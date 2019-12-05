using System;
using Xunit;

namespace PageObjectsExample
{
    public class FunctionsExample
    { 
        [Fact]
        public void TestSample()
        {
            var person = new Person("Jan", "Kowalski");
            var personNumber = person.Create();
            person.Edit(personNumber);

            person.MetodaScalona_CreateAndEdit();
        }

    }

    internal class Person
    {
        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; }
        public string Surname { get; }

        internal string Create()
        {
            // jakas logika tworzenia 

            return "12334345";

        }

        internal void Edit(string personNumber)
        {
            // jakas logika edycji
            Assert.Equal("1233", personNumber);
        }

        internal void MetodaScalona_CreateAndEdit()
        { // jakas logika tworzenia 

            var personNumber = "12334345";

            // jakas logika edycji
            Assert.Equal("1233", personNumber);
        }
    }
}
