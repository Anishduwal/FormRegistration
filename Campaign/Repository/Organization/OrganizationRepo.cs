using Campaign.Data;
using Campaign.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Campaign.Repository.Organization
{
    public class OrganizationRepo : IOrganizationRepo
    {
        private readonly DapperContext _context;
        public OrganizationRepo(DapperContext context)
        {
            _context = context;
        }
        public List<OrganizationModel> ReadOrganization()
        {
            List<OrganizationModel> obj = new List<OrganizationModel>();
            var param = new DynamicParameters();
            //param.Add("@Flag", "Select");
            using (var connection = _context.CreateConnection())
            {
                obj = connection.Query<OrganizationModel>(sql: "[dbo].[sproc_Read_organization]", param: param, commandType: CommandType.StoredProcedure).ToList();
                return obj;
            }
        }
        public OrganizationModel CreateOrganization(OrganizationModel model, string filePath)
        {
            OrganizationModel obj = new OrganizationModel();
            var param = new DynamicParameters();
            param.Add("@Flag", "Insert");
            param.Add("@Id", model.Id);
            param.Add("@Name", model.OrganizationName);
            param.Add("@FullAddress", model.FullAddress);
            param.Add("@EmailAddress", model.EmailAddress);
            param.Add("@MobileNo", model.MobileNo);
            param.Add("@Username", model.UserName);
            param.Add("@Password", model.Password);
            param.Add("@RegistrationNumber", model.RegistrationNumber);
            param.Add("@DirectorName", model.DirectorName);
            param.Add("@VatPanNumber", model.VatPanNumber);
            param.Add("@VatPanImage", filePath);
            param.Add("@IsActive", model.IsActive);
            param.Add("@IsDeleted", model.IsDeleted);
            using (var connection = _context.CreateConnection())
            {
                obj = connection.QueryFirstOrDefault<OrganizationModel>(sql: "[dbo].[sproc_create_or_update_organization]", param: param, commandType: CommandType.StoredProcedure);
                return new OrganizationModel
                {
                    Id = obj.Id
                };
            }
        }
        public async Task<OrganizationModel> GetOrgByIdAsync(int Id)
        {
            OrganizationModel obj = new OrganizationModel();
            var param = new DynamicParameters();
            param.Add("@Id", dbType: DbType.Int32, value: Id, direction: ParameterDirection.Input);
            using (var connection = _context.CreateConnection())
            {
                obj = await connection.QueryFirstOrDefaultAsync<OrganizationModel>(sql: "[dbo].[sproc_get_Organization_By_Id]", param: param, commandType: CommandType.StoredProcedure);
                return new OrganizationModel
                {
                    Id = obj.Id,
                    OrganizationName = obj.OrganizationName,
                    FullAddress = obj.FullAddress,
                    EmailAddress = obj.EmailAddress,
                    MobileNo = obj.MobileNo,
                    UserName = obj.UserName,
                    Password = obj.Password,
                    RegistrationNumber = obj.RegistrationNumber,
                    DirectorName = obj.DirectorName,
                    VatPanNumber = obj.VatPanNumber,
                    IsActive = obj.IsActive,
                    UpdatedBy = obj.UpdatedBy
                };
            }
        }
        public OrganizationModel UpdateOrganization(OrganizationModel model)
        {
            OrganizationModel obj = new OrganizationModel();
            var param = new DynamicParameters();
            param.Add("@Flag", "Update");
            param.Add("@Id", model.Id);
            param.Add("@Name", model.OrganizationName);
            param.Add("@FullAddress", model.FullAddress);
            param.Add("@EmailAddress", model.EmailAddress);
            param.Add("@MobileNo", model.MobileNo);
            param.Add("@Username", model.UserName);
            param.Add("@Password", model.Password);
            param.Add("@RegistrationNumber", model.RegistrationNumber);
            param.Add("@DirectorName", model.DirectorName);
            param.Add("@VatPanNumber", model.VatPanNumber);
            param.Add("@VatPanImage", model.VatPanImage);
            param.Add("@IsActive", model.IsActive);
            param.Add("@IsDeleted", model.IsDeleted);
            using (var connection = _context.CreateConnection())
            {
                obj = connection.QueryFirstOrDefault<OrganizationModel>(sql: "[dbo].[sproc_create_or_update_organization]", param: param, commandType: CommandType.StoredProcedure);
                return new OrganizationModel
                {
                    Id = obj.Id
                };

            }
        }
        public OrganizationModel DeleteOrganization(OrganizationModel model)
        {
            OrganizationModel obj = new OrganizationModel();
            var param = new DynamicParameters();
            param.Add("@Id", model.Id);
            using (var connection = _context.CreateConnection())
            {
                obj = connection.QueryFirstOrDefault<OrganizationModel>(sql: "[dbo].[sproc_delete_organization]", param: param, commandType: CommandType.StoredProcedure);
                return obj;
            }
        }
        public List<FieldDetailsModel> GetColumnField()
        {
            List<FieldDetailsModel> obj = new List<FieldDetailsModel>();
            var param = new DynamicParameters();
            using (var connection = _context.CreateConnection())
            {
                obj = connection.Query<FieldDetailsModel>(sql: "[dbo].[sproc_Get_Column_FieldName]", param: param, commandType: CommandType.StoredProcedure).ToList();
                return obj;
            };

        }
        public OrganizationFieldModel AddOrganizationField(OrganizationFieldModel model)
        {
            OrganizationFieldModel obj = new OrganizationFieldModel();
            var param = new DynamicParameters();
            param.Add("@Flag", "Insert");
            param.Add("@OrgId", model.OrgId);
            param.Add("@OrgFormTypeName", model.OrgFormTypeName);
            param.Add("@JsonField", model.JsonField);
            using (var connection = _context.CreateConnection())
            {
                obj = connection.QueryFirstOrDefault<OrganizationFieldModel>(sql: "[dbo].[sproc_create_organization_field]", param: param, commandType: CommandType.StoredProcedure);
                return new OrganizationFieldModel
                {
                    Id = obj.Id
                };
            }

        }
        public List<OrganizationFieldModel> OrganizationEvent(int OrgId)
        {
            List<OrganizationFieldModel> obj = new List<OrganizationFieldModel>();
            var param = new DynamicParameters();
            param.Add("@OrgId", OrgId);
            using (var connection = _context.CreateConnection())
            {
                obj = connection.Query<OrganizationFieldModel>(sql: "[dbo].[sproc_view_organization_event]", param: param, commandType: CommandType.StoredProcedure).ToList();
                return obj;
            }

        }
        public OrganizationFieldModel GetOrganizationFieldById(int Id)
        {
            OrganizationFieldModel obj = new OrganizationFieldModel();
            var param = new DynamicParameters();
            param.Add("@Flag", "Read");
            param.Add("@Id", Id);
            using (var connection = _context.CreateConnection())
            {
                obj = connection.QueryFirstOrDefault<OrganizationFieldModel>(sql: "[dbo].[sproc_create_organization_field]", param: param, commandType: CommandType.StoredProcedure);
                return new OrganizationFieldModel
                {
                    Id = obj.Id,
                    OrgId = obj.OrgId,
                    OrgFormTypeName = obj.OrgFormTypeName,
                    JsonField = obj.JsonField,
                };
            }
        }
        public OrganizationFieldModel UpdateOrganizationField(OrganizationFieldModel model)
        {
            OrganizationFieldModel obj = new OrganizationFieldModel();
            var param = new DynamicParameters();
            param.Add("@Flag", "Update");
            param.Add("@Id", model.Id);
            param.Add("@OrgId", model.OrgId);
            param.Add("@JsonField", model.JsonField);
            param.Add("@OrgFormTypeName", model.OrgFormTypeName);
            using (var connection = _context.CreateConnection())
            {
                obj = connection.QueryFirstOrDefault<OrganizationFieldModel>(sql: "[dbo].[sproc_create_organization_field]", param: param, commandType: CommandType.StoredProcedure);
                return new OrganizationFieldModel
                {
                    Id = obj.Id,
                    OrgId = obj.OrgId,
                    OrgFormTypeName = obj.OrgFormTypeName,
                    JsonField = obj.JsonField,
                };
            }
        }
        public OrganizationFieldModel RemoveOrganizationField(int Id)
        {
            OrganizationFieldModel obj = new OrganizationFieldModel();
            var param = new DynamicParameters();
            param.Add("@Flag", "Delete");
            param.Add("@Id", Id);
            using (var connection = _context.CreateConnection())
            {
                obj = connection.QueryFirstOrDefault<OrganizationFieldModel>(sql: "[dbo].[sproc_create_organization_field]", param: param, commandType: CommandType.StoredProcedure);
                return obj;
            };
        }

    }
}
