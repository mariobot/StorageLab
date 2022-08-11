using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageModels;

namespace StorageWebApp.Controllers
{
    public class StorageController : Controller
    {
        // GET: StorageController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StorageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StorageController/Create
        public ActionResult CreateContainer()
        {
            return View();
        }

        public ActionResult UploadFile()
        {
            return View();
        }

        // POST: StorageController/Create
        [HttpPost("CreateContainerPost")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateContainerPost(StorageInformation storageInfo)
        {
            try
            {
                StorageLibrary.StorageService storageService = new StorageLibrary.StorageService();
                await storageService.CreateContainerAsync(storageInfo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost("UploadFilePost")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UploadFilePost(StorageInformation storageInfo)
        {
            try
            {
                StorageLibrary.StorageService storageService = new StorageLibrary.StorageService();
                await storageService.UploadAsync(storageInfo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StorageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StorageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StorageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StorageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
