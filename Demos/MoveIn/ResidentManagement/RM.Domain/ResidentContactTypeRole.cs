namespace SLS.RM.Domain;

public partial class ResidentContactTypeRole
{
	public ResidentContactTypeRole()
	{
		ResidentContactTypes = new HashSet<ResidentContactType>();
	}

	public int ResidentContactTypeRoleId { get; set; }
	public string ResidentContactTypeRoleName { get; set; } = null!;
	public int RowStatusId { get; set; }

	public virtual ICollection<ResidentContactType> ResidentContactTypes { get; set; }
}
