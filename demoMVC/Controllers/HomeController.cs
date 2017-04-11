using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace demoMVC.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index(int? page)
		{
			var pageItems = ArticleItems();
			var articleModels = pageItems as IList<Models.ArticleModel> ?? pageItems.ToList();
			var pager = new Pagination("Home", articleModels.Count, page);
		    var items = articleModels.Skip((int)((pager.CurrentPage - 1) * pager.PageSize)).Take((int)pager.PageSize);
			var viewModel = new Models.HomeModel(items, pager);
			return View(viewModel);
		}

		public static IEnumerable<Models.ArticleModel> ArticleItems()
		{
			var dummyItems = new List<Models.ArticleModel>();
			for (var i = 1; i < 17; i++) {
				dummyItems.Add(new Models.ArticleModel(i, "Title: " + i, "This is article" + i));
			}
			return dummyItems;
		}
	}
}
