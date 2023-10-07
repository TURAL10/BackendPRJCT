using BackendPRJCT.Models;

namespace BackendPRJCT.ModelViews
{
    public class BlogDetailVM
    {
        public Banner Banner { get; set; }
        public List<Category> Categories { get; set; }
        public List<LatestPost> LatestPosts { get; set; }
        public List<Tag> Tags { get; set; } 
        public Blog Blog { get; set; }
    }
}
