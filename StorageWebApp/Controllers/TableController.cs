using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageModels;

namespace StorageWebApp.Controllers
{
    public class TableController : Controller
    {
        public const string SessionConnectionString = "_connstringtable";
        public const string SessiionTableName = "_tablename";

        public StorageInformation memoryStorageInformation { get; set; }

        // GET: StorageController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StorageController/Create
        public ActionResult CreateTable()
        {
            return View();
        }

        public ActionResult CreateItemTable()
        {
            return View();
        }

        public ActionResult GetItemTable()
        {
            return View();
        }

        public async Task<ActionResult> BlobsList()
        {
            return null;

            
        }

        // POST: StorageController/Create
        [HttpPost("CreateTable")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTable(TableInformation tableInformation)
        {
            try
            {
                Library.TableService tableService = new Library.TableService();
                await tableService.CreateTableAsync(tableInformation);

                HttpContext.Session.SetString(SessionConnectionString, tableInformation.ConnectionString);
                HttpContext.Session.SetString(SessiionTableName, tableInformation.TableName);

                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost("CreateItemTable")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateItemTablePost(TableInformation tableInformation)
        {
            try
            {
                Library.TableService tableService = new Library.TableService();
                await tableService.CreateItemTableAsync(tableInformation);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost("")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteContainer(StorageInformation storageInfo)
        {
            try
            {
                return null;
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
