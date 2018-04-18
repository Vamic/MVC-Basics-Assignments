using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Person
    {
        private static int PeopleCount = 0;
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }

        public static List<Person> PeopleList { get; set; }
        
        public Person() { }
        
        public Person(string name, string phone, string city, bool isTemplate)
        {
            this.Name = name;
            this.Phone = phone;
            this.City = city;
            if(!isTemplate)
            {
                PeopleCount++;
                this.ID = PeopleCount;
            }
        }

        public Person(string name, string phone, string city) 
            : this(name, phone, city, false)
        {
        }

        public static void GenerateList()
        {
            PeopleList = new List<Person>
            {
                new Person("Thomas Whitty", "070-4324031", "GRÖNAHÖG"),
                new Person("Orlando Bryce", "0981-6841735", "TOMTEBODA"),
                new Person("Shawanna To", "0693-2595150", "BALLINGSLÖV"),
                new Person("Broderick Oglesby", "0739-9681594", "ÖJE"),
                new Person("Junko Schoolcraft", "0528-2784905", "SÖLVESBORG"),
                new Person("Kellie Testerman", "08-2223857", "HARMÅNGER"),
                new Person("Laurette Ottman", "0651-3015369", "KUNGSHAMN"),
                new Person("Jerrica Milot", "033-2400723", "ÖDESBORG"),
                new Person("Fermin Kazmierczak", "0923-8648243", "ÖDESBORG"),
                new Person("Rayna Brown", "0494-8726761", "HISHULT")
            };
        }

        public static List<Person> FilterList(List<Person> list, string search, bool caseSensitive)
        {
            if(caseSensitive)
                return list.Where(person => person.Name.Contains(search) || person.City.Contains(search)).ToList();
            search = search.ToLower();
            return list.Where(person => person.Name.ToLower().Contains(search) || person.City.ToLower().Contains(search)).ToList();
        }

        public static bool operator true(Person person)
        {
            return person.ID > 0;
        }

        public static bool operator false(Person person)
        {
            return person.ID == 0;
        }
    }
}