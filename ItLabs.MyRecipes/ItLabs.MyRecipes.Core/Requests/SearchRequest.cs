namespace ItLabs.MyRecipes.Core.Requests
{
    public class SearchRequest
    {
        public SearchRequest()
        {
            PageSize = Constants.DefaultPageSize;
            Page = 1;
        }

        public string Name { get; set; }
        public bool IsDone { get; set; }
        public bool IsFavorite { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
