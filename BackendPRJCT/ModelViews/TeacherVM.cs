using BackendPRJCT.Models;

namespace BackendPRJCT.ModelViews
{
    public class TeacherVM
    {

        public List<Teacher> Teachers { get; set; }
        public List<TeacherSkills> TeachersSkills { get; set; }
        public List<TeacherSM> TeacherSMs { get; set; }
    }
}
