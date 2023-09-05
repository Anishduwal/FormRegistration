using Campaign.Models;

namespace Campaign.Repository.FieldDetail
{
    public interface IFieldDetailRepo
    {
        public FieldDetailsModel AddFields(FieldDetailsModel model);
        public List<FieldTypeModel> GetFieldDataTypes();
        public List<CategoryModel> GetCategory();
        public TblFieldDetailsModel InsertFields(TblFieldDetailsModel model);
    }
}
