using BackendPRJCT.Models;

namespace BackendPRJCT.ModelViews
{
	public class HomeVM
	{
		public List<Slider> Sliders { get; set; }
		public List<RightBoard> RightBoards { get; set; }
		public Testominal Testominal { get; set; }
		public List<NoticeBoard> NoticeBoards { get; set; }
		public Choose Choose { get; set; }
		public List<Course> Courses { get; set; }
		public List<Event> Events { get; set; }
		public List<Blog> Blogs { get; set; }
	}
}
