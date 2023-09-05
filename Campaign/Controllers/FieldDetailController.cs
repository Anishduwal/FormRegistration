using Campaign.Enums;
using Campaign.Models;
using Campaign.Repository.FieldDetail;
using Campaign.Repository.Organization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Campaign.Controllers
{
    public class FieldDetailController : Controller
    {
        private readonly IFieldDetailRepo _fieldRepo;

        public FieldDetailController(IFieldDetailRepo fieldDetailRepo)
        {
            _fieldRepo = fieldDetailRepo;
        }
        public IActionResult Index()
        {
            List<string> itemList = new List<string>
        {
            "INT",
            "VARCHAR(50)",
            "VARCHAR(100)",
            "VARCHAR(255)",
            "VARCHAR(MAX)",
            "NVARCHAR(50)",
            "NVARCHAR(100)",
            "NVARCHAR(255)",
            "NVARCHAR(MAX)",
            "Decimal(18,2)",
            "DateTime",
            "BIT"
        };
            //ViewBag.DataType = Enum.GetValues(typeof(DataType)).Cast<DataType>().ToList();
            ViewBag.DataType = itemList;
            return View();
        }
        [HttpPost]
        public IActionResult AddField(FieldViewModel model)
        {
            List<FieldDetailsModel>? models = JsonConvert.DeserializeObject<List<FieldDetailsModel>>(model.Jsondata);
            foreach (var field in models)
            {
                var data = _fieldRepo.AddFields(field);
            }
            return RedirectToAction("Index", "Organization");
        }
        public IActionResult InsertField()
        {
            List<FieldTypeModel> FieldType = _fieldRepo.GetFieldDataTypes();
            ViewBag.FieldType = new SelectList(FieldType, "Id", "FieldType");
            List<CategoryModel> Category = _fieldRepo.GetCategory();
            ViewBag.Category = new SelectList(Category, "Id", "CategoryName");
            return View();
        }
        [HttpPost]
        public IActionResult InsertField(FieldViewModel model)
        {
            List<TblFieldDetailsModel>? models = JsonConvert.DeserializeObject<List<TblFieldDetailsModel>>(model.Jsondata);
            foreach (var field in models)
            {
                var data = _fieldRepo.InsertFields(field);
            }
            return View();
        }

        
        
    }
}
