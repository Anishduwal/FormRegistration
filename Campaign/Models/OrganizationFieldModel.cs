namespace Campaign.Models
{
    public class OrganizationFieldModel
    {
        public int Id { get; set; }
        public int OrgId { get; set; }
        public string? JsonField { get; set; }
        public string? OrgFormTypeName { get; set; }
        public bool IsDeleted { get; set; }
        public List<FieldDetailsModel> Field { get; set; }
        public List<FieldDetailsModel> SelectedField { get; set; }
        public List<OrganizationModel> Organization { get; set; }
        public string? OrganizationName { get; set; }

    }
}
