using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _360Courier.Extensions;

namespace ConsoleApplication
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Student : Person {
        public char Grade { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var list = new List<Student>();
            for (int i = 0; i < 2; i++)
            {
                var p = new Student();
                p.Age = 10 + i;
                p.Name = "7omos"+i;
                p.Grade = (char)((int)'a'+(i%6));
                list.Add(p);
            }
            
            Console.WriteLine(list.ToJson(true));*/
            /*
            var student = p as Student;
            if (student != null)
            {
                student.Grade = 'f';
            }
             */

            string s = @"[
  {
    ""Grade"": ""a"",
    ""Name"": ""7omos0"",
    ""Age"": 10
  },
  {
    ""Grade"": ""b"",
    ""Name"": ""7omos1"",
    ""Age"": 11
  }
]";
            var l = s.FromJson<List<Student>>();
            Console.WriteLine(l);
        }
    }
}
