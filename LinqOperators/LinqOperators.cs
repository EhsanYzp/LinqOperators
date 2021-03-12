using LinqOperators.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqOperators
{
    /// <summary>
    /// Class which has the basic usage example of different operators of LINQ components.
    /// The general format of LINQ query is as follows:
    /// from <range variable> in <IEnumerable<T> or IQueryable<T> Collection>
    /// <Standard Query Operators> <lambda expression>
    /// <select or groupBy operator > <result formation>
    /// </summary>
    class LinqComponent
    {
        /// <summary>
        /// This function is an example of query syntax or query expression syntax.
        /// Query syntax is similar to SQL (Structured Query Language) for the database.
        /// </summary>
        public void QuerySyntax()
        {
            IList<string> names = new List<string>()
            {
                "name1",
                "name2",
                "name3",
                "name4",
                "name1andname2"
            };

            //LINQ Query syntax
            var result = from s in names
                         where s.Contains("name1")
                         select s;

            foreach (var item in result)
            {
                Console.WriteLine($"result of query syntax: {item}");
            }
        }

        /// <summary>
        /// This function is an example of method syntax.
        /// Method syntax (also known as fluent syntax) uses extension methods included in the Enumerable or Queryable static class,
        /// similar to how you would call the extension method of any class.
        /// </summary>
        public void MethodSyntax()
        {
            IList<string> names = new List<string>()
            {
                "name1",
                "name2",
                "name3",
                "name4",
                "name1andname2"
            };

            var result = names.Where(s => s.Contains("name1"));

            foreach (var item in result)
            {
                Console.WriteLine($"result of method syntax: {item}");
            }
        }

        /// <summary>
        /// This function sample uses a Where operator to filter the students who is teen ager from the given collection(sequence).
        /// It uses a lambda expression as a predicate function.
        /// </summary>
        public void WhereOperator()
        {
            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

            // query type1: LINQ Query Syntax to find out teenager students
            var teenAgerStudent = from s in studentList
                                  where s.Age > 12 && s.Age < 20
                                  select s;

            //query type2: Alternatively, you can also use a Func type delegate with an anonymous method to pass as a predicate function as below (output would be the same):
            /*
            Func<Student, bool> isTeenAger = delegate (Student s) {
                return s.Age > 12 && s.Age < 20;
            };

            var filteredResult = from s in studentList
                                 where isTeenAger(s)
                                 select s;
            */

            // query type3: LINQ Query Method to find out teenager students.
            //Unlike the query syntax, you need to pass whole lambda expression as a predicate function
            //instead of just body expression in LINQ method syntax.
            // var teenAgerStudent = studentList.Where(s => s.Age > 12 && s.Age < 20);


            // the Where extension method also have second overload that includes index of current element in the collection.
            // You can use that index in your logic if you need.
            /* 
              var filteredResult = studentList.Where((s, i) => {
                if (i % 2 == 0) // if it is even element
                    return true;

                return false;
            });
            */

            Console.WriteLine("Teen age Students:");

            foreach (Student std in teenAgerStudent)
            {
                Console.WriteLine(std.StudentName);
            }
        }

        /// <summary>
        /// The OfType operator filters the collection based on the ability to cast an element in a collection to a specified type.
        /// </summary>
        public void OfTypeOperator()
        {
            IList mixedList = new ArrayList();
            mixedList.Add(0);
            mixedList.Add("One");
            mixedList.Add("Two");
            mixedList.Add(3);
            mixedList.Add(new Student() { StudentID = 22, StudentName = "Ehsan" });

            var stringResult = from s in mixedList.OfType<string>() select s;
            var intResult = from s in mixedList.OfType<int>() select s;
            var stdResult = from s in mixedList.OfType<Student>() select s;

            //quert type 2: OfType in Method Syntax
            //var stringResult = mixedList.OfType<string>();

            foreach (var str in stringResult)
                Console.WriteLine(str);

            foreach (var integer in intResult)
                Console.WriteLine(integer);

            foreach (var std in stdResult)
                Console.WriteLine(std.StudentName);
        }

        /// <summary>
        /// OrderBy sorts the values of a collection in ascending or descending order.
        /// It sorts the collection in ascending order by default because ascending keyword is optional here.
        /// Use descending keyword to sort collection in descending order.
        /// </summary>
        public void OrderByOperator()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            var orderByResult = from s in studentList
                                orderby s.StudentName //Sorts the studentList collection in ascending order
                                select s;

            var orderByDescendingResult = from s in studentList //Sorts the studentList collection in descending order
                                          orderby s.StudentName descending
                                          select s;

            Console.WriteLine("Ascending Order:");

            foreach (var std in orderByResult)
                Console.WriteLine(std.StudentName);

            Console.WriteLine("Descending Order:");

            foreach (var std in orderByDescendingResult)
                Console.WriteLine(std.StudentName);

            //method syntax
            //var studentsInAscOrder = studentList.OrderBy(s => s.StudentName);
            //var studentsInDescOrder = studentList.OrderByDescending(s => s.StudentName);


            //multiple sorting: You can sort the collection on multiple fields seperated by comma.
            //The given collection would be first sorted based on the first field and then
            //if value of first field would be the same for two elements then 
            //it would use second field for sorting and so on.
            //var orderByResult = from s in studentList
            //                    orderby s.StudentName, s.Age
            //                    select new { s.StudentName, s.Age };
        }

        /// <summary>
        /// The OrderBy() method sorts the collection in ascending order based on specified field.
        /// Use ThenBy() method after OrderBy to sort the collection on another field in ascending order. 
        /// Linq will first sort the collection based on primary field which is specified by OrderBy method and
        /// then sort the resulted collection in ascending order again based on secondary field specified by ThenBy method.
        /// </summary>
        public void ThenByOperator()
        {
            IList<Student> studentList = new List<Student>()
            {
                new Student(){ Age = 121, StudentID = 233, StudentName = "name1"},
                new Student(){ Age = 321, StudentID = 23243, StudentName = "sdname1"},
                new Student(){ Age = 721, StudentID = 23133, StudentName = "4rername1"},
                new Student(){ Age = 251, StudentID = 1233, StudentName = "asdname1"},
                new Student(){ Age = 321, StudentID = 6233, StudentName = "nsadame1"}
            };

            var thenByResult = studentList.OrderBy(s => s.Age).ThenBy(s => s.StudentName);

            foreach (var item in thenByResult)
            {
                Console.WriteLine(item.StudentName);
            }
            var thenByResultSDescending = studentList.OrderBy(s => s.Age).ThenByDescending(s => s.StudentName);
            foreach (var item in thenByResultSDescending)
            {
                Console.WriteLine($"{item.Age} , {item.StudentName}");
            }
        }

        /// <summary>
        /// The GroupBy operator returns a group of elements from the given collection based on some key value.
        /// Each group is represented by IGrouping<TKey, TElement> object.
        /// Also, the GroupBy method has eight overload methods, so you can use appropriate extension method based on your requirement in method syntax.
        /// The result of GroupBy operators is a collection of groups.For example, GroupBy returns IEnumerable<IGrouping<TKey, Student>> from the Student collection
        /// </summary>
        public void GroupByOperator()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Abram" , Age = 21 }
            };

            //GroupBy in query syntax
            var groupedResult = from s in studentList
                                group s by s.Age;

            foreach (var ageGroup in groupedResult)
            {
                Console.WriteLine($"Age group: {ageGroup.Key}");

                foreach (var Student in ageGroup)
                {
                    Console.WriteLine($"Student: {Student.StudentName}");
                }
            }
            //GroupBy in method Syntax
            // var groupedResult2 = studentList.GroupBy(s => s.Age);
        }

        /// <summary>
        /// ToLookup is the same as GroupBy; the only difference is GroupBy execution is deferred, whereas ToLookup execution is immediate.
        /// Also, ToLookup is only applicable in Method syntax. ToLookup is not supported in the query syntax.
        /// </summary>
        public void ToLookUpOperator()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Abram" , Age = 21 }
            };

            var lookupResult = studentList.ToLookup(s => s.Age);

            foreach (var group in lookupResult)
            {
                Console.WriteLine("Age Group: {0}", group.Key);  //Each group has a key 

                foreach (Student s in group)  //Each group has a inner collection  
                    Console.WriteLine("Student Name: {0}", s.StudentName);
            }
        }

        /// <summary>
        /// The Join operator operates on two collections, inner collection & outer collection.
        /// It returns a new collection that contains elements from both the collections which satisfies specified expression.
        /// It is the same as inner join of SQL.
        /// </summary>
        public void JoinOperator()
        {
            IList<string> strList1 = new List<string>() {
                "One",
                "Two",
                "Three",
                "Four"
            };

            IList<string> strList2 = new List<string>() {
                "One",
                "Two",
                "Five",
                "Six"
            };
            var innerJoin = strList1.Join(                          //outer sequence
                                            strList2,               //inner sequence
                                            str1 => str1,           //outerkeyselector
                                            str2 => str2,           //innerkeyselector
                                            (str1, str2) => str1);  //result selector

            foreach (var item in innerJoin)
            {
                Console.WriteLine(item);
            }

            //Join operator in query syntax.
            /*
            var innerJoin = from s in studentList // outer sequence
                            join st in standardList //inner sequence 
                            on s.StandardID equals st.StandardID // key selector 
                            select new
                            { // result selector 
                                StudentName = s.StudentName,
                                StandardName = st.StandardName
                            };
                            */
        }

        /// <summary>
        /// The GroupJoin operator joins two sequences based on key and groups the result by matching key and then returns the collection of grouped result and key.
        /// </summary>
        public void GroupJoinOperator()
        {
            IList<StudentWithStandardId> studentList = new List<StudentWithStandardId>() {
                new StudentWithStandardId() { StudentID = 1, StudentName = "John", StandardID =1 },
                new StudentWithStandardId() { StudentID = 2, StudentName = "Moin", StandardID =1 },
                new StudentWithStandardId() { StudentID = 3, StudentName = "Bill", StandardID =2 },
                new StudentWithStandardId() { StudentID = 4, StudentName = "Ram",  StandardID =2 },
                new StudentWithStandardId() { StudentID = 5, StudentName = "Ron" }
            };

            IList<Standard> standardList = new List<Standard>() {
                 new Standard(){ StandardID = 1, StandardName="Standard 1"},
                 new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };

            var groupJoin = standardList.GroupJoin(studentList,  //inner sequence
                                            std => std.StandardID, //outerKeySelector 
                                            s => s.StandardID,     //innerKeySelector
                                            (std, studentsGroup) => new // resultSelector 
                                            {
                                                Students = studentsGroup,
                                                StandarFulldName = std.StandardName
                                            });

            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.StandarFulldName);

                foreach (var stud in item.Students)
                    Console.WriteLine(stud.StudentName);
            }

        }

        /// <summary>
        /// The Select operator always returns an IEnumerable collection which contains elements based on a transformation function.
        /// It is similar to the Select clause of SQL that produces a flat result set.
        /// </summary>
        public void SelectOperator()
        {
            IList<Student> studentList = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John" },
            new Student() { StudentID = 2, StudentName = "Moin" },
            new Student() { StudentID = 3, StudentName = "Bill" },
            new Student() { StudentID = 4, StudentName = "Ram" },
            new Student() { StudentID = 5, StudentName = "Ron" }
        };

            //select in query syntax
            var selectResult = from s in studentList
                               select s.StudentName;

            foreach (var item in selectResult)
            {
                Console.WriteLine($"student name: {item}");
            }

            //Select in Method Syntax
            //var selectResult = studentList.Select(s => new { Name = s.StudentName, Age = s.Age });
        }

        /// <summary>
        /// The All operator evalutes each elements in the given collection on a specified condition and returns True if all the elements satisfy a condition.
        /// </summary>
        public void AllOperator()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            bool areAllStudentsTeenager = studentList.All(s => s.Age > 12 && s.Age < 20);

            Console.WriteLine($"are all students teenager? {areAllStudentsTeenager}");
        }

        /// <summary>
        /// Any checks whether any element satisfy given condition or not? In the following example, Any operation is used to check whether any student is teen ager or not.
        /// </summary>
        public void AnyOperator()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            bool areAnyStudentsTeenager = studentList.Any(s => s.Age > 12 && s.Age < 20);

            Console.WriteLine($"are any students teenager? {areAnyStudentsTeenager}");
        }

        /// <summary>
        /// he Contains operator checks whether a specified element exists in the collection or not and returns a boolean.
        /// The follow example works well with primitive data types. However, it will not work with a custom class.
        /// to compare values of those objects, you need to create a class by implementing IEqualityComparer interface, that compares values of two specified objects and returns boolean.
        /// </summary>
        public void ContainsOperator()
        {
            IList<int> intList = new List<int>() { 1, 2, 3, 4, 5 };

            bool result10 = intList.Contains(10);
            Console.WriteLine($"is this list contains 10? {result10}");

            bool result5 = intList.Contains(5);
            Console.WriteLine($"is this list contains 5? {result5}");
        }

        /// <summary>
        /// The aggregation operators perform mathematical operations like Average, Aggregate, Count, Max, Min and Sum, on the numeric property of the elements in the collection.
        /// </summary>
        public void AggegateOperator()
        {
            //overload 1:
            //   public static TSource Aggregate<TSource>(this IEnumerable<TSource> source,
            //                            Func<TSource, TSource, TSource> func);
            IList<String> strList = new List<String>() { "One", "Two", "Three", "Four", "Five" };

            var commaSeperatedString = strList.Aggregate((s1, s2) => s1 + ", " + s2);

            Console.WriteLine(commaSeperatedString);

            //overload2
            // public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source,
            //                            TAccumulate seed,
            //                             Func<TAccumulate, TSource, TAccumulate> func);

            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
            };

            string commaSeparatedStudentNames = studentList.Aggregate<Student, string>(
                                                    "Student Names: ",  // seed value
                                                    (str, s) => str += s.StudentName + ",");

            Console.WriteLine(commaSeparatedStudentNames);

            //overload3
            //public static TResult Aggregate<TSource, TAccumulate, TResult>(this IEnumerable<TSource> source,
            //                             TAccumulate seed,
            //                            Func<TAccumulate, TSource, TAccumulate> func,
            //                            Func<TAccumulate, TResult> resultSelector);

            string commaSeparatedStudentNames2 = studentList.Aggregate<Student, string, string>(
                                            String.Empty, // seed value
                                            (str, s) => str += s.StudentName + ",", // returns result using seed value, String.Empty goes to lambda expression as str
                                            str => str.Substring(0, str.Length - 1)); // result selector that removes last comma

            Console.WriteLine(commaSeparatedStudentNames2);
            //overload3
        }

        /// <summary>
        /// Average extension method calculates the average of the numeric items in the collection. Average method returns nullable or non-nullable decimal, double or float value.
        /// </summary>
        public void AverageOperator()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
            };

            var avgAge = studentList.Average(s => s.Age);

            Console.WriteLine("Average Age of Student: {0}", avgAge);
        }

        /// <summary>
        /// The Count operator returns the number of elements in the collection or number of elements that have satisfied the given condition.
        /// </summary>
        public void CountOperator()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Mathew", Age = 15 }
            };

            //overload1:int Count<TSource>();
            //The first overload method of Count returns the number of elements in the specified collection
            var totalStudents = studentList.Count();

            Console.WriteLine("Total Students: {0}", totalStudents);

            //overload2:int Count<TSource>(Func<TSource, bool> predicate);
            //the second overload method returns the number of elements which have satisfied the specified condition given as lambda expression/predicate function.
            var adultStudents = studentList.Count(s => s.Age >= 18);

            Console.WriteLine("Number of Adult Students: {0}", adultStudents);

            //Count operator in query syntax
            //C# Query Syntax doesn't support aggregation operators. However, you can wrap the query into brackets and use an aggregation functions as shown below.
            var totalAge = (from s in studentList
                            select s.Age).Count();

            Console.WriteLine($"count operator in query syntax: {totalAge}");
        }

        /// <summary>
        /// The Max operator returns the largest numeric element from a collection.
        /// </summary>
        public void MaxOperator()
        {
            //example 1
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };

            var largest = intList.Max();

            Console.WriteLine("Largest Element: {0}", largest);


            //example2
            var largestEvenElements = intList.Max(i =>
            {
                if (i % 2 == 0)
                    return i;

                return 0;
            });

            Console.WriteLine("Largest Even Element: {0}", largestEvenElements);

            //example3
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "Johjkhkljhn", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
            };

            var oldest = studentList.Max(s => s.Age);

            Console.WriteLine("Oldest Student Age: {0}", oldest);

            //example4
            // to find the student with the longest name, you need to implement IComparable<T> interface and compare student names' length in CompareTo method.
            //So now, you can use Max() method which will use CompareTo method in order to return appropriate result.
            var studentWithLongName = studentList.Max();

            Console.WriteLine("Student ID: {0}, Student Name: {1}", studentWithLongName.StudentID, studentWithLongName.StudentName);
        }

        /// <summary>
        /// The Sum() method calculates the sum of numeric items in the collection.
        /// </summary>
        public void SumOperator()
        {
            //example1
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };

            var total = intList.Sum();

            Console.WriteLine("Sum: {0}", total);

            //example2
            var sumOfEvenElements = intList.Sum(i =>
            {
                if (i % 2 == 0)
                    return i;

                return 0;
            });

            Console.WriteLine("Sum of Even Elements: {0}", sumOfEvenElements);


            //example3
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
            };

            var sumOfAge = studentList.Sum(s => s.Age);

            Console.WriteLine("Sum of all student's age: {0}", sumOfAge);

            var numOfAdults = studentList.Sum(s =>
            {
                if (s.Age >= 18)
                    return 1;
                else
                    return 0;
            });

            Console.WriteLine("Total Adult Students: {0}", numOfAdults);
        }

        /// <summary>
        /// The ElementAt() method returns an element from the specified index from a given collection. 
        /// If the specified index is out of the range of a collection then it will throw an Index out of range exception. Please note that index is a zero based index.
        /// </summary>
        public void ElementAtOperator()
        {
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { "One", "Two", null, "Four", "Five" };

            Console.WriteLine("1st Element in intList: {0}", intList.ElementAt(0));
            Console.WriteLine("1st Element in strList: {0}", strList.ElementAt(0));
        }

        /// <summary>
        /// The ElementAtOrDefault() method also returns an element from the specified index from a collaction and
        /// if the specified index is out of range of a collection then it will return a default value of the data type instead of throwing an error.
        /// </summary>
        public void ElementAtOrDefaultOperator()
        {
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { "One", "Two", null, "Four", "Five" };

            Console.WriteLine("3rd Element in intList: {0}", intList.ElementAtOrDefault(2));
            Console.WriteLine("3rd Element in strList: {0}", strList.ElementAtOrDefault(2));

            Console.WriteLine("10th Element in intList: {0} - default int value",
                intList.ElementAtOrDefault(9));
            Console.WriteLine("10th Element in strList: {0} - default string value (null)",
                             strList.ElementAtOrDefault(9));
        }

        /// <summary>
        /// The First() method returns the first element of a collection, or the first element that satisfies the specified condition using lambda expression or Func delegate.
        /// If a given collection is empty or does not include any element that satisfied the condition then it will throw InvalidOperation exception.
        /// </summary>
        public void FirstOperator()
        {
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine("1st Element in intList: {0}", intList.First());

            //This overload method takes the lambda expression as predicate delegate to specify a condition and returns the first element that satisfies the specified condition.
            Console.WriteLine("1st Even Element in intList: {0}", intList.First(i => i % 2 == 0));

            Console.WriteLine("1st Element in strList: {0}", strList.First());

            //  emptyList.First() throws an InvalidOperationException
            //   Console.WriteLine(emptyList.First());
        }


        /// <summary>
        /// The FirstOrDefault() method does the same thing as First() method.
        /// The only difference is that it returns default value of the data type of a collection if a collection is empty or
        /// doesn't find any element that satisfies the condition.
        /// </summary>
        public void FirstOrDefaultOperator()
        {
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine("1st Element in intList: {0}", intList.FirstOrDefault());
            Console.WriteLine("1st Even Element in intList: {0}",
                                             intList.FirstOrDefault(i => i % 2 == 0));

            Console.WriteLine("1st Element in strList: {0}", strList.FirstOrDefault());

            Console.WriteLine("1st Element in emptyList: {0}", emptyList.FirstOrDefault());

            //If a collection includes null element then FirstOrDefault() throws an exception while evaluting the specified condition. The following example demonstrates this.
            //   Console.WriteLine("1st Even Element in intList: {0}",
            //                       strList.FirstOrDefault(s => s.Contains("T")));
        }

        /// <summary>
        /// The Last() method returns the last element from a collection, or the last element that satisfies the specified condition using lambda expression or Func delegate.
        /// If a given collection is empty or does not include any element that satisfied the condition then it will throw InvalidOperation exception.
        /// </summary>
        public void LastOperator()
        {
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine("Last Element in intList: {0}", intList.Last());

            Console.WriteLine("Last Even Element in intList: {0}", intList.Last(i => i % 2 == 0));

            Console.WriteLine("Last Element in strList: {0}", strList.Last());

            //  emptyList.Last() throws an InvalidOperationException
            //    Console.WriteLine(emptyList.Last());
        }

        /// <summary>
        /// The LastOrDefault() method does the same thing as Last() method.
        /// The only difference is that it returns default value of the data type of a collection if a collection is empty or doesn't find any element that satisfies the condition.
        /// </summary>
        public void LastOrDefaultOperator()
        {
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine("Last Element in intList: {0}", intList.LastOrDefault());

            Console.WriteLine("Last Even Element in intList: {0}",
                                             intList.LastOrDefault(i => i % 2 == 0));

            Console.WriteLine("Last Element in strList: {0}", strList.LastOrDefault());

            Console.WriteLine("Last Element in emptyList: {0}", emptyList.LastOrDefault());
        }


        /// <summary>
        /// Returns the only element from a collection, or the only element that satisfies a condition.
        /// If Single() found no elements or more than one elements in the collection then throws InvalidOperationException.
        /// </summary>
        public void SingleOperator()
        {
            IList<int> oneElementList = new List<int>() { 7 };
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine("The only element in oneElementList: {0}", oneElementList.Single());
            Console.WriteLine("The only element which is less than 10 in intList: {0}",
             intList.Single(i => i < 10));

            //Followings throw an exception
            //Console.WriteLine("The only Element in intList: {0}", intList.Single());
            //Console.WriteLine("The only Element in emptyList: {0}", emptyList.Single());
        }

        /// <summary>
        /// The same as Single, except that it returns a default value of a specified generic type, 
        /// instead of throwing an exception if no element found for the specified condition.
        /// However, it will thrown InvalidOperationException if it found more than one element for the specified condition in the collection.
        /// </summary>
        public void SingleOrDefaultOperator()
        {
            IList<int> oneElementList = new List<int>() { 7 };
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine("The only element in oneElementList: {0}",
             oneElementList.SingleOrDefault());

            Console.WriteLine("Element in emptyList: {0}", emptyList.SingleOrDefault());

            //Followings throw an exception
            //Console.WriteLine("The only Element in intList: {0}", intList.SingleOrDefault());
        }

        /// <summary>
        /// The SequenceEqual method checks whether the number of elements, value of each element and order of elements in two collections are equal or not.
        /// If the collection contains elements of primitive data types then it compares the values and number of elements, whereas collection with complex type elements, 
        /// checks the references of the objects.So, if the objects have the same reference then they considered as equal otherwise they are considered not equal.
        /// </summary>

        public void SequenceEqualOperator()
        {
            IList<string> strList1 = new List<string>() { "one", "two", "three", "four", "five" };
            IList<string> strList2 = new List<string>() { "one", "two", "three", "four", "five" };
            IList<string> strList3 = new List<string>() { "ten", "two", "six", "four", "five" };

            bool isEqual = strList1.SequenceEqual(strList2);
            Console.WriteLine($"is strList1 and strList2 equal? {isEqual}");

            bool isEqual2 = strList1.SequenceEqual(strList3);
            Console.WriteLine($"is strList1 and strList3 equal? {isEqual2}");
        }

        /// <summary>
        /// The Concat() method appends two sequences of the same type and returns a new sequence (collection).
        /// </summary>
        public void ConcatOperator()
        {
            IList<string> collection1 = new List<string>() { "One", "Two", "Three" };
            IList<string> collection2 = new List<string>() { "Five", "Six" };

            var collection3 = collection1.Concat(collection2);

            foreach (string str in collection3)
                Console.WriteLine(str);

            IList<int> collection11 = new List<int>() { 1, 2, 3 };
            IList<int> collection22 = new List<int>() { 4, 5, 6 };

            var collection33 = collection11.Concat(collection22);

            foreach (int i in collection33)
                Console.WriteLine(i);
        }

        /// <summary>
        /// The DefaultIfEmpty() method returns a new collection with the default value if the given collection on which DefaultIfEmpty() is invoked is empty.
        ///  Another overload method of DefaultIfEmpty() takes a value parameter that should be replaced with default value.
        /// </summary>
        public void DefaultIfEmptyOperator()
        {
            IList<string> emptyList = new List<string>();

            var newList1 = emptyList.DefaultIfEmpty();
            var newList2 = emptyList.DefaultIfEmpty("None");

            Console.WriteLine("Count: {0}", newList1.Count());
            Console.WriteLine("Value: {0}", newList1.ElementAt(0));

            Console.WriteLine("Count: {0}", newList2.Count());
            Console.WriteLine("Value: {0}", newList2.ElementAt(0));
        }

        /// <summary>
        /// The Empty() method is not an extension method of IEnumerable or IQueryable like other LINQ methods. It is a static method included in Enumerable static class.
        /// So, you can call it the same way as other static methods like Enumerable.Empty<TResult>().
        /// The Empty() method returns an empty collection of a specified type 
        /// </summary>
        public void EmptyOperator()
        {
            var emptyCollection1 = Enumerable.Empty<string>();
            var emptyCollection2 = Enumerable.Empty<Student>();

            Console.WriteLine("Count: {0} ", emptyCollection1.Count());
            Console.WriteLine("Type: {0} ", emptyCollection1.GetType().Name);

            Console.WriteLine("Count: {0} ", emptyCollection2.Count());
            Console.WriteLine("Type: {0} ", emptyCollection2.GetType().Name);
        }

        /// <summary>
        /// The Range() method returns a collection of IEnumerable<T> type with specified number of elements and sequential values starting from the first element.
        /// </summary>
        public void RangeOperator()
        {
            var intCollection = Enumerable.Range(10, 10);
            Console.WriteLine("Total Count: {0} ", intCollection.Count());

            for (int i = 0; i < intCollection.Count(); i++)
                Console.WriteLine("Value at index {0} : {1}", i, intCollection.ElementAt(i));
        }


        /// <summary>
        /// The Repeat() method generates a collection of IEnumerable<T> type with specified number of elements and each element contains same specified value.
        /// </summary>
        public void RepeatOperator()
        {
            var intCollection = Enumerable.Repeat<int>(10, 10);
            Console.WriteLine("Total Count: {0} ", intCollection.Count());

            for (int i = 0; i < intCollection.Count(); i++)
                Console.WriteLine("Value at index {0} : {1}", i, intCollection.ElementAt(i));
        }

        /// <summary>
        /// The Distinct extension method returns a new collection of unique elements from the given collection.
        /// </summary>
        public void DistinctOperator()
        {
            IList<string> strList = new List<string>() { "One", "Two", "Three", "Two", "Three" };

            IList<int> intList = new List<int>() { 1, 2, 3, 2, 4, 4, 3, 5 };

            var distinctList1 = strList.Distinct();

            foreach (var str in distinctList1)
                Console.WriteLine(str);

            var distinctList2 = intList.Distinct();

            foreach (var i in distinctList2)
                Console.WriteLine(i);
        }

        /// <summary>
        /// The Except() method requires two collections. It returns a new collection with elements from the first collection which do not exist in the second collection (parameter collection).
        /// </summary>
        public void ExceptOperator()
        {
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };

            var result = strList1.Except(strList2);

            foreach (string str in result)
                Console.WriteLine(str);
        }

        /// <summary>
        /// The Intersect extension method requires two collections. It returns a new collection that includes common elements that exists in both the collection. 
        /// </summary>
        public void IntersectOperator()
        {
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };

            var result = strList1.Intersect(strList2);

            foreach (string str in result)
                Console.WriteLine(str);
        }

        /// <summary>
        /// The Union extension method requires two collections and returns a new collection that includes distinct elements from both the collections.
        /// </summary>
        public void UnionOperator()
        {
            IList<string> strList1 = new List<string>() { "One", "Two", "three", "Four" };
            IList<string> strList2 = new List<string>() { "Two", "THREE", "Four", "Five" };

            var result = strList1.Union(strList2);

            foreach (string str in result)
                Console.WriteLine(str);
        }

        /// <summary>
        /// Skips elements up to a specified position starting from the first element in a sequence.
        /// </summary>
        public void SkipOperator()
        {
            IList<string> strList = new List<string>() { "one", "two", "three", "four", "five" };

            var newList = strList.Skip(2);

            foreach (var str in newList)
            {
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// Skips elements based on a condition until an element does not satisfy the condition.
        /// If the first element itself doesn't satisfy the condition, it then skips 0 elements and returns all the elements in the sequence.
        /// </summary>
        public void SkipWhileOperator()
        {
            IList<string> strList = new List<string>() {
                                            "One",
                                            "Two",
                                            "Three",
                                            "Four",
                                            "Five",
                                            "Six"  };

            var resultList = strList.SkipWhile(s => s.Length < 4);

            foreach (string str in resultList)
                Console.WriteLine(str);
        }

        /// <summary>
        /// Partitioning operators split the sequence (collection) into two parts and returns one of the parts.
        /// The Take() extension method returns the specified number of elements starting from the first element.
        /// </summary>
        public void TakeOperator()
        {
            IList<string> strList = new List<string>() { "One", "Two", "Three", "Four", "Five" };

            var newList = strList.Take(2);

            foreach (var str in newList)
                Console.WriteLine(str);
        }

        /// <summary>
        /// The TakeWhile() extension method returns elements from the given collection until the specified condition is true.
        /// If the first element itself doesn't satisfy the condition then returns an empty collection.
        /// </summary>
        public void TakeWhileOperator()
        {
            IList<string> strList = new List<string>() {
                                            "Three",
                                            "Four",
                                            "Five",
                                            "Hundred"  };

            var result = strList.TakeWhile(s => s.Length > 4);

            foreach (string str in result)
                Console.WriteLine(str);
        }

        /// <summary>
        /// ToList converts collection to list
        /// ToArray converts a collection to an array
        /// </summary>
        public void ToListAndToArrayOperators()
        {
            IList<string> strList = new List<string>() {
                                            "One",
                                            "Two",
                                            "Three",
                                            "Four",
                                            "Three"
                                            };

            string[] strArray = strList.ToArray<string>();// converts List to Array

            IList<string> list = strArray.ToList<string>(); // converts array into list
        }

        /// <summary>
        /// Converts a Generic list to a generic dictionary
        /// </summary>
        public void ToDictionaryOperator()
        {
            IList<Student> studentList = new List<Student>() {
                    new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                    new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
                };

            //following converts list into dictionary where StudentId is a key
            IDictionary<int, Student> studentDict =
                                            studentList.ToDictionary<Student, int>(s => s.StudentID);

            foreach (var key in studentDict.Keys)
                Console.WriteLine("Key: {0}, Value: {1}",
                                            key, (studentDict[key] as Student).StudentName);
        }
    }
}
