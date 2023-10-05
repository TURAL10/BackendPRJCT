﻿using System.ComponentModel.DataAnnotations;

namespace BackendPRJCT.ModelViews.AdminCourse
{
    public class CreateCourseVM
    {
        [Required(ErrorMessage ="Add Image")]
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string About { get; set; }
        public string Apply { get; set; }
        public string Certification { get; set; }
    }
}
