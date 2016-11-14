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
			var articleModels = pageItems as IList<demoMVC.Models.ArticleModel> ?? pageItems.ToList();
			var pager = new Pagination("Home", articleModels.Count, page);

			var viewModel = new demoMVC.Models.HomeModel();
			{
				viewModel.Items =
					articleModels.Skip((int)((pager.CurrentPage - 1) * pager.PageSize)).Take((int)pager.PageSize);
				viewModel.PaginationInformation = pager;
			}
			return View(viewModel);
		}

		public static IEnumerable<demoMVC.Models.ArticleModel> ArticleItems()
		{
			var dummyItems = new List<demoMVC.Models.ArticleModel>();
			for (int i = 1; i < 17; i++) {
				dummyItems.Add(new demoMVC.Models.ArticleModel() {ArticleId = i, ArticleBody = "This is article" + i, Title = "Title: " + i });
			}
			return dummyItems;
		}
	}
}
