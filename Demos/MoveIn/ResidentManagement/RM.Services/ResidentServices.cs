using SLS.LM.Services.Requests;

namespace SLS.LM.Services;

public class ResidentServices : ServicesBase
{

	public ResidentServices(string connectionString) : base(connectionString) { }

	public async Task<ResidentResponse?> GetResidentAsync(int residentId)
	{
		using RMContext rmContext = new(_connectionString);
		return BuildResidentResponse(await GetResidentDataAsync(residentId, rmContext));
	}

	public async Task<int> MoveInResidentAsync(MoveInRequest moveInRequest)
	{
		using RMContext rmContext = new(_connectionString);
		return await CreateResidentAsync(rmContext, moveInRequest);
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
			CommunityId = communityId
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
				ResidentCommunityId = residentCommunity.CommunityId,
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

	private static async Task<Resident?> GetResidentDataAsync(int residentId, RMContext rmContext)
		=> await rmContext.Residents
			.Include(x => x.ResidentCommunities)
				.ThenInclude(x => x.Community)
			.Include(x => x.ResidentCommunities)
				.ThenInclude(x => x.Lease)
			.Include(x => x.ResidentCommunities)
				.ThenInclude(x => x.ResidentRooms)
					.ThenInclude(x => x.Room)
			.Include(x => x.ResidentCommunities)
				.ThenInclude(x => x.ResidentCareLevels)
					.ThenInclude(x => x.CareLevel)
			.Include(x => x.ResidentCommunities)
				.ThenInclude(x => x.ResidentAncillaryCares)
					.ThenInclude(x => x.AncillaryCare)
						.ThenInclude(x => x.AncillaryCareCategory)
			.Include(x => x.ResidentContacts)
				.ThenInclude(x => x.ResidentContactType)
			.Include(x => x.ResidentContacts)
				.ThenInclude(x => x.ResidentContactPhoneNumbers)
					.ThenInclude(x => x.PhoneNumberType)
			.Include(x => x.ResidentContacts)
				.ThenInclude(x => x.ResidentContactPostalAddresses)
					.ThenInclude(x => x.PostalAddressType)
			.FirstOrDefaultAsync(x => x.ResidentId == residentId);

	private static ResidentResponse? BuildResidentResponse(Resident? resident)
		=> (resident is null) ? null : new ResidentResponse()
		{
			ResidentId = resident.ResidentId,
			FirstName = resident.FirstName,
			MiddleName = resident.MiddleName,
			LastName = resident.LastName,
			DateOfBirth = resident.DateOfBirth,
			ResidentCommunities = BuildResidentCommunityResponseList(resident.ResidentCommunities),
			Contacts = BuildResidentContactResponseList(resident.ResidentContacts)
		};

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