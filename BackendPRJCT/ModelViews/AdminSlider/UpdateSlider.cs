namespace BackendPRJCT.ModelViews.AdminSlider
{
    public class UpdateSlider
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
    }
}
