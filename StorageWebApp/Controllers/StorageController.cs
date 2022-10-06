namespace StorageWebApp.Controllers
{
    using Azure.Storage.Blobs.Models;
    using Microsoft.AspNetCore.Mvc;
    using StorageModels;
    using Util;
    public class StorageController : Controller
    {
        public ActionResult CreateContainer()
        {
            StorageInformation storageInformation = SessionUtil.GetSession(HttpContext);
            return View(storageInformation);
        }

        public async Task<ActionResult> Containers()
        {
            StorageInformation storageInformation = SessionUtil.GetSession(HttpContext);
            Library.StorageService storageService = new Library.StorageService();
            Azure.AsyncPageable<BlobContainerItem> containersList = await storageService.ContainersAsync(storageInformation);
            return View(containersList);
        }

        public ActionResult UploadFile()
        {
            StorageInformation storageInformation = SessionUtil.GetSession(HttpContext);
            return View(storageInformation);
        }

        public ActionResult UploadFile2()
        {
            StorageInformation storageInformation = SessionUtil.GetSession(HttpContext);
            return View(storageInformation);
        }

        public async Task<ActionResult> BlobsList(string containername)
        {
            StorageInformation storageInformation = SessionUtil.GetSession(HttpContext);
            
            if (!string.IsNullOrEmpty(containername))
            {
                storageInformation.ContainerName = containername;
            }
            
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
            SessionUtil.SetSessionStorage(storageInfo, HttpContext);
            Library.StorageService storageService = new Library.StorageService();
            await storageService.CreateContainerAsync(storageInfo);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost("UploadFilePost")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UploadFilePost(StorageInformation storageInfo)
        {
            SessionUtil.SetSessionStorage(storageInfo, HttpContext);

            Library.StorageService storageService = new Library.StorageService();
            await storageService.UploadAsync(storageInfo);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost("UploadFilePost2")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UploadFilePost2(StorageInformation storageInfo)
        {
            SessionUtil.SetSessionStorage(storageInfo, HttpContext);

            Library.StorageService storageService = new Library.StorageService();
            await storageService.Upload2Async(storageInfo);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost("DeleteContainer")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteContainer(string containername)
        {
            StorageInformation storageInformation = SessionUtil.GetSession(HttpContext);
            Library.StorageService storageService = new Library.StorageService();
            await storageService.DeleteContainerAsync(storageInformation, containername);
            return RedirectToAction("Containers", "Storage");
        }

        [HttpPost("DeleteFile")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteFile(string filename)
        {
            StorageInformation storageInformation = SessionUtil.GetSession(HttpContext);
            Library.StorageService storageService = new Library.StorageService();
            await storageService.DeleteFileAsync(storageInformation, filename);
            return RedirectToAction("BlobsList", "Storage");
        }

        [HttpPost("DownloadFile")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DownloadFile(string filename)
        {
            StorageInformation storageInformation = SessionUtil.GetSession(HttpContext);
            Library.StorageService storageService = new Library.StorageService();
            Stream file = await storageService.DownloadFileAsync(storageInformation, filename);
            return File(file,"application/text");
        }
    }
}
