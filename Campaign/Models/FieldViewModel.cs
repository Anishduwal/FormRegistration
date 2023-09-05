using System.Collections.Generic;

namespace Campaign.Models
{
    public class FieldViewModel
    {
        public List<FieldDetailsModel> Field { get; set; }
        public List<TblFieldDetailsModel> tblField { get; set; }
        public string Jsondata { get; set; }
        public int CategoryId { get; set; }

    }
}
