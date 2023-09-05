using Campaign.Models;
using Campaign.Repository.Organization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Campaign.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IOrganizationRepo _campaignRepo;

        private readonly IWebHostEnvironment WebHostEnvironment;
        public OrganizationController(IOrganizationRepo campaignRepo, IWebHostEnvironment webHostEnvironment)
        {
            _campaignRepo = campaignRepo;
            WebHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(OrganizationModel model)
        {
            var data = _campaignRepo.ReadOrganization();
            return View(data);
        }
        public IActionResult CreateOrganization()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateOrganization([FromForm]OrganizationModel model)
        {
            if (ModelState.IsValid)
            {
                OrganizationModel organizationModel = new OrganizationModel();
                string filePath = UploadFile(model);
                var data = _campaignRepo.CreateOrganization(model, filePath);
                return RedirectToAction("Index");
            }
            return View(model);
            
        }

        private string UploadFile(OrganizationModel model)
        {
            string fileName = null;
            if (model.VatPanImage != null)
            {
                string filepath = "PanImages\\"; // Update with your image directory
                filepath += Guid.NewGuid().ToString() + "_" + model.VatPanImage.FileName;
                var filePath = Path.Combine(WebHostEnvironment.WebRootPath, filepath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.VatPanImage.CopyToAsync(stream);
                }
                return filePath;
            }
            return null;
        }

        public async Task<IActionResult> UpdateOrganization(int Id)
        {
            var data =  await _campaignRepo.GetOrgByIdAsync(Id);
            return View(data);
        }
        [HttpPost]
        public IActionResult UpdateOrganization(OrganizationModel model)
        {
            var data = _campaignRepo.UpdateOrganization(model);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteOrganization(OrganizationModel model)
        {
            var data = _campaignRepo.DeleteOrganization(model);
            return RedirectToAction("Index");
        }

        public IActionResult OrganizationField()
        {
            List<OrganizationModel> OrganizationModel = _campaignRepo.ReadOrganization();
            ViewBag.OrgId = new SelectList(OrganizationModel, "Id", "OrganizationName");
            OrganizationFieldModel model = new OrganizationFieldModel();
            model.Field = _campaignRepo.GetColumnField();
            return View(model);
        }

        [HttpPost]
        public IActionResult OrganizationField([FromForm]OrganizationFieldModel model)
        {
            var data = _campaignRepo.AddOrganizationField(model);
            return RedirectToAction("Index");
        }
        public IActionResult OrganizationEvent(int Id)
        {
            var data = _campaignRepo.OrganizationEvent(Id);
            return View(data);
        }
        public IActionResult UpdateOrganizationEvent(int Id)
        {
            List<OrganizationModel> OrganizationModel = _campaignRepo.ReadOrganization();
            ViewBag.OrgId = new SelectList(OrganizationModel, "Id", "OrganizationName");
            OrganizationFieldModel model = new OrganizationFieldModel();
            model.Field = _campaignRepo.GetColumnField();
            var data = _campaignRepo.GetOrganizationFieldById(Id);
            model.SelectedField = JsonConvert.DeserializeObject<List<FieldDetailsModel>>(data.JsonField);
            model.OrgFormTypeName = data.OrgFormTypeName;
            model.OrgId = data.OrgId;
            model.Id = data.Id;
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateOrganizationEvent([FromForm] OrganizationFieldModel model)
        {
            var data = _campaignRepo.UpdateOrganizationField(model);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteOrganizationEvent(int Id)
        {
            var data = _campaignRepo.RemoveOrganizationField(Id);
            return RedirectToAction("Index");
        }
    }
}
