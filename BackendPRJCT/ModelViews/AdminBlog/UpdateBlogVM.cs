namespace BackendPRJCT.ModelViews.AdminBlog
{
    public class UpdateBlogVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Month { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }
        public int Comment { get; set; }
    }
}
