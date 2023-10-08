namespace BackendPRJCT.ModelViews.AdminEvent
{
    public class CreateEventVM
    {
        public IFormFile Image { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
        public string Venue { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public int Day { get; set; }
        public string Month { get; set; }
    }
}
