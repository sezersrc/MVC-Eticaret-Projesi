using Eticaret.Business;
using Eticaret.Entities;
using System.Linq;
using System.Web.Mvc;

namespace Eticaret.WebUI.Controllers
{
    public class PartialPageController : Controller
    {
        private readonly CrudeRepositorycs<TBLCategory> Crud = new CrudeRepositorycs<TBLCategory>();
        

        // GET: PartialPage
        public ActionResult PartialMenu()
        {
            return PartialView("/Views/PartialPage/_PartialHeaderMenu.cshtml", Crud.List().OrderBy(x => x.MenuOrder));
        }


    }
}