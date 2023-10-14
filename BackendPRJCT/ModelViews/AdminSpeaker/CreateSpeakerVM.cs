namespace BackendPRJCT.ModelViews.AdminSpeaker
{
    public class CreateSpeakerVM
    {
        public IFormFile Image { get; set; }
        public string Name { get; set; }
        public string Prof { get; set; }
        public List<int> EventId { get; set; }
    }
}
