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
            var output = Util.SessionUtil.GetSessionTable(HttpContext);
            return View(output);
        }

        public ActionResult CreateItemTable()
        {
            var output = Util.SessionUtil.GetSessionTable(HttpContext);
            return View(output);
        }

        public ActionResult GetItemTable()
        {
            var output = Util.SessionUtil.GetSessionTable(HttpContext);
            return View(output);
        }

        // POST: StorageController/Create
        [HttpPost("CreateTable")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTablePost(TableInformation tableInformation)
        {
            try
            {
                Util.SessionUtil.SetSessionTable(tableInformation, HttpContext);
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
                Util.SessionUtil.SetSessionTable(tableInformation, HttpContext);
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
