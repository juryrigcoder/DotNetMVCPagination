
namespace demoMVC.Models
{
	public class ArticleModel
	{
	   // Access is limited to the containing class or types derived from the containing class.
	    public int ArticleId { get; private set; }// Unique identifier
	    public string Title { get; private set; }// Article title
	    public string ArticleBody { get; private set; }// The article
	    // Constructor setting private properties on instantiation
	    public ArticleModel(int _articleID, string _title, string _articleBody)
	    {
	        ArticleId = _articleID;
	        Title = _title;
	        ArticleBody = _articleBody;
	    }
	}
}
