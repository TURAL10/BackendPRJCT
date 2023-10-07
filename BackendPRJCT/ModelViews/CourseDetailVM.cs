using BackendPRJCT.Models;

namespace BackendPRJCT.ModelViews
{
    public class CourseDetailVM
    {
        public Banner Banner { get; set; }
        public List<Category> Categories { get; set; }
        public List<LatestPost> LatestPosts { get; set; }
        public List<Tag> Tags { get; set; }
        public Course Course { get; set; }
    }
}
