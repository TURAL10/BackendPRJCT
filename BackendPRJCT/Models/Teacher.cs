﻿namespace BackendPRJCT.Models
{
	public class Teacher
	{
		public int Id { get; set; }
		public string Image { get; set; }
		public string Name { get; set; }
		public string Prof { get; set; }
        public string AboutMe { get; set; }
        public string Degree { get; set; }
        public string Experience { get; set; }
        public string Hobby { get; set; }
        public string Faculty { get; set; }
        public string Mail { get; set; }
        public string Number { get; set; }
        public string Skype { get; set; }
        public List<TeacherSkills> TeacherSkills { get; set; }
		public List<TeacherSM> TeacherSMs { get; set; }

    }
}
