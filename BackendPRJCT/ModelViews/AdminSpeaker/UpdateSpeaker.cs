using BackendPRJCT.Models;

namespace BackendPRJCT.ModelViews.AdminSpeaker
{
    public class UpdateSpeaker
    {
        public int Id { get; set; }
        public IFormFile? Image { get; set; }
        public string Name { get; set; }
        public string Prof { get; set; }
        public List<int> EventId { get; set; }
        public List<Event>? Events { get; set; }
    }
}
