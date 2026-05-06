
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Net;
using TAFESA_Enrolment_System.Model;

namespace TAFESA_Enrolment_System.Tests
{
    [TestFixture]
    public class UtilityTests
    {
        private Student[] students;

        [SetUp]
        public void SetUp()
        {
            students = new Student[]
            {
                new Student("STU005", "IT", new DateTime(2025, 1, 10), new Enrolment(), "Carlos Diaz", "carlos@email.com", "0400000001", new Address()),
                new Student("STU002", "IT", new DateTime(2025, 1, 11), new Enrolment(), "Maria Lopez", "maria@email.com", "0400000002", new Address()),
                new Student("STU009", "IT", new DateTime(2025, 1, 12), new Enrolment(), "Juan Perez", "juan@email.com", "0400000003", new Address()),
                new Student("STU001", "IT", new DateTime(2025, 1, 13), new Enrolment(), "Ana Torres", "ana@email.com", "0400000004", new Address()),
                new Student("STU007", "IT", new DateTime(2025, 1, 14), new Enrolment(), "Luis Ramirez", "luis@email.com", "0400000005", new Address()),
                new Student("STU010", "IT", new DateTime(2025, 1, 15), new Enrolment(), "Sofia Mendoza", "sofia@email.com", "0400000006", new Address()),
                new Student("STU003", "IT", new DateTime(2025, 1, 16), new Enrolment(), "Diego Castro", "diego@email.com", "0400000007", new Address()),
                new Student("STU008", "IT", new DateTime(2025, 1, 17), new Enrolment(), "Elena Vargas", "elena@email.com", "0400000008", new Address()),
                new Student("STU004", "IT", new DateTime(2025, 1, 18), new Enrolment(), "Pedro Salazar", "pedro@email.com", "0400000009", new Address()),
                new Student("STU006", "IT", new DateTime(2025, 1, 19), new Enrolment(), "Camila Rojas", "camila@email.com", "0400000010", new Address())
            };
        }

        [Test]
        public void LinearSearchArray_FoundStudent_ReturnsCorrectIndex()
        {
            Student target = students[3];

            int result = Utility.LinearSeachArray(students, target);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void LinearSearchArray_StudentNotFound_ReturnsMinusOne()
        {
            Student target = new Student("STU999", "IT", DateTime.Now, new Enrolment(), "Not Found", "none@email.com", "0499999999", new Address());

            int result = Utility.LinearSeachArray(students, target);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void BinarySearchArray_FoundStudent_ReturnsCorrectIndex()
        {
            Utility.SelectionSortAscending(students);
            Student target = new Student("STU006", "IT", new DateTime(2025, 1, 19), new Enrolment(), "Camila Rojas", "camila@email.com", "0400000010", new Address());

            int result = Utility.BinarySearchArray(students, target);

            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void BinarySearchArray_StudentNotFound_ReturnsMinusOne()
        {
            Utility.SelectionSortAscending(students);
            Student target = new Student("STU999", "IT", DateTime.Now, new Enrolment(), "Not Found", "none@email.com", "0499999999", new Address());

            int result = Utility.BinarySearchArray(students, target);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void SelectionSortAscending_SortsByStudentIdCorrectly()
        {
            Utility.SelectionSortAscending(students);

            Student[] ascendingExpected = new Student[]
            {
                new Student("STU001"),
                new Student("STU002"),
                new Student("STU003"),
                new Student("STU004"),
                new Student("STU005"),
                new Student("STU006"),
                new Student("STU007"),
                new Student("STU008"),
                new Student("STU009"),
                new Student("STU010")
            };

            Student[] descendingExpected = new Student[]
            {
                new Student("STU010"),
                new Student("STU009"),
                new Student("STU008"),
                new Student("STU007"),
                new Student("STU006"),
                new Student("STU005"),
                new Student("STU004"),
                new Student("STU003"),
                new Student("STU002"),
                new Student("STU001")
            };

   
            for (int i = 0; i < students.Length; i++)
            {
                Assert.That(students[i], Is.EqualTo(ascendingExpected[i]));
                //Assert.That(students[i], Is.EqualTo(descendingExpected[i]));
            }
        }

        [Test]
        public void SelectionSortDescending_SortsByStudentIdCorrectly()
        {
            Utility.SelectionSortDescending(students);

            Student[] ascendingExpected = new Student[]
            {
                new Student("STU001"),
                new Student("STU002"),
                new Student("STU003"),
                new Student("STU004"),
                new Student("STU005"),
                new Student("STU006"),
                new Student("STU007"),
                new Student("STU008"),
                new Student("STU009"),
                new Student("STU010")
            };

            Student[] descendingExpected = new Student[]
            {
                new Student("STU010"),
                new Student("STU009"),
                new Student("STU008"),
                new Student("STU007"),
                new Student("STU006"),
                new Student("STU005"),
                new Student("STU004"),
                new Student("STU003"),
                new Student("STU002"),
                new Student("STU001")
            };

            
            for (int i = 0; i < students.Length; i++)
            {
                //Assert.That(students[i], Is.EqualTo(ascendingExpected[i]));
                Assert.That(students[i], Is.EqualTo(descendingExpected[i]));
            }
        
        }



    }
}
