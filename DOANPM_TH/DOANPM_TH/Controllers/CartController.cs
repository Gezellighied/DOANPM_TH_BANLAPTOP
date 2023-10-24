using Azure;
using DOANPM_TH.Models;
using DOANPM_TH.Models.ClassModel;
using DOANPM_TH.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;


namespace DOANPM_TH.Controllers
{
	public class CartController : Controller
	{
		public ActionResult Index()
		{
			ProductModel db = new ProductModel();
			return View(db.FindAll().ToList());
		}
	}
}