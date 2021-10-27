// <copyright file="FizzBuzzController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FizzBuzz.Controllers
{
    using System.Web.Mvc;
    using FizzBuzz.Models;
    using FizzBuzz.Service.Interface;
    using FizzBuzz.Utility.Common;
    using PagedList;

    /// <summary>
    /// FizzBuzzController.
    /// </summary>
    public class FizzBuzzController : Controller
    {
        private readonly IFizzBuzzService fizzBuzzService;

        private readonly int pageSize = Constants.MaxPageSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="FizzBuzzController"/> class.
        /// </summary>
        /// <param name="fizzBuzzService">IFizzBuzzService.</param>
        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
            this.fizzBuzzService = fizzBuzzService;
        }

        /// <summary>
        /// Get the DisplayFizzBuzz.
        /// </summary>
        /// <returns>FizzBuzzModel.</returns>
        [HttpGet]
        public ActionResult DisplayFizzBuzz()
        {
            return this.View(new FizzBuzzModel());
        }

        /// <summary>
        /// Post the DisplayFizzBuzz.
        /// </summary>
        /// <param name="model">FizzBuzzModel.</param>
        /// <param name="page">Page Number.</param>
        /// <returns>Action with FizzBuzzModel.</returns>
        [HttpPost]
        public ActionResult DisplayFizzBuzz(FizzBuzzModel model, int page = 1)
        {
            if (this.ModelState.IsValid)
            {
                model.FizzBuzzListValue = this.PagedList(model.Number.Value, page);
            }

            return this.View(Constants.ActionName, model);
        }

        /// <summary>
        /// Get the DisplayFizzBuzz on Page Navigation.
        /// </summary>
        /// <param name="number">number.</param>
        /// <param name="page">page.</param>
        /// <returns>Action with FizzBuzzModel.</returns>
        [HttpGet]
        public ActionResult LoadBasedOnPageIndex(int number, int page)
        {
            var model = new FizzBuzzModel
            {
                Number = number,
                FizzBuzzListValue = this.PagedList(number, page),
            };
            return this.View(Constants.ActionName, model);
        }

        private IPagedList<string> PagedList(int number, int pageNumber)
        {
            var resultList = this.fizzBuzzService.GetData(number).ToPagedList(pageNumber, this.pageSize);
            return resultList;
        }
    }
}