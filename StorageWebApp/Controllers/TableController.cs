using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageModels;

namespace StorageWebApp.Controllers
{
    public class StorageController : Controller
    {
        public const string SessionConnectionString = "_connstring";
        public const string SessionContainer = "_container";

        public StorageInformation memoryStorageInformation { get; set; }

        // GET: StorageController
        public ActionResult Index()
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

        public ActionResult DeleteContainer()
        {
            return View();
        }

        public async Task<ActionResult> BlobsList()
        {
            

            string conn = HttpContext.Session.GetString(SessionContainer).ToString();
            string container = HttpContext.Session.GetString(SessionContainer).ToString();
            StorageLibrary.StorageService storageService = new StorageLibrary.StorageService();
            StorageInformation storageInformation = new StorageInformation()
            {
                ConnectionString = conn,
                ContainerName = container,
            };
            Azure.Pageable<BlobItem> blobList = await storageService.ListBlobsAsync(storageInformation);
            var result = blobList;
            return View(blobList);
        }

        // POST: StorageController/Create
        [HttpPost("CreateContainerPost")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateContainerPost(StorageInformation storageInfo)
        {
            try
            {
                HttpContext.Session.SetString(SessionConnectionString, storageInfo.ConnectionString);
                HttpContext.Session.SetString(SessionContainer, storageInfo.ContainerName);

                memoryStorageInformation = storageInfo;
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
                memoryStorageInformation = storageInfo;
                StorageLibrary.StorageService storageService = new StorageLibrary.StorageService();
                await storageService.UploadAsync(storageInfo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost("DeleteContainer")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteContainer(StorageInformation storageInfo)
        {
            try
            {
                memoryStorageInformation = storageInfo;
                StorageLibrary.StorageService storageService = new StorageLibrary.StorageService();
                await storageService.DeleteContainerAsync(storageInfo);
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
