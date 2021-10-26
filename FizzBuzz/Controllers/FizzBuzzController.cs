using FizzBuzz.Models;
using FizzBuzz.Service.Interface;
using FizzBuzz.Utility.Common;
using PagedList;
using System.Web.Mvc;

namespace FizzBuzz.Controllers
{
    public class FizzBuzzController : Controller
    {
        private readonly IFizzBuzzService fizzBuzzService;

        private int pageSize = Constants.MaxPageSize;

        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
            this.fizzBuzzService = fizzBuzzService;
        }

        public ActionResult Index()
        {
            return this.View(new FizzBuzzModel());
        }

        public ActionResult Display(FizzBuzzModel model, int page = 1)
        {
            if (ModelState.IsValid)
            {
                model.FizzBuzzListValue = this.PagedList(model.Number.Value, page);
            }
            return this.View(Constants.ActionName, model);
        }
        public ActionResult LoadBasedOnPageIndex(int number, int page)
        {
            var model = new FizzBuzzModel
            {
                Number = number,
                FizzBuzzListValue = this.PagedList(number, page)
            };
            return this.View(Constants.ActionName, model);
        }

        private IPagedList<string> PagedList(int number, int pageNumber)
        {
            var resultList = this.fizzBuzzService.GetData(number).ToPagedList(pageNumber, pageSize);
            return resultList;
        }
    }
}