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
            string conn = HttpContext.Session.GetString(SessionConnectionString).ToString();
            string container = HttpContext.Session.GetString(SessionContainer).ToString();
            Library.StorageService storageService = new Library.StorageService();
            StorageInformation storageInformation = new StorageInformation()
            {
                ConnectionString = conn,
                ContainerName = container,
            };
            Azure.Pageable<BlobItem> blobList = storageService.ListBlobsAsync(storageInformation).Result;
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
                Library.StorageService storageService = new Library.StorageService();
                await storageService.CreateContainerAsync(storageInfo);
                return RedirectToAction("Index", "Home");

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
                Library.StorageService storageService = new Library.StorageService();
                await storageService.UploadAsync(storageInfo);
                return RedirectToAction("Index", "Home");
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
                Library.StorageService storageService = new Library.StorageService();
                await storageService.DeleteContainerAsync(storageInfo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
