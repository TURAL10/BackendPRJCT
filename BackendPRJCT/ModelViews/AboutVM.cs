using BackendPRJCT.Models;

namespace BackendPRJCT.ModelViews
{
    public class AboutVM
    {
        public About About { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<TeacherSM> TeachersSMs { get; set;}
        public Testominal Testominal { get; set; }
        public List<NoticeBoard> NoticeBoards { get; set; }

    }
}
