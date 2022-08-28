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

        // POST: StorageController/Create
        [HttpPost("CreateTable")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTablePost(TableInformation tableInformation)
        {
            try
            {
                Library.TableService tableService = new Library.TableService();
                await tableService.CreateTableAsync(tableInformation);



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
    }
}
