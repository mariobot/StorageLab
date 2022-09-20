using Microsoft.AspNetCore.Mvc;
using StorageModels;

namespace StorageWebApp.Controllers
{
    public class TableController : Controller
    {   
        public ActionResult CreateTable()
        {
            var output = Util.SessionUtil.GetSessionTable(HttpContext);
            return View(output);
        }

        public async Task<ActionResult> CreateItemTable()
        {
            var output = Util.SessionUtil.GetSessionTable(HttpContext);
            return View(output);
        }

        public async Task<ActionResult> CreateItemsTable()
        {
            var output = Util.SessionUtil.GetSessionTable(HttpContext);
            return View(output);
        }

        public async Task<ActionResult> GetItemTable()
        {
            var tableInformation = Util.SessionUtil.GetSessionTable(HttpContext);
            Library.TableService tableService = new Library.TableService();
            var result = await tableService.GetItemTableAsync(tableInformation);
            return View(result);
        }

        public async Task<ActionResult> GetItemsTable()
        {
            var tableInformation = Util.SessionUtil.GetSessionTable(HttpContext);
            Library.TableService tableService = new Library.TableService();
            var result = await tableService.GetItemsTableAsync(tableInformation);
            return View(result);
        }

        // POST: StorageController/Create
        [HttpPost("CreateTablePost")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTablePost(TableInformation tableInformation)
        {
            Util.SessionUtil.SetSessionTable(tableInformation, HttpContext);
            Library.TableService tableService = new Library.TableService();
            await tableService.CreateTableAsync(tableInformation);

            return RedirectToAction("Index","Home");
        }

        [HttpPost("CreateItemTablePost")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateItemTablePost(TableInformation tableInformation)
        {   
            Util.SessionUtil.SetSessionTable(tableInformation, HttpContext);
            Library.TableService tableService = new Library.TableService();
            await tableService.CreateItemTableAsync(tableInformation);

            return RedirectToAction("Index", "Home");            
        }

        [HttpPost("CreateItemsTablePost")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateItemsTablePost(TableInformation tableInformation)
        {
            Util.SessionUtil.SetSessionTable(tableInformation, HttpContext);
            Library.TableService tableService = new Library.TableService();
            await tableService.CreateItemsTableAsync(tableInformation);

            return RedirectToAction("Index", "Home");
        }
    }
}
