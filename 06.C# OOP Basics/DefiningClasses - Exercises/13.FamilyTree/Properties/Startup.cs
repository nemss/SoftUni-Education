using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;

namespace _13.FamilyTree
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var listPeople = new List<Person>();
            var storePepople = new List<string>();

            var person = Console.ReadLine();

            string inputLine;
            while (!(inputLine = Console.ReadLine()).Equals("End"))
            {
                var tokens = inputLine.Split(new string[] {" - "}, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 1)
                {
                    var name = tokens[0];
                    var birthday = tokens[1];

                    listPeople.Add(new Person(name, birthday));
                }
                else
                {
                    storePepople.Add(inputLine);
                }
            }

            foreach (var storePerson in storePepople)
            {
                Person parent;
                Person children;

                var info = Regex.Split(storePerson, " - ");

                if (info[0].Contains('/') && info[1].Contains('/')) // Both inputs are dates of birthday
                {
                    var parentBirhtday = info[0];
                    var childrenBirthday = info[1];

                    parent = listPeople
                        .First(p => p.Birthday.Equals(parentBirhtday)); // We searcg for the current person in our list
                    children = listPeople
                        .First(p => p.Birthday.Equals(childrenBirthday)); // We searcg for the current person in our list
                }
                else if (info[0].Contains('/') || info[1].Contains('/')) // One of the inputs is date
                {
                    var name = string.Empty;
                    var birthday = string.Empty;

                    if (info[0].Contains('/')) // First is date
                    {
                        birthday = info[0];
                        name = info[1];

                        parent = listPeople
                            .First(p => p.Birthday.Equals(birthday));
                        children = listPeople
                            .First(p => p.Name.Equals(name));
                    }
                    else // Second is date
                    {
                        birthday = info[1];
                        name = info[0];

                        children = listPeople
                            .First(p => p.Birthday.Equals(birthday));
                        parent = listPeople
                            .First(p => p.Name.Equals(name));
                    }
                }
                else // Both are names
                {
                    var parentName = info[0];
                    var childrenName = info[1];

                    parent = listPeople
                        .First(p => p.Name.Equals(parentName));
                    children = listPeople
                        .First(p => p.Name.Equals(childrenName));
                }

                if (!parent.Children.Contains(children))
                {
                    parent.Children.Add(children);
                }

                if (!children.Parents.Contains(parent))
                {
                    children.Parents.Add(parent);
                }
            }

            Person ourPerson;

            // Chech if the info for our person is Name or Date
            if (person.Contains('/'))
            {
                ourPerson = listPeople.First(p => p.Birthday.Equals(person));
            }
            else
            {
                ourPerson = listPeople.First(p => p.Name.Equals(person));
            }

            var result = new StringBuilder();

            result.AppendLine(ourPerson.ToString());

            result.AppendLine("Parents:");
            foreach (var parent in ourPerson.Parents)
            {
                result.AppendLine(parent.ToString());
            }

            result.AppendLine("Children:");
            foreach (var child in ourPerson.Children)
            {
                result.AppendLine(child.ToString());
            }

            Console.Write(result);
        }
    }
    }

    public class Person
    {
        public Person(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Parents = new List<Person>();
            this.Children = new List<Person>();
        }

        public string Name { get; set; }
        public string Birthday { get; set; }
        public List<Person> Parents { get; set; }
        public List<Person> Children { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Birthday}";
        }
    }

