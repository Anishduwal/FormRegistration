using Campaign.Models;

namespace Campaign.Repository.Organization
{
    public interface IOrganizationRepo
    {
        public List<OrganizationModel> ReadOrganization();
        public OrganizationModel CreateOrganization(OrganizationModel model, string filePath);
        public OrganizationModel UpdateOrganization(OrganizationModel model);
        public OrganizationModel DeleteOrganization(OrganizationModel model);
        public Task<OrganizationModel> GetOrgByIdAsync(int Id);
        public List<FieldDetailsModel> GetColumnField();
        public OrganizationFieldModel AddOrganizationField(OrganizationFieldModel model);
        public List<OrganizationFieldModel> OrganizationEvent(int OrgId);
        public OrganizationFieldModel GetOrganizationFieldById(int Id);
        public OrganizationFieldModel UpdateOrganizationField(OrganizationFieldModel model);
        public OrganizationFieldModel RemoveOrganizationField(int Id);

    }
}
