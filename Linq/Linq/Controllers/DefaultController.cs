using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Linq.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LinqSelect()
        {
            List<Student1> stuList = new List<Student1>()
            {
                new Student1(){ ID=100,Name="amir",Age=23,Average=16.25},
                new Student1(){ ID=101,Name="reza",Age=22,Average=12.3},
                new Student1(){ ID=102,Name="sara",Age=22,Average=12},
                new Student1(){ ID=103,Name="hassan",Age=24,Average=18},
                new Student1(){ ID=104,Name="mina",Age=21,Average=17.11},
            };
            //1 Linq method SelectMany
            var StudentList = stuList.Select(x => x);
            //2 Linq query
            //var StudentList = from stu in stuList
            //                  select stu;
            return View(StudentList);
        }
        public IActionResult LinqSelectMany()
        {
            List<Student2> Objstudent = new List<Student2>()
            {
                new Student2() { Name = "Ravi Varma", Gender = "Male", Subjects = new List<string> { "Mathematics", "Physics" } },
                new Student2() { Name = "Vikram Sharma", Gender = "Male", Subjects = new List<string> { "Social Studies", "Chemistry" } },
                new Student2() { Name = "Harish Dutt", Gender = "Male", Subjects = new List<string> { "Biology", "History", "Geography" } },
                new Student2() { Name = "Akansha Wadhwani", Gender = "Female", Subjects = new List<string> { "English", "Zoology", "Botany" } },
                new Student2() { Name = "Vikrant Seth", Gender = "Male", Subjects = new List<string> { "Civics", "Drawing" } }
            };

            //1 Linq method SelectMany
            var Subjects = Objstudent.SelectMany(x => x.Subjects);

            //2 Linq query
            //IEnumerable<string> Subjects = from student in Objstudent
            //                               from st2 in student.Subjects
            //                               select st2;

            //3 Linq method Select
            //IEnumerable<List<string>> Subjects = Objstudent.Select(x => x.Subjects);

            return View(Subjects);
        }
        public IActionResult LinqSelectMany2()
        {
            string[] stringArray =
            {
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "0123456789"
            };
            //1 Linq method SelectMany
            var result = stringArray.SelectMany(s => s);
            //2 Linq method Select
            //var result = stringArray.Select(s => s);
            //3 Linq query
            //var result = from str in stringArray
            //             from ch in str
            //             select ch;

            return View(result);
        }
        public IActionResult LinqOrderby1()
        {
            String[] ArrayCountries = { "Iran", "Uk", "Usa", "China", "Germany", "Japan", "Albania" };

            //1 Linq Method
            var Countries = ArrayCountries.OrderBy(x => x);

            //2 Linq Query
            //var Countries = from co in ArrayCountries
            //                orderby co
            //                select co;

            return View(Countries);
        }
        public IActionResult LinqOrderby2()
        {
            List<Student2> Objstudent = new List<Student2>()
            {
                new Student2() { Name = "Suresh Dasari", Gender = "Male", Subjects = new List<string> { "Mathematics", "Physics" } },
                new Student2() { Name = "Rohini Alavala", Gender = "Female", Subjects = new List<string> { "Entomology", "Botany" } },
                new Student2() { Name = "Praveen Kumar", Gender = "Male", Subjects = new List<string> { "Computers", "Operating System", "Java" } },
                new Student2() { Name = "Sateesh Chandra", Gender = "Male", Subjects = new List<string> { "English", "Social Studies", "Chemistry" } },
                new Student2() { Name = "Madhav Sai", Gender = "Male", Subjects = new List<string> { "Accounting", "Charted" } }
            };

            //1 Linq Method
            var studentname = Objstudent.OrderBy(x => x.Name);

            //2 Linq Query
            //var studentname = from x in Objstudent
            //                  orderby x.Name
            //                  select x;

            return View(studentname);
        }
        public IActionResult OrderByDescending()
        {
            String[] ArrayCountries = { "Iran", "Uk", "Usa", "China", "Germany", "Japan", "Albania" };

            //1 Linq Method
            var Countries = ArrayCountries.OrderByDescending(x => x);

            //2 Linq Query
            //var Countries = from x in ArrayCountries
            //                orderby x descending
            //                select x;

            return View(Countries);
        }
        public IActionResult OrderByDescending1()
        {
            //1 Linq Method
            var studentname = Student2.GetList().OrderByDescending(x => x.Name);

            //2 Linq Query
            //var studentname = from stu in Student2.GetList()
            //                  orderby stu.Name descending
            //                  select stu;

            return View(studentname);
        }
        public IActionResult ThenBy1()
        {
            List<Student1> students = new List<Student1>();
            students.Add(new Student1 { ID = 1, Name = "ADAM ", Average = 1.5, Age = 39 });
            students.Add(new Student1 { ID = 2, Name = "JACKSON ", Average = 1.4, Age = 32 });
            students.Add(new Student1 { ID = 3, Name = "ELIZA ", Average = 3, Age = 45 });
            students.Add(new Student1 { ID = 4, Name = "ZOE ", Average = 2.1, Age = 39 });

            //1 Linq Method
            var studentsOrderByRank = students.OrderBy(x => x.Average).ThenBy(x => x.Age);

            //2 Linq Query
            //var studentsOrderByRank = from student in students
            //                          orderby student.Average, student.Age
            //                          select student;

            return View(studentsOrderByRank);
        }
        public IActionResult ThenByDescending1()
        {
            List<Student1> students = new List<Student1>();
            students.Add(new Student1 { ID = 1, Name = "ADAM ", Average = 1.5, Age = 39 });
            students.Add(new Student1 { ID = 2, Name = "JACKSON ", Average = 1.4, Age = 32 });
            students.Add(new Student1 { ID = 3, Name = "ELIZA ", Average = 3, Age = 45 });
            students.Add(new Student1 { ID = 4, Name = "ZOE ", Average = 2.1, Age = 39 });

            //1 Linq Method
            var studentsOrderByRank = students.OrderByDescending(x => x.Average).ThenByDescending(x => x.Age);

            //2 Linq Query
            //var studentsOrderByRank = from stu in students
            //                          orderby stu.Average descending, stu.Age descending
            //                          select stu;

            return View(studentsOrderByRank);
        }
        public IActionResult LinqReverse()
        {
            int[] number = { 10, 30, 45, 100, 700, 12, 50 };
            //1 Linq Method
            IEnumerable<int> num = number.Select(x => x);
            IEnumerable<int> numReverse = number.Reverse<int>();

            //2 Linq Query
            //IEnumerable<int> num = number.Select(x => x);
            //IEnumerable<int> numReverse = number.Reverse<int>();

            //return View(num);
            return View(numReverse);
        }
        public IActionResult LinqWhere1()
        {
            string[] countries = { "India", "Iran", "USA", "Argentina", "Peru", "China" };
            //1 Linq Method
            IEnumerable<string> result = countries.Where(s => s.StartsWith("I"));

            //2 Linq Query
            //IEnumerable<string> result = from x in countries
            //                             where x.StartsWith("I")
            //                             select x;

            return View(result);
        }
        public IActionResult LinqWhere2()
        {
            List<Student1> stuList = new List<Student1>()
            {
                new Student1(){ ID=100,Name="amir",Age=23,Average=16.25},
                new Student1(){ ID=101,Name="reza",Age=22,Average=12.3},
                new Student1(){ ID=102,Name="sara",Age=22,Average=12},
                new Student1(){ ID=103,Name="hassan",Age=24,Average=18},
                new Student1(){ ID=104,Name="mina",Age=21,Average=17.11},
            };

            //1 Linq Method
            var StudentList = stuList.Where(x => x.Average > 15);

            //2 Linq Query
            //var StudentList = from stu in stuList
            //                  where stu.Average > 15
            //                  select stu;

            return View(StudentList);
        }
        public IActionResult LinqWhere3()
        {
            string[] countries = { "India", "Iran", "USA", "Argentina", "Peru", "China" };

            //1 Linq Method
            IEnumerable<string> result = countries.Where(s => s.StartsWith("I") & s.EndsWith("n"));

            //2 Linq Query
            //IEnumerable<string> result = from x in countries
            //                             where x.StartsWith("I")
            //                             where x.EndsWith("n")
            //                             select x;

            return View(result);
        }
        public IActionResult LinqOfType1()
        {
            ArrayList obj = new ArrayList();
            obj.Add("Iran");
            obj.Add("USA");
            obj.Add(1);
            obj.Add(true);
            obj.Add(55.6);
            obj.Add("UK");
            obj.Add("India");

            //1 Linq Method
            IEnumerable<string> result = obj.OfType<string>();

            //2 Linq Query
            //IEnumerable result = from x in obj.OfType<int>()
            //                     select x;

            return View(result);
        }
        public IActionResult LinqOfType2()
        {
            ArrayList persons = new ArrayList()
            {
                new Student1(){ ID=100,Name="amir",Age=23,Average=16.25},
                new Student1(){ ID=101,Name="reza",Age=22,Average=12.3},
                new Student1(){ ID=102,Name="sara",Age=22,Average=12},
                new Student1(){ ID=103,Name="hassan",Age=24,Average=18},
                new Student1(){ ID=104,Name="mina",Age=21,Average=17.11},
                new Employee1(){ ID=2000,Name="nader" ,Gender="Male",HoursWorked=150},
                new Employee1(){ ID=2000,Name="javad" ,Gender="Male",HoursWorked=177},
                new Employee1(){ ID=2000,Name="neda" ,Gender="Female",HoursWorked=110},
                new Employee1(){ ID=2000,Name="arash" ,Gender="Male",HoursWorked=300},
                new Employee1(){ ID=2000,Name="zahra" ,Gender="Female",HoursWorked=160},
                new Employee1(){ ID=2000,Name="amin" ,Gender="Male",HoursWorked=100}
            };

            //1 Linq Method
            IEnumerable<Employee1> personsList = persons.OfType<Employee1>().Where(x => x.HoursWorked > 140 & x.Gender.Equals("Female"));

            //2 Linq Query
            //IEnumerable<Employee> personsList = from person in persons.OfType<Employee>()
            //                                    where person.HoursWorked > 140
            //                                    where person.Gender.Equals("Female")
            //                                    select person;

            return View(personsList);
        }
        public IActionResult LinqUnion()
        {
            string[] count1 = { "UK", "Australia", "India", "USA" };
            string[] count2 = { "India", "Iran", "UK", "China" };

            //1 Linq Method
            var result = count1.Union(count2).OrderBy(x => x);

            //2 Linq Query
            //var result = from x in count1.Union(count2)
            //             orderby x
            //             select x;

            return View(result);
        }
        public IActionResult LinqConcat()
        {
            string[] count1 = { "UK", "Australia", "India", "USA" };
            string[] count2 = { "India", "Iran", "UK", "China" };

            //1 Linq Method
            var result = count1.Concat(count2).OrderBy(x => x);

            //2 Linq Query
            //var result = from x in count1.Concat(count2)
            //             orderby x
            //             select x;

            return View(result);
        }
        public IActionResult LinqIntersect()
        {
            string[] count1 = { "UK", "Iran", "India", "USA" };
            string[] count2 = { "India", "Canada", "Brazil", "Iran" };

            //1 Linq Method
            var result = count1.Intersect(count2);

            //2 Linq Query
            //var result = from x in count1.Intersect(count2)
            //             select x;

            return View(result);
        }
        public IActionResult LinqDistinct()
        {
            string[] countries = { "UK", "UK", "Iran", "INDIA", "india", "USA", "USA", "iran" };

            //1 Linq Method
            var result = countries.Distinct();

            //2 Linq Query
            //var result = (from x in countries
            //              select x).Distinct();

            return View(result);
        }
        public IActionResult LinqExcept()
        {
            string[] arr1 = { "Olivia", "Jack", "Oscar", "Emily" };
            string[] arr2 = { "Olivia", "Freddie", "Jack", "Oscar" };

            //1 Linq Method
            var result = arr1.Except(arr2);

            //2 Linq Query
            //var result = from x in arr1.Except(arr2)
            //             select x;

            return View(result);
        }
        public IActionResult LinqInnerJoin()
        {
            List<Department1> objDept = new List<Department1>(){
                new Department1{DepId=1,DepName="Software"},
                new Department1{DepId=2,DepName="Finance"},
                new Department1{DepId=3,DepName="Health"}
            };
            List<Employee2> objEmp = new List<Employee2>()
            {
                new Employee2 { EmpId=1,Name = "Suresh Dasari", DeptId=1 },
                new Employee2 { EmpId=2,Name = "Rohini Alavala", DeptId=1 },
                new Employee2 { EmpId=3,Name = "Praveen Alavala", DeptId=2 },
                new Employee2 { EmpId=4,Name = "Sateesh Alavala", DeptId =2},
                new Employee2 { EmpId=5,Name = "Madhav Sai"}
};
            //1 Linq Method
            var result = objDept.Join(
                            objEmp, d => d.DepId, e => e.DeptId, (dep, emp) => new Departmant1Employee2
                            {
                                EmpName = emp.Name,
                                DepName = dep.DepName
                            });


            //2 Linq Query
            //var result = from d in objDept
            //             join e in objEmp
            //             on d.DepId equals e.DeptId
            //             select new Departmant1Employee2
            //             {
            //                 EmpName = e.Name,
            //                 DepName = d.DepName
            //             };

            return View(result);
        }
        public IActionResult LinqLeftOuterJoin()
        {
            List<Department1> objDept = new List<Department1>()
            {
                new Department1{DepId=1,DepName="Software"},
                new Department1{DepId=2,DepName="Finance"},
                new Department1{DepId=3,DepName="Health"}
            };
            List<Employee2> objEmp = new List<Employee2>()
            {
                new Employee2 { EmpId=1,Name = "Suresh Dasari", DeptId=1 },
                new Employee2 { EmpId=2,Name = "Rohini Alavala", DeptId=1 },
                new Employee2 { EmpId=3,Name = "Praveen Alavala", DeptId=2 },
                new Employee2 { EmpId=4,Name = "Sateesh Alavala", DeptId =2},
                new Employee2 { EmpId=5,Name = "Madhav Sai"}
            };


            //1 Linq Method



            //2 Linq Query
            var result = from e in objEmp
                         join d in objDept
                         on e.DeptId equals d.DepId into empDept
                         from ed in empDept.DefaultIfEmpty()
                         select new Departmant1Employee2
                         {
                             EmpName = e.Name,
                             DepName = ed == null ? "No Department" : ed.DepName
                         };

            return View(result);
        }
        public IActionResult LinqCrossJoin()
        {
            List<Department1> objDept = new List<Department1>(){
            new Department1{DepId=1,DepName="Software"},
            new Department1{DepId=2,DepName="Finance"},
            new Department1{DepId=3,DepName="Health"}
            };
            List<Employee2> objEmp = new List<Employee2>()
            {
            new Employee2 { EmpId=1,Name = "Suresh Dasari", DeptId=1 },
            new Employee2 { EmpId=2,Name = "Rohini Alavala", DeptId=1 },
            new Employee2 { EmpId=3,Name = "Praveen Kumar", DeptId=2 },
            new Employee2 { EmpId=4,Name = "Sateesh Chandra", DeptId =2},
            new Employee2 { EmpId=5,Name = "Madhav Sai"}
            };


            //1 Linq Method



            //2 Linq Query
            var result = from e in objEmp
                         from d in objDept
                         select new Departmant1Employee2
                         {
                             EmpName = e.Name,
                             DepName = d.DepName
                         };

            return View(result);
        }
        public IActionResult LinqGroupJoin()
        {
            List<Department1> objDept = new List<Department1>(){
            new Department1{DepId=1,DepName="Software"},
            new Department1{DepId=2,DepName="Finance"},
            new Department1{DepId=3,DepName="Health"}
            };
            List<Employee2> objEmp = new List<Employee2>()
            {
            new Employee2 { EmpId=1,Name = "Suresh Dasari", DeptId=1 },
            new Employee2 { EmpId=2,Name = "Rohini Alavala", DeptId=1 },
            new Employee2 { EmpId=3,Name = "Praveen Kumar", DeptId=2 },
            new Employee2 { EmpId=4,Name = "Sateesh Chandra", DeptId =2},
            new Employee2 { EmpId=5,Name = "Madhav Sai"}
            };



            //1 Linq Method



            //2 Linq Query
            var result = from d in objDept
                         join e in objEmp on d.DepId equals e.DeptId into empDept
                         select new Departmant1Employee2_new
                         {
                             DepName = d.DepName,
                             EmpNames = from emp2 in empDept
                                        orderby emp2.Name
                                        select emp2
                         };

            return View(result);
        }
        public IActionResult LinqTake()
        {
            string[] countries = { "India", "Iran", "Russia", "China", "USA", "Argentina" };



            //1 Linq Method
            var result = countries.Take(3);



            //2 Linq Query
            //var result = (from x in countries
            //              select x).Take(3);
            //or
            //var result = from x in countries.Take(3)
            //             select x;

            return View(result);
        }
        public IActionResult LinqTakeWhile()
        {
            string[] countries = { "India", "Russia", "Iran", "China", "USA", "Argentina" };


            //1 Linq Method
            var result = countries.TakeWhile(x => x.StartsWith("I"));



            //2 Linq Query
            //var result = (from x in countries
            //              select x).TakeWhile(x => x.StartsWith("I"));

            return View(result);
        }
        public IActionResult LinqSkip()
        {
            string[] countries = { "India", "Iran", "Russia", "China", "USA", "Argentina" };

            //1 Linq Method
            var result = countries.Skip(3);



            //2 Linq Query
            //var result = (from x in countries
            //              select x).Skip(3);

            return View(result);
        }
        public IActionResult LinqSkipWhile()
        {
            int[] num = { 2, 4, 6, 7, 8, 10, 12 };

            //1 Linq Method
            var result = num.SkipWhile(x => x % 2 == 0);



            //2 Linq Query
            //var result = (from x in num
            //              select x).SkipWhile(x => x % 2 == 0);

            return View(result);
        }
        public IActionResult LinqToList()
        {
            string[] countries = { "US", "UK", "India", "Russia", "China", "Australia", "Iran" };
            //1 Linq Method
            List<string> result = countries.ToList();



            //2 Linq Query
            //List<string> result = (from x in countries
            //                                select x).ToList();

            return View(result);
        }
        public IActionResult LinqToArray()
        {
            List<int> num = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //1 Linq Method
            int[] arraynum = num.ToArray();



            //2 Linq Query
            //int[] arraynum = (from m in num
            //                  select m).ToArray();

            return View(arraynum);
        }
        public IActionResult LinqToLookup()
        {
            List<Employee3> objEmployee = new List<Employee3>()
             {
            new Employee3() { Name = "Ashish Sharma", Department = "Marketing", Country = "India" },
            new Employee3() { Name = "John Smith", Department = "IT", Country = "Australia" },
            new Employee3() { Name = "Kim Jong", Department = "Sales", Country = "China" },
            new Employee3() { Name = "Marcia Adams", Department = "HR", Country = "USA" },
            new Employee3() { Name = "John Doe", Department = "Operations", Country = "Canada" }
            };

            //1 Linq Method
            var emp = objEmployee.ToLookup(x => x.Department);



            //2 Linq Query
            //var emp = from y in objEmployee.ToLookup(x => x.Department)
            //                                                  select y;

            return View(emp);
        }
        public IActionResult LinqToLookup2()
        {
            List<string> NumList = new List<string>() { "One", "Two", "Three", "Four", "Five", "Six", "seven" };

            //1 Linq Method
            ILookup<int, string> Num = NumList.ToLookup(x => x.Length);



            //2 Linq Query
            //ILookup<int, string> Num = (from z in NumList
            //                            select z).ToLookup(x => x.Length);
            return View(Num);
        }
        public IActionResult LinqCast()
        {
            List<Object> obj = new List<Object>();
            obj.Add(2.25);
            obj.Add(4.3);
            obj.Add(7.3);
            obj.Add(13.75);

            //1 Linq Method
            IEnumerable<double> result = obj.Cast<double>();



            //2 Linq Query
            //IEnumerable<double> result = from x in obj.Cast<double>()
            //                             select x;
            return View(result);
        }
        public IActionResult LinqAsEnumerable()
        {

            string[] array = new string[] { "Name", "Lastname", "Email", "Password" };
            //1 Linq Method
            IEnumerable result = array.AsEnumerable();



            //2 Linq Query

            return View(result);
        }
        public IActionResult LinqToDictionary()
        {

            List<Student3> objStudent = new List<Student3>()
            {
                new Student3() { Id=1,Name = "Suresh Dasari", Gender = "Male",Location="Chennai" },
                new Student3() { Id=2,Name = "Rohini Alavala", Gender = "Female", Location="Chennai" },
                new Student3() { Id=3,Name = "Praveen Alavala", Gender = "Male",Location="Bangalore" },
                new Student3() { Id=4,Name = "Sateesh Alavala", Gender = "Male", Location ="Vizag"},
                new Student3() { Id=5,Name = "Madhav Sai", Gender = "Male", Location="Nagpur"}
            };



            //1 Linq Method
            Dictionary<int, string> result = objStudent.ToDictionary(x => x.Id, x => x.Name);



            //2 Linq Query
            //Dictionary<int, string> result = (from x in objStudent
            //                                  select x).ToDictionary(x => x.Id, x => x.Name);

            return View(result);
        }
        public IActionResult LinqAggregate()
        {

            int[] Num = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] charlist = { "a", "b", "c", "d" };




            //1 Linq Method
            double Average = Num.Aggregate((a, b) => a * b);
            var concta = charlist.Aggregate((a, b) => a + ',' + b);

            //double Average = Num.Aggregate((a, b) => (a + 1) + b);
            //string concta = charlist.Aggregate((a, b) => a + "->\t" + b);

            //2 Linq Query
            //double Average = (from x in Num
            //                  select x).Aggregate((a, b) => a * b);
            //string concta = (from x in charlist
            //                 select x).Aggregate((a, b) => a + "," + b);



            string result = concta + Average.ToString();
            ViewBag.result = result;

            return View();
        }
        public IActionResult LinqGroupBy()
        {

            List<Student3> objStudent = new List<Student3>()
            {
                new Student3() { Name = "Suresh Dasari", Gender = "Male", Location = "Chennai" },
                new Student3() { Name = "Rohini Alavala", Gender = "Female", Location = "Chennai" },
                new Student3() { Name = "Praveen Alavala", Gender = "Male", Location = "Bangalore" },
                new Student3() { Name = "Sateesh Alavala", Gender = "Male", Location = "Vizag" },
                new Student3() { Name = "Madhav Sai", Gender = "Male", Location = "Nagpur" }
             };




            //1 Linq Method
            var student = objStudent.GroupBy(x => x.Location).ToList();

            //2 Linq Query
            //var student = from x in objStudent.GroupBy(x => x.Location)
            //              select x;
            // or
            //var student = from x in objStudent
            //              group x by x.Location;



            return View(student);
        }
        public IActionResult LinqSequenceEqual()
        {

            string[] arr1 = { "welcome", "to", "tutlane", "com" };
            string[] arr2 = { "welcome", "TO", "TUTLANE", "com" };
            string[] arr3 = { "welcome", "to", "tutlane" };
            string[] arr4 = { "WELCOME", "TO", "TUTLANE" };





            //1 Linq Method
            bool res1 = arr1.SequenceEqual(arr2);
            bool res2 = arr1.SequenceEqual(arr2, StringComparer.OrdinalIgnoreCase);
            bool res3 = arr1.SequenceEqual(arr3);
            bool res4 = arr3.SequenceEqual(arr4, StringComparer.OrdinalIgnoreCase);

            //2 Linq Query





            ViewBag.res1 = res1;
            ViewBag.res2 = res2;
            ViewBag.res3 = res3;
            ViewBag.res4 = res4;

            return View();
        }
        public IActionResult LinqRange()
        {
            //1 Linq Method
            IEnumerable<int> obj = Enumerable.Range(100, 20);

            //2 Linq Query



            return View(obj);
        }
        public IActionResult LinqRepeat()
        {
            //1 Linq Method
            IEnumerable<int> obj = Enumerable.Repeat(524, 3);

            //2 Linq Query



            return View(obj);
        }




















    }
    public class Student1
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Average { get; set; }
    }
    public class Student2
    {
        public string Name { get; set; }

        public string Gender { get; set; }

        public List<string> Subjects { get; set; }
        public static List<Student2> GetList()
        {
            List<Student2> Objstudent = new List<Student2>()
            {
                new Student2() { Name = "Suresh Dasari", Gender = "Male", Subjects = new List<string> { "Mathematics", "Physics" } },
                new Student2() { Name = "Rohini Alavala", Gender = "Female", Subjects = new List<string> { "Entomology", "Botany" } },
                new Student2() { Name = "Praveen Kumar", Gender = "Male", Subjects = new List<string> { "Computers", "Operating System", "Java" } },
                new Student2() { Name = "Sateesh Chandra", Gender = "Male", Subjects = new List<string> { "English", "Social Studies", "Chemistry" } },
                new Student2() { Name = "Madhav Sai", Gender = "Male", Subjects = new List<string> { "Accounting", "Charted" } }
            };
            return Objstudent;
        }
    }



    public class Employee1
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int HoursWorked { get; set; }
    }
    public class Department1
    {
        public int DepId { get; set; }
        public string DepName { get; set; }
    }
    public class Employee2
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int DeptId { get; set; }
    }

    public class Departmant1Employee2
    {
        public string DepName { get; set; }
        public string EmpName { get; set; }
    }
    public class Departmant1Employee2_new
    {
        public string DepName { get; set; }
        public IEnumerable<Employee2> EmpNames { get; set; }
    }

    public class Employee3
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Country { get; set; }
    }

    public class Student3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }

    }
}














