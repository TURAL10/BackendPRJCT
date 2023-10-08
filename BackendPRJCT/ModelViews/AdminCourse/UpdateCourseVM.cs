using System.ComponentModel.DataAnnotations;

namespace BackendPRJCT.ModelViews.AdminCourse
{
    public class UpdateCourseVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Add Image")]
        public IFormFile Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string About { get; set; }
        public string Apply { get; set; }
        public string Certification { get; set; }
    }
}
