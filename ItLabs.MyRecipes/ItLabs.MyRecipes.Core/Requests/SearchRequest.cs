namespace ItLabs.MyRecipes.Core.Requests
{
    public class SearchRequest
    {
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public bool IsFavorite { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }

    }
}
