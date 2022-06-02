using FileCustomAttribute.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileExtensionAttribute.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Index(FileModel model)
        {
            if (ModelState.IsValid)
            {
                IFormFile file = model.formFile;
                var result = UploadFile(file);
                if (result == true)
                {
                    ViewBag.Message = "Your File uploaded";
                    return View();
                }
                else
                {
                    ViewBag.Message = "Your File something wrog try again";
                    return View(model);
                }
            }
            return View(model);
        }
        private bool  UploadFile(IFormFile file)
        {

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");
            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = Guid.NewGuid().ToString() + "-" + file.FileName /*+ fileInfo.Extension*/;


            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyToAsync(stream);
                return true;
            }
            return false;
        }
    }
}
