using System;
using System.Collections.Generic;

namespace test.ConsoleApp
{
    public class Person
    {
        public string Name;
        public int Age;

        public Person(string personName, int personAge)
        {
            Name = personName;
            Age = personAge;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Pero Peric", 24);
            Person person2 = new Person("Ivo Ivic", 21);
            Person person3 = new Person("Karlo Karlic", 35);

            List<Person> people = new List<Person>();
            people.Add(person1);
            people.Add(person2);
            people.Add(person3);

            /*
            foreach (Person person in people)
            {
                Console.WriteLine(person.Name, person.Age);
            }
            */
        }
    }
}
