using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using SLS.Common.Services.EventMessages;
using System.Text;
using System.Text.Json;

namespace SLS.RM.Services;

public class ResidentServices : ServicesBase, IResidentServices
{

	private readonly string _eventHubConnectionString;

	public ResidentServices(
		string connectionString,
		string eventHubConnectionString) : base(connectionString)
		=> _eventHubConnectionString = eventHubConnectionString;

	public async Task<ResidentResponse?> GetResidentAsync(int residentId)
	{
		using RMContext rmContext = new(_connectionString);
		return BuildResidentResponse(await GetResidentDataAsync(residentId, rmContext));
	}

	public async Task<int> MoveInResidentAsync(MoveInRequest moveInRequest, string eventHubName)
	{
		using RMContext rmContext = new(_connectionString);
		int residentId = await CreateResidentAsync(rmContext, moveInRequest);
		await SendMoveInMessage(eventHubName, moveInRequest, residentId);
		return residentId;
	}

	private async Task SendMoveInMessage(string eventHubName, MoveInRequest moveInRequest, int residentId)
	{
		await using EventHubProducerClient producerClient = new(_eventHubConnectionString, eventHubName);
		// Create a batch of events
		using EventDataBatch eventDataBatch = await producerClient.CreateBatchAsync();

		if (!eventDataBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(GenerateResidentMoveInEventMessage(moveInRequest, residentId))))))
			// if it is too large for the batch
			throw new Exception($"Event is too large for the batch and cannot be sent.");

		try
		{
			// Use the producer client to send the batch of events to the event hub
			await producerClient.SendAsync(eventDataBatch);
		}
		finally
		{
			await producerClient.CloseAsync();
		}
	}

	private static async Task<int> CreateResidentAsync(RMContext rmContext, MoveInRequest moveInRequest)
	{
		Resident resident = await CreateResidentRecordAsync(rmContext, moveInRequest.Resident);
		ResidentCommunity residentCommunity = await CreateResidentCommunityRecordAsync(rmContext, resident.ResidentId, moveInRequest.CommunityId);
		await CreateResidentRoomsAsync(rmContext, residentCommunity, moveInRequest.Rooms);
		await CreateResponsiblePartyAsync(rmContext, resident.ResidentId, moveInRequest.ResponsibleParty);
		await CreateLeeseeAsync(rmContext, resident.ResidentId, moveInRequest.Lease);
		return resident.ResidentId;
	}

	private static async Task<Resident> CreateResidentRecordAsync(RMContext rmContext, MoveInResidentRequest? moveInResidentRequest)
	{
		if (moveInResidentRequest is null) throw new ArgumentNullException(nameof(moveInResidentRequest));
		if (string.IsNullOrWhiteSpace(moveInResidentRequest.FirstName)) throw new ArgumentNullException(nameof(moveInResidentRequest.FirstName));
		if (string.IsNullOrWhiteSpace(moveInResidentRequest.LastName)) throw new ArgumentNullException(nameof(moveInResidentRequest.LastName));
		Resident resident = new()
		{
			FirstName = moveInResidentRequest.FirstName,
			MiddleName = moveInResidentRequest.MiddleName,
			LastName = moveInResidentRequest.LastName,
			DateOfBirth = moveInResidentRequest.DateOfBirth
		};
		await rmContext.AddAsync(resident);
		await rmContext.SaveChangesAsync();
		return resident;
	}

	private static async Task<ResidentCommunity> CreateResidentCommunityRecordAsync(RMContext rmContext, int residentId, int communityId)
	{
		ResidentCommunity residentCommunity = new()
		{
			ResidentId = residentId,
			CommunityId = communityId,
			LeaseId = null
		};
		await rmContext.AddAsync(residentCommunity);
		await rmContext.SaveChangesAsync();
		return residentCommunity;
	}

	private static async Task CreateResidentRoomsAsync(RMContext rmContext, ResidentCommunity residentCommunity, List<MoveInRoomRequest> moveInRoomRequests)
	{
		foreach (MoveInRoomRequest moveInRoomRequest in moveInRoomRequests)
			await rmContext.ResidentRooms.AddAsync(new()
			{
				ResidentCommunityId = residentCommunity.ResidentCommunityId,
				RoomId = moveInRoomRequest.RoomId,
				EffectiveDate = moveInRoomRequest.EffectiveDate,
				Rate = moveInRoomRequest.Rate
			});
		await rmContext.SaveChangesAsync();
	}

	private static async Task CreateResponsiblePartyAsync(RMContext rmContext, int residentId, MoveInResponsiblePartyRequest? moveInResponsiblePartyRequest)
	{
		if (moveInResponsiblePartyRequest is not null)
		{
			ResidentContact residentContact = new()
			{
				ResidentId = residentId,
				ResidentContactTypeId = 5,
				FirstName = moveInResponsiblePartyRequest.FirstName,
				MiddleName = moveInResponsiblePartyRequest.MiddleName,
				LastName = moveInResponsiblePartyRequest.LastName ?? string.Empty,
				EmailAddress = moveInResponsiblePartyRequest.EmailAddress,
				HasPowerOfAttorney = moveInResponsiblePartyRequest.HasPowerOfAttorney,
				HasDurablePowerOfAttorney = moveInResponsiblePartyRequest.HasDurablePowerOfAttorney,
				IsLegalGuardian = moveInResponsiblePartyRequest.IsLegalGuardian,
				IsMedicalPowerOfAttorney = moveInResponsiblePartyRequest.IsMedicalPowerOfAttorney
			};
			await rmContext.AddAsync(residentContact);
			await rmContext.SaveChangesAsync();

			if (moveInResponsiblePartyRequest.PhoneNumber is not null)
				await rmContext.ResidentContactPhoneNumbers.AddAsync(new()
				{
					ResidentContactId = residentContact.ResidentContactId,
					PhoneNumberTypeId = moveInResponsiblePartyRequest.PhoneNumber.PhoneNumberTypeId,
					CountryCode = moveInResponsiblePartyRequest.PhoneNumber.CountryCode,
					PhoneNumber = moveInResponsiblePartyRequest.PhoneNumber.PhoneNumber ?? string.Empty,
					IsDefault = moveInResponsiblePartyRequest.PhoneNumber.IsDefault
				});

			if (moveInResponsiblePartyRequest.PostalAddress is not null)
				await rmContext.ResidentContactPostalAddresses.AddAsync(new()
				{
					ResidentContactId = residentContact.ResidentContactId,
					PostalAddressTypeId = 1,
					StreetAddress1 = moveInResponsiblePartyRequest.PostalAddress.StreetAddress1,
					StreetAddress2 = moveInResponsiblePartyRequest.PostalAddress.StreetAddress2,
					City = moveInResponsiblePartyRequest.PostalAddress.City ?? string.Empty,
					CountryDivisionCode = moveInResponsiblePartyRequest.PostalAddress.CountryDivision,
					CountryCode = moveInResponsiblePartyRequest.PostalAddress.Country ?? string.Empty,
					PostalCode = moveInResponsiblePartyRequest.PostalAddress.PostalCode
				});

			await rmContext.SaveChangesAsync();

		}
	}

	private static async Task CreateLeeseeAsync(RMContext rmContext, int residentId, MoveInLeaseRequest? moveInLeaseRequest)
	{
		if (moveInLeaseRequest is not null)
		{
			ResidentContact residentContact = new()
			{
				ResidentId = residentId,
				ResidentContactTypeId = 5,
				FirstName = moveInLeaseRequest.LesseeFirstName,
				MiddleName = moveInLeaseRequest.LesseeMiddleName,
				LastName = moveInLeaseRequest.LesseeLastName ?? string.Empty,
				EmailAddress = moveInLeaseRequest.LesseeEmail
			};
			await rmContext.AddAsync(residentContact);
			await rmContext.SaveChangesAsync();

			if (moveInLeaseRequest.PhoneNumber is not null)
				await rmContext.ResidentContactPhoneNumbers.AddAsync(new()
				{
					ResidentContactId = residentContact.ResidentContactId,
					PhoneNumberTypeId = moveInLeaseRequest.PhoneNumber.PhoneNumberTypeId,
					CountryCode = moveInLeaseRequest.PhoneNumber.CountryCode,
					PhoneNumber = moveInLeaseRequest.PhoneNumber.PhoneNumber ?? string.Empty,
					IsDefault = moveInLeaseRequest.PhoneNumber.IsDefault
				});

			if (moveInLeaseRequest.PostalAddress is not null)
				await rmContext.ResidentContactPostalAddresses.AddAsync(new()
				{
					ResidentContactId = residentContact.ResidentContactId,
					PostalAddressTypeId = 1,
					StreetAddress1 = moveInLeaseRequest.PostalAddress.StreetAddress1,
					StreetAddress2 = moveInLeaseRequest.PostalAddress.StreetAddress2,
					City = moveInLeaseRequest.PostalAddress.City ?? string.Empty,
					CountryDivisionCode = moveInLeaseRequest.PostalAddress.CountryDivision,
					CountryCode = moveInLeaseRequest.PostalAddress.Country ?? string.Empty,
					PostalCode = moveInLeaseRequest.PostalAddress.PostalCode
				});

			await rmContext.SaveChangesAsync();

		}
	}

	private static ResidentMoveInEventMessage GenerateResidentMoveInEventMessage(MoveInRequest moveInRequest, int residentId)
	{
		return new()
		{
			CommunityId = moveInRequest.CommunityId,
			Resident = new()
			{
				ResidentId = residentId,
				FirstName = moveInRequest.Resident?.FirstName,
				MiddleName = moveInRequest.Resident?.MiddleName,
				LastName = moveInRequest.Resident?.LastName,
				DateOfBirth = moveInRequest.Resident?.DateOfBirth ?? DateTime.UtcNow
			},
			Lease = new()
			{
				LeaseTypeId = moveInRequest.Lease?.LeaseTypeId ?? 1,
				StartDate = moveInRequest.Lease?.StartDate ?? DateTime.UtcNow,
				EndDate = moveInRequest.Lease?.EndDate ?? DateTime.UtcNow,
				LesseeFirstName = moveInRequest.Lease?.LesseeFirstName,
				LesseeMiddleName = moveInRequest.Lease?.LesseeMiddleName,
				LesseeEmail = moveInRequest.Lease?.LesseeLastName,
				PostalAddress = new()
				{
					StreetAddress1 = moveInRequest.Lease?.PostalAddress?.StreetAddress1,
					StreetAddress2 = moveInRequest.Lease?.PostalAddress?.StreetAddress2,
					City = moveInRequest.Lease?.PostalAddress?.City,
					CountryDivision = moveInRequest.Lease?.PostalAddress?.CountryDivision,
					Country = moveInRequest.Lease?.PostalAddress?.Country,
					PostalCode = moveInRequest.Lease?.PostalAddress?.PostalCode
				},
				PhoneNumber = new()
				{
					PhoneNumberTypeId = moveInRequest.Lease?.PhoneNumber?.PhoneNumberTypeId ?? 1,
					CountryCode = moveInRequest.Lease?.PhoneNumber?.CountryCode,
					PhoneNumber = moveInRequest.Lease?.PhoneNumber?.PhoneNumber,
					IsDefault = moveInRequest.Lease?.PhoneNumber?.IsDefault ?? true
				}
			},
			Rooms = GenerateMoveInRoomEventMessage(moveInRequest),
			ResponsibleParty = new()
			{
				FirstName = moveInRequest.ResponsibleParty?.FirstName,
				MiddleName = moveInRequest.ResponsibleParty?.MiddleName,
				LastName = moveInRequest.ResponsibleParty?.LastName,
				PostalAddress = new()
				{
					StreetAddress1 = moveInRequest.ResponsibleParty?.PostalAddress?.StreetAddress1,
					StreetAddress2 = moveInRequest.ResponsibleParty?.PostalAddress?.StreetAddress2,
					City = moveInRequest.ResponsibleParty?.PostalAddress?.City,
					CountryDivision = moveInRequest.ResponsibleParty?.PostalAddress?.CountryDivision,
					Country = moveInRequest.ResponsibleParty?.PostalAddress?.Country,
					PostalCode = moveInRequest.ResponsibleParty?.PostalAddress?.PostalCode
				},
				PhoneNumber = new()
				{
					PhoneNumberTypeId = moveInRequest.ResponsibleParty?.PhoneNumber?.PhoneNumberTypeId ?? 1,
					CountryCode = moveInRequest.ResponsibleParty?.PhoneNumber?.CountryCode,
					PhoneNumber = moveInRequest.ResponsibleParty?.PhoneNumber?.PhoneNumber,
					IsDefault = moveInRequest.ResponsibleParty?.PhoneNumber?.IsDefault ?? true
				},
				HasPowerOfAttorney = moveInRequest.ResponsibleParty?.HasPowerOfAttorney ?? false,
				HasDurablePowerOfAttorney = moveInRequest.ResponsibleParty?.HasDurablePowerOfAttorney ?? false,
				IsLegalGuardian = moveInRequest.ResponsibleParty?.IsLegalGuardian ?? false,
				IsMedicalPowerOfAttorney = moveInRequest.ResponsibleParty?.IsMedicalPowerOfAttorney ?? false
			}
		};
	}

	private static List<MoveInRoomEventMessage> GenerateMoveInRoomEventMessage(MoveInRequest moveInRequest)
	{
		List<MoveInRoomEventMessage> response = new();
		foreach (MoveInRoomRequest moveInRoomRequest in moveInRequest.Rooms)
			response.Add(new()
			{
				RoomId = moveInRoomRequest.RoomId,
				EffectiveDate = moveInRoomRequest.EffectiveDate,
				Rate = moveInRoomRequest.Rate
			});
		return response;
	}

	private static async Task<Resident?> GetResidentDataAsync(int residentId, RMContext rmContext)
		=> await rmContext.Residents
			.Include(x => x.ResidentCommunities)
				.ThenInclude(x => x.Community)
			.Include(x => x.ResidentCommunities)
				.ThenInclude(x => x.Lease)
			.Include(x => x.ResidentCommunities)
				.ThenInclude(x => x.ResidentRooms)
					.ThenInclude(x => x.Room)
			//.Include(x => x.ResidentCommunities)
			//	.ThenInclude(x => x.ResidentCareLevels)
			//		.ThenInclude(x => x.CareLevel)
			//.Include(x => x.ResidentCommunities)
			//	.ThenInclude(x => x.ResidentAncillaryCares)
			//		.ThenInclude(x => x.AncillaryCare)
			//			.ThenInclude(x => x.AncillaryCareCategory)
			.Include(x => x.ResidentContacts)
				.ThenInclude(x => x.ResidentContactType)
					.ThenInclude(x => x.ResidentContactTypeRole)
			.Include(x => x.ResidentContacts)
				.ThenInclude(x => x.ResidentContactPhoneNumbers)
					.ThenInclude(x => x.PhoneNumberType)
			.Include(x => x.ResidentContacts)
				.ThenInclude(x => x.ResidentContactPostalAddresses)
					.ThenInclude(x => x.PostalAddressType)
			.FirstOrDefaultAsync(x => x.ResidentId == residentId);

	private static ResidentResponse? BuildResidentResponse(Resident? resident)
	{
		ResidentResponse? response = default;
		if (resident is not null)
		{
			response = new ResidentResponse()
			{
				ResidentId = resident.ResidentId,
				FirstName = resident.FirstName,
				MiddleName = resident.MiddleName,
				LastName = resident.LastName,
				DateOfBirth = resident.DateOfBirth,
				ResidentCommunities = BuildResidentCommunityResponseList(resident.ResidentCommunities),
				Contacts = BuildResidentContactResponseList(resident.ResidentContacts)
			};
		}
		return response;
	}

	private static List<ResidentCommunityResponse> BuildResidentCommunityResponseList(ICollection<ResidentCommunity>? residentCommunities)
	{
		List<ResidentCommunityResponse> response = new();



		if (residentCommunities is not null && residentCommunities.Any())
			foreach (ResidentCommunity residentCommunity in residentCommunities)
				response.Add(BuildResidentCommunityResponse(residentCommunity));
		return response;
	}

	private static ResidentCommunityResponse BuildResidentCommunityResponse(ResidentCommunity residentCommunity)
	{
		ResidentCommunityResponse response = new()
		{
			ResidentCommunityId = residentCommunity.ResidentCommunityId,
			CommunityNumber = residentCommunity.Community.CommunityNumber,
			CommunityName = residentCommunity.Community.CommunityName,
			Lease = (residentCommunity.Lease is null) ? default : new()
			{
				LeaseId = residentCommunity.Lease.LeaseId,
				StartDate = residentCommunity.Lease.StartDate,
				EndDate = residentCommunity.Lease.EndDate,
			},
			Rooms = BuildResidentRoomResponseList(residentCommunity.ResidentRooms)
		};
		return response;
	}

	private static List<ResidentRoomResponse> BuildResidentRoomResponseList(ICollection<ResidentRoom>? residentRooms)
	{
		List<ResidentRoomResponse> response = new();
		if (residentRooms is not null && residentRooms.Any())
		{
			foreach (ResidentRoom residentRoom in residentRooms)
			{
				response.Add(new()
				{
					ResidentRoomId = residentRoom.ResidentRoomId,
					RoomId = residentRoom.RoomId,
					RoomNumber = residentRoom.Room.RoomNumber,
					Rate = residentRoom.Rate,
					EffectiveDate = residentRoom.EffectiveDate
				});
			}
		}
		return response;
	}

	private static Dictionary<string, List<ResidentContactResponse>> BuildResidentContactResponseList(ICollection<ResidentContact>? residentContacts)
	{
		Dictionary<string, List<ResidentContactResponse>> response = new();
		if (residentContacts is not null && residentContacts.Any())
		{
			foreach (ResidentContact residentContact in residentContacts)
			{
				response.TryAdd(residentContact.ResidentContactType.ResidentContactTypeRole.ResidentContactTypeRoleName, new());
				response[residentContact.ResidentContactType.ResidentContactTypeRole.ResidentContactTypeRoleName].Add(new()
				{
					ResidentContactId = residentContact.ResidentContactId,
					ResidentContactType = residentContact.ResidentContactType.ResidentContactTypeName,
					FirstName = residentContact.FirstName,
					MiddleName = residentContact.MiddleName,
					LastName = residentContact.LastName,
					EmailAddress = residentContact.EmailAddress,
					HasPowerOfAttorney = residentContact.HasPowerOfAttorney,
					HasDurablePowerOfAttorney = residentContact.HasDurablePowerOfAttorney,
					IsLegalGuardian = residentContact.IsLegalGuardian,
					IsMedicalPowerOfAttorney = residentContact.IsMedicalPowerOfAttorney,
					PhoneNumbers = AddResidentContactPhoneNumber(residentContact.ResidentContactPhoneNumbers),
					PostalAddresses = AddResidentContactPostalAddresses(residentContact.ResidentContactPostalAddresses)
				});
			}
		}
		return response;
	}

	private static List<PhoneNumberResponse> AddResidentContactPhoneNumber(ICollection<ResidentContactPhoneNumber>? residentContactPhoneNumbers)
	{
		List<PhoneNumberResponse> response = new();
		if (residentContactPhoneNumbers is not null && residentContactPhoneNumbers.Any())
			foreach (ResidentContactPhoneNumber residentContactPhoneNumber in residentContactPhoneNumbers)
				response.Add(new()
				{
					PhoneNumberId = residentContactPhoneNumber.ResidentContactPhoneNumberId,
					PhoneNumberType = residentContactPhoneNumber.PhoneNumberType.PhoneNumberTypeName,
					IsDefault = residentContactPhoneNumber.IsDefault,
					CountryCode = residentContactPhoneNumber.CountryCode,
					PhoneNumber = residentContactPhoneNumber.PhoneNumber
				});
		return response;
	}

	private static List<PostalAddressResponse> AddResidentContactPostalAddresses(ICollection<ResidentContactPostalAddress>? residentContactPostalAddresses)
	{
		List<PostalAddressResponse> response = new();
		if (residentContactPostalAddresses is not null && residentContactPostalAddresses.Any())
			foreach (ResidentContactPostalAddress residentContactPostalAddress in residentContactPostalAddresses)
				response.Add(new()
				{
					PostalAddressId = residentContactPostalAddress.ResidentContactPostalAddressId,
					PostalAddressType = residentContactPostalAddress.PostalAddressType?.PostalAddressTypeName,
					StreetAddress1 = residentContactPostalAddress.StreetAddress1,
					StreetAddress2 = residentContactPostalAddress.StreetAddress2,
					City = residentContactPostalAddress.City,
					CountryDivision = residentContactPostalAddress.CountryDivisionCode,
					Country = residentContactPostalAddress.CountryCode,
					PostalCode = residentContactPostalAddress.PostalCode,
					IsDefault = residentContactPostalAddress.PostalAddressType?.IsDefault ?? false
				});
		return response;
	}
}