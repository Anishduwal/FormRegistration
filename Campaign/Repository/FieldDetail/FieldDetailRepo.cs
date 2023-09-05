using Campaign.Data;
using Campaign.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Campaign.Repository.FieldDetail
{
    public class FieldDetailRepo : IFieldDetailRepo
    {
        private readonly DapperContext _context;
        public FieldDetailRepo(DapperContext context)
        {
            _context = context;
        }
        public FieldDetailsModel AddFields(FieldDetailsModel model)
        {
            FieldDetailsModel obj = new FieldDetailsModel();
            var param = new DynamicParameters();
            param.Add("@Id", model.Id);
            param.Add("@FieldName", model.FieldName);
            param.Add("@DataType", model.DataType);
            using (var connection = _context.CreateConnection())
            {
                obj = connection.QueryFirstOrDefault<FieldDetailsModel>(sql: "[dbo].[sproc_dynamic_add_fields]", param: param, commandType: CommandType.StoredProcedure);
                return new FieldDetailsModel
                {
                    Id = obj.Id
                };
            }
        }
        public List<FieldTypeModel> GetFieldDataTypes()
        {
            List<FieldTypeModel> obj = new List<FieldTypeModel>();
            var param = new DynamicParameters();
            using (var connection = _context.CreateConnection())
            {
                obj = connection.Query<FieldTypeModel>(sql: "[dbo].[sproc_get_fieldtype]", param: param, commandType: CommandType.StoredProcedure).ToList();
                return obj;
            }
        }
        public List<CategoryModel> GetCategory()
        {
            List<CategoryModel> obj = new List<CategoryModel>();
            var param = new DynamicParameters();
            using (var connection = _context.CreateConnection())
            {
                obj = connection.Query<CategoryModel>(sql: "[dbo].[sproc_get_Category]", param: param, commandType: CommandType.StoredProcedure).ToList();
                return obj;
            }
        }
        public TblFieldDetailsModel InsertFields(TblFieldDetailsModel model)
        {
            TblFieldDetailsModel obj = new TblFieldDetailsModel();
            var param = new DynamicParameters();
            param.Add("@Flag", "Insert");
            param.Add("@FieldName", model.FieldName);
            param.Add("@DataType", model.DataType);
            param.Add("@CategoryId", model.CategoryId);
            param.Add("@OrderId", model.OrderId);
            using (var connection = _context.CreateConnection())
            {
                obj = connection.QueryFirstOrDefault<TblFieldDetailsModel>(sql: "[dbo].[sproc_create_field_and_datatype]", param: param, commandType: CommandType.StoredProcedure);
                return obj;
            }
        }
    }
}
