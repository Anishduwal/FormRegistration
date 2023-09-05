namespace Campaign.Models
{
    public class TblFieldDetailsModel
    {
        public int Id { get; set; }
        public string? FieldName { get; set; }
        public string? DataType { get; set; }
        public int CategoryId { get; set; }
        public int OrderId { get; set; }

    }
}
