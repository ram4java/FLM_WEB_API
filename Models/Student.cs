namespace FLM_WEB_API.Models
{
    public class Student
    {
        public string Name { set; get; }
        public string Course {  set; get; }

        public Student(string name, string course) { 
            Name = name;
            Course = course;
        }
    }
}
