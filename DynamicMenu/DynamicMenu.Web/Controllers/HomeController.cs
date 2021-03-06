﻿// -----------------------------------------------------------------------
//  <copyright file="HomeController.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.Web.Controllers
{
    using System.Linq;
    using Infrastructure;
    using Infrastructure.Helpers;
    using Infrastructure.Repositories;
    using Infrastructure.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    /// <summary> Represents a controller for main home. </summary>
    public class HomeController : Controller
    {
        /// <summary> Initializes a new instance of the <see cref="HomeController" /> class. </summary>
        /// <param name="dataContext"> The data context. </param>
        public HomeController(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        /// <summary> Gets the data context. </summary>
        /// <value> The <see cref="DataContext" />. </value>
        public DataContext DataContext { get; }

        /// <summary> Defines the index action. </summary>
        /// <returns> An <see cref="IActionResult" />. </returns>
        public IActionResult Index()
        {
            ViewData["Title"] = "Domovska stranka";
            return View();
        }

        /// <summary> Defines the menu action. </summary>
        /// <returns> An <see cref="IActionResult" />. </returns>
        public IActionResult Menu()
        {
            var rep = new MenuRepository(DataContext);
            var menus = rep.GetAll().ToList();
            var categories = CategoryHelper.GetCategories(menus);
            var viewModel = new MenusViewModel {Categories = categories};
            return PartialView("_CategoryMenu", viewModel);
        }

        /// <summary> Defines the about action. </summary>
        /// <returns> An <see cref="IActionResult" />. </returns>
        public IActionResult About()
        {
            ViewData["Title"] = "O nas";
            return View();
        }

        /// <summary> Defines the contact action. </summary>
        /// <returns> An <see cref="IActionResult" />. </returns>
        public IActionResult Contact()
        {
            ViewData["Title"] = "Kontakt";
            return View();
        }

        /// <summary> Defines the error action. </summary>
        /// <returns> An <see cref="IActionResult" />. </returns>
        public IActionResult Error() => View();
    }
}