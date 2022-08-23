namespace StorageWebApp.Controllers
{
    using Azure.Storage.Blobs.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using StorageModels;
    using Util;

    public class StorageController : Controller
    {
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

        public ActionResult UploadFile2()
        {
            return View();
        }

        public ActionResult DeleteContainer()
        {
            return View();
        }

        public async Task<ActionResult> BlobsList()
        {
            StorageInformation storageInformation = SessionUtil.GetSession(HttpContext);
            
            Library.StorageService storageService = new Library.StorageService();
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

                SessionUtil.SetSession(storageInfo, HttpContext);               

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
                SessionUtil.SetSession(storageInfo, HttpContext);

                Library.StorageService storageService = new Library.StorageService();
                await storageService.UploadAsync(storageInfo);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost("UploadFilePost2")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UploadFilePost2(StorageInformation storageInfo)
        {
            try
            {
                SessionUtil.SetSession(storageInfo, HttpContext);

                Library.StorageService storageService = new Library.StorageService();
                await storageService.Upload2Async(storageInfo);
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
                SessionUtil.SetSession(storageInfo, HttpContext);

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
