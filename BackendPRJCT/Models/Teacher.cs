namespace BackendPRJCT.Models
{
	public class Teacher
	{
		public int Id { get; set; }
		public string Image { get; set; }
		public string Name { get; set; }
		public string Prof { get; set; }
		public bool IsMain { get; set; }
		public TeacherDetail TeacherDetail { get; set; }
		public List<TeacherSkills> TeacherSkills { get; set; }
		public List<TeacherSM> TeacherSMs { get; set; }

    }
}
