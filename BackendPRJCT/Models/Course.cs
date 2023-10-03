namespace BackendPRJCT.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string About { get; set; }
        public string Apply { get; set; }
        public string Certification { get; set; }
        public List<Feature> Features { get; set; }
    }
}
