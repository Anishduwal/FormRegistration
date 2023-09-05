using System.ComponentModel.DataAnnotations;

namespace Campaign.Models
{
    public class FieldDetailsModel
    {
        public int Id { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Special Characters are not allowed.")]
        public string? FieldName { get; set; }
        public string? DataType { get; set; }
        public bool status { get; set; }

    }
}
