namespace SLS.RM.Domain;

public partial class ResidentContactType
{
	public ResidentContactType()
	{
		ResidentContacts = new HashSet<ResidentContact>();
	}

	public int ResidentContactTypeId { get; set; }
	public string? ExternalId { get; set; }
	public string ResidentContactTypeName { get; set; } = null!;
	public int ResidentContactTypeRoleId { get; set; }
	public int RowStatusId { get; set; }

	public virtual ResidentContactTypeRole ResidentContactTypeRole { get; set; } = null!;
	public virtual ICollection<ResidentContact> ResidentContacts { get; set; }
}
