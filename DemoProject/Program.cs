using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem
{
    public class Student
    {
        public int id
        {
            set;
            get;
        }
        public string name
        {
            set;
            get;
        }
        public string geneder
        {
            set;
            get;
        }
        public int[] degree
        {
            set;
            get;
        }

    }
    public class Program
    {
        List<Student> student = new List<Student>
        { new Student { id = 1, name = "Ahmed", geneder = "male", degree=new int []{ 94,83,72,56,98 } },
            new Student { id = 4, name = "Aml", geneder = "Female", degree=new int [] { 60,89,65,74,55} },
            new Student {id = 3, name = "Donia", geneder = "Female",degree=new int[] {80,95,93,97,98} },
            new Student {id = 2, name = "Mohamed", geneder = "male" ,degree=new int[] { 80,84,87,90,68} },
             new Student {id = 5, name = "Ali", geneder = "male" ,degree=new int[] { 49,55,30,50,48} }
        };

        public List<Student> AllStudents()
        {
            return student;
        }

        public List<Student> getDetails(int id)
        {
            List<Student> std = new List<Student>();
            foreach (var item in student)
            {
                if (item.id == id)
                {
                    std.Add(item);
                }
            }
            return std;
        }
        public string AddUser(string id, string name, string gender, int[] degree)
        {

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
            {
                return "Student ID or Name couldn't be empty";
            }
            else
            {
                student.Add(new Student { id = int.Parse(id), name = name, geneder = gender, degree = degree });
                return "Success";
            }

        }
        public string DeleteUser(int id, string name)
        {
            foreach (var item in student)
            {
                if (item.id == id && item.name == name)
                {
                    student.Remove(item);
                    return "Success";
                }
            }
            return "Fail";
        }
        public int totalresult(int[] degrees)
        {
            int degree = 0;
            for (int i = 0; i < degrees.Length; i++)
            {
                degree += degrees[i];
            }
            return degree;


        }
        public string grade(int[] degrees)
        {
            double result = totalresult(degrees);
            double percentage = (result / 500) * 100;
            if (percentage >= 85)
            {
                return "Excellent";
            }
            else if (percentage < 85 && percentage >= 75)
            {
                return "Very Good";
            }
            else if (percentage < 75 && percentage >= 50)
            {
                return "Good";
            }
            else
            {
                return "Fail";
            }
        }
        static void Main(string[] args)
        {
        }
    }
}

