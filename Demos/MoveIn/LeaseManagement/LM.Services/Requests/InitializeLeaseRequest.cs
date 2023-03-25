using SLS.Common.Services.EventMessages;

namespace SLS.LM.Services.Requests;

public class InitializeLeaseRequest
{

	public InitializeLeaseRequest() { }

	public InitializeLeaseRequest(ResidentMoveInEventMessage residentMoveInEventMessage)
	{

		if (residentMoveInEventMessage.Lease is null)
		{
			throw new ArgumentException("Lease not specified");
		}
		else
		{
			Lease = new()
			{
				LeaseTypeId = residentMoveInEventMessage.Lease.LeaseTypeId,
				StartDate = residentMoveInEventMessage.Lease.StartDate,
				EndDate = residentMoveInEventMessage.Lease.EndDate,
				Rate = residentMoveInEventMessage.Lease.Rate
			};
			Lessee = new()
			{
				FirstName = residentMoveInEventMessage.Lease.LesseeFirstName ?? string.Empty,
				MiddleName = residentMoveInEventMessage.Lease.LesseeMiddleName,
				LastName = residentMoveInEventMessage.Lease.LesseeLastName ?? string.Empty,
				EmailAddress = residentMoveInEventMessage.Lease.LesseeEmail
			};
		}

		if (residentMoveInEventMessage.Resident is null)
		{
			throw new ArgumentException("Resident not specified");
		}
		else
		{
			Resident = new()
			{
				FirstName = residentMoveInEventMessage.Resident.FirstName ?? string.Empty,
				MiddleName = residentMoveInEventMessage.Resident.MiddleName,
				LastName = residentMoveInEventMessage.Resident.LastName ?? string.Empty
			};
		}

		if (residentMoveInEventMessage.ResponsibleParty is null)
		{
			throw new ArgumentException("Responsible Party not speciifed");
		}
		else
		{
			ResponsibleParty = new()
			{
				FirstName = residentMoveInEventMessage.ResponsibleParty.FirstName ?? string.Empty,
				MiddleName = residentMoveInEventMessage.ResponsibleParty.MiddleName,
				LastName = residentMoveInEventMessage.ResponsibleParty.LastName ?? string.Empty,
				EmailAddress = residentMoveInEventMessage.ResponsibleParty.EmailAddress
			};
		}

	}

	public LeaseRequest Lease { get; set; } = null!;
	public ResidentRequest Resident { get; set; } = null!;
	public ContactRequest Lessee { get; set; } = null!;
	public ContactRequest ResponsibleParty { get; set; } = null!;

}