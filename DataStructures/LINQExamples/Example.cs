namespace DataStructures.LINQExamples
{
    public class LINQExamples
    {
        public static void Run()
        {

            WhereExample();
        }

        private static void WhereExample()
        {
            var numbers = new[] { 5, 3, 8, 1, 4, 7, 2, 6, 7, 8, 9, 10, };
            var numbesGreaterThanfive = numbers.Where(n => n > 5);
            Console.WriteLine($"Numbers greater than 5: {string.Join(",", numbesGreaterThanfive)}");

            var peopel = new Person[]
            {
                new Person { Name = "Omid", Age = 30 },
                new Person { Name = "Saeed", Age = 20 },
                new Person { Name = "Vahid", Age = 24 },
                new Person { Name = "Ali", Age = 28 },
                new Person { Name = "Reza", Age = 40 },
            };

            var adults = peopel.Where(p => p.Age > 25);
            Console.WriteLine($"Adults: {string.Join(", ", adults.Select(a => a.Name))}");

            string[] fruits = new[] { "banana", "apple", "orange", "mango", "grape", "kiwi", "watermelon" };
            var fruitsWithEvenIndex = fruits.Where((f, index) => index % 2 == 0);
            Console.WriteLine($"Fruits with even index: {string.Join(", ", fruitsWithEvenIndex)}");

            var result = numbers.Where(n => n > 5).Where(n => n % 2 == 0);
            Console.WriteLine($"Numbers greater than 5 and even: {string.Join(",", result)}");

            var students = new List<Student>
            {
                new Student { Name = "Omid", Courses = new List<string> { "Math", "Physics" } },
                new Student { Name = "Saeed", Courses = new List<string> { "Biology", "Chemistry" } },
                new Student { Name = "Vahid", Courses = new List<string> { "Math", "Biology" } },
                new Student { Name = "Ali", Courses = new List<string> { "History", "Geography" } },
            };

            var query = students.Select(s => s.Courses);

            foreach (var course in query)
            {
                Console.WriteLine($"Courses: {string.Join(", ", course)}");
            }

            var allUniqueCourses = students
            .SelectMany(s => s.Courses)
            .Distinct()
            .OrderBy(course => course);
            foreach (var course in allUniqueCourses)
            {
                Console.WriteLine($"- {course}");
            }

            var studentsWithCourses = students
            .Select(s => new
            {
                s.Name,
                Courses = string.Join(",", s.Courses),
            });

            foreach (var item in studentsWithCourses)
            {
                Console.WriteLine($"{item.Name}: {item.Courses}");
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }


    public class Student
    {
        public string Name { get; set; }
        public List<string> Courses { get; set; }
    }
}