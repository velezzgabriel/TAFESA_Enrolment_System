using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAFESA_Enrolment_System.Model;

namespace TAFESA_Enrolment_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== TESTING STUDENT CONSTRUCTORS ===");
            Console.WriteLine();

            // Test no-args constructor
            Student student1 = new Student();
            Console.WriteLine("student1 (no-args constructor):");
            Console.WriteLine(student1);
            Console.WriteLine();

            // Test constructor with only studentID
            Student student2 = new Student("S1001");
            Console.WriteLine("student2 (studentID-only constructor):");
            Console.WriteLine(student2);
            Console.WriteLine();

            // Create address object for student 1,3,4,5
            Address addressStudent1 = new Address(
                "45",
                "Cordoba Avenue",
                "Glenelg",
                "5045",
                "SA"
            );

            Address addressStudent3 = new Address(
                "12",
                "King Street",
                "Adelaide",
                "5000",
                "SA"
            );

            Address addressStudent4 = new Address(
                "34",
                "Queen Street",
                "Adelaide",
                "5000",
                "SA"
            );

            Address addressStudent5 = new Address(
                "56",
                "Prince Street",
                "Adelaide",
                "5000",
                "SA"
            );


            Enrolment enrolmentStudent1 = new Enrolment(
                new Subject("ICTWEB430", "Produce Server-Side Script for Dynamic Web Pages", 950.00),
                new DateTime(2026, 2, 15),
                "Pass",
                2
            );

            Enrolment enrolmentStudent3 = new Enrolment(
                new Subject("ICTPRG547", "Apply Advanced Programming Skills", 1200.00),
                new DateTime(2026, 3, 8),
                "Pass",
                1
            );

            Enrolment enrolmentStudent4 = new Enrolment(
                new Subject("ICTPRG547", "Apply Advanced Programming Skills", 1200.00),
                new DateTime(2025, 1, 1),
                "Fail",
                2
            );

            Enrolment enrolmentStudent5 = new Enrolment(
                new Subject("ICTPRG547", "Apply Advanced Programming Skills", 1200.00),
                new DateTime(2026, 3, 8),
                "Pass",
                1
            );

            // Test all-args constructor
            Student student3 = new Student(
                "S2001",
                "ICTPRG547",
                new DateTime(2026, 3, 8),
                enrolmentStudent3,
                "Gabriel Velez",
                "gabriel@email.com",
                "0400000000",
                addressStudent3
            );

            Console.WriteLine("student3 (all-args constructor):");
            Console.WriteLine(student3);
            Console.WriteLine();

            Console.WriteLine("=== TESTING PROPERTY ACCESSOR METHODS ===");
            Console.WriteLine();

            student1.StudentID = "S3001";
            student1.StudentProgram = "ICTWEB430";
            student1.StudentDateRegistered = new DateTime(2026, 2, 1);
            student1.StudentEnrolment = enrolmentStudent1;
            student1.PersonName = "Emily Smith";
            student1.PersonEmail = "emily@email.com";
            student1.PersonPhoneNumber = "0433333333";
            student1.PersonAddress = addressStudent1;

            Console.WriteLine("student1 after setting properties:");
            Console.WriteLine("Student ID: " + student1.StudentID);
            Console.WriteLine("Program: " + student1.StudentProgram);
            Console.WriteLine("Date Registered: " + student1.StudentDateRegistered);
            Console.WriteLine("Enrolment: " + student1.StudentEnrolment);
            Console.WriteLine("Name: " + student1.PersonName);
            Console.WriteLine("Email: " + student1.PersonEmail);
            Console.WriteLine("Phone Number: " + student1.PersonPhoneNumber);
            Console.WriteLine("Address: " + student1.PersonAddress);
            Console.WriteLine();

            Console.WriteLine("=== TESTING ToString() on students ===");
            Console.WriteLine();
            Console.WriteLine(student1.ToString());
            Console.WriteLine();
            Console.WriteLine(student2.ToString());
            Console.WriteLine();
            Console.WriteLine(student3.ToString());
            Console.WriteLine();

            Console.WriteLine("=== TESTING Equals() ===");
            Console.WriteLine();

            Student student4 = new Student(
                "S2001",
                "Different Program",
                new DateTime(2025, 1, 1),
                enrolmentStudent4,
                "Another Name",
                "another@email.com",
                "0411111111",
                addressStudent4
            );

            Student student5 = new Student(
                "S5001",
                "ICTPRG547",
                new DateTime(2026, 3, 8),
                enrolmentStudent5,
                "Ana Lopez",
                "ana@email.com",
                "0422222222",
                addressStudent5
            );

            Console.WriteLine("student3:");
            Console.WriteLine(student3);
            Console.WriteLine();

            Console.WriteLine("student4:");
            Console.WriteLine(student4);
            Console.WriteLine();

            Console.WriteLine("student5:");
            Console.WriteLine(student5);
            Console.WriteLine();

            Console.WriteLine("student3.Equals(student4): " + student3.Equals(student4));
            Console.WriteLine("student3.Equals(student5): " + student3.Equals(student5));
            Console.WriteLine("student4 == student5: " + (student4==student5));
            Console.WriteLine();

            Console.WriteLine("=== TESTING GetHashCode() ===");
            Console.WriteLine();

            Console.WriteLine("Student3 and student4 should have the same hash code since they are considered equal based on their StudentID.");
            Console.WriteLine("student3 hash code: " + student3.GetHashCode());
            Console.WriteLine("student4 hash code: " + student4.GetHashCode());
            Console.WriteLine("student5 hash code: " + student5.GetHashCode());
            Console.WriteLine();

            Console.WriteLine("=== TESTING == AND != OPERATORS ===");
            Console.WriteLine();

            Console.WriteLine("student3 == student4: " + (student3 == student4));
            Console.WriteLine("student3 != student5: " + (student3 != student5));
            Console.WriteLine();

            Console.WriteLine("=== TESTING NULL COMPARISONS ===");
            Console.WriteLine();

            Console.WriteLine("Student student6 = null;");
            Console.WriteLine("Student student7 = null;");
            Console.WriteLine();
            Student student6 = null;
            Student student7 = null;

            Console.WriteLine("student6 == student7: " + (student6 == student7));
            Console.WriteLine("student3 == null: " + (student3 == null));
            Console.WriteLine("student3 != null: " + (student3 != null));
            Console.WriteLine();


            // =========================
            // PERSON TESTS
            // =========================
            Console.WriteLine("===== TESTING PERSON CLASS =====");
            Console.WriteLine();

            // Create address object for person 1 and 2
            Address addressPerson1 = new Address(
                "27",
                "Sevilla Avenue",
                "Melbourne",
                "3000",
                "VIC"
            );

            Address addressPerson2 = new Address(
                "18",
                "Valencia street",
                "Adelaide",
                "5000",
                "SA"
            );

            Person person1 = new Person();
            Person person2 = new Person(
                "Carlos Ramirez",
                "carlos.ramirez@email.com",
                "0412345678",
                addressPerson2
            );

            Console.WriteLine("person1 (no-args constructor):");
            Console.WriteLine(person1);
            Console.WriteLine();

            Console.WriteLine("person2 (all-args constructor):");
            Console.WriteLine(person2);
            Console.WriteLine();

            person1.PersonName = "Lucia Fernandez";
            person1.PersonEmail = "lucia.fernandez@email.com";
            person1.PersonPhoneNumber = "0498765432";
            person1.PersonAddress = addressPerson1;

            Console.WriteLine("person1 after using property assessor methods:");
            Console.WriteLine("Name: " + person1.PersonName);
            Console.WriteLine("Email: " + person1.PersonEmail);
            Console.WriteLine("Phone Number: " + person1.PersonPhoneNumber);
            Console.WriteLine("Address: " + person1.PersonAddress);
            Console.WriteLine();

            Console.WriteLine("person1 ToString():");
            Console.WriteLine(person1.ToString());
            Console.WriteLine();


            // =========================
            // ADDRESS TESTS
            // =========================
            Console.WriteLine("===== TESTING ADDRESS CLASS =====");
            Console.WriteLine();

            Address address1 = new Address();
            Address address2 = new Address(
                "12",
                "Granada street",
                "Adelaide",
                "5000",
                "SA"
            );

            Console.WriteLine("address1 (no-args constructor):");
            Console.WriteLine(address1);
            Console.WriteLine();

            Console.WriteLine("address2 (all-args constructor):");
            Console.WriteLine(address2);
            Console.WriteLine();

            address1.AddressStreetNum = "45";
            address1.AddressStreetName = "Cordoba Avenue";
            address1.AddressSuburb = "Glenelg";
            address1.AddressPostcode = "5045";
            address1.AddressState = "SA";

            Console.WriteLine("address1 after using property assessor methods:");
            Console.WriteLine("Street Number: " + address1.AddressStreetNum);
            Console.WriteLine("Street Name: " + address1.AddressStreetName);
            Console.WriteLine("Suburb: " + address1.AddressSuburb);
            Console.WriteLine("Postcode: " + address1.AddressPostcode);
            Console.WriteLine("State: " + address1.AddressState);
            Console.WriteLine();

            Console.WriteLine("address1 ToString():");
            Console.WriteLine(address1.ToString());
            Console.WriteLine();


            // =========================
            // SUBJECT TESTS
            // =========================
            Console.WriteLine("===== TESTING SUBJECT CLASS =====");
            Console.WriteLine();

            Subject subject1 = new Subject();
            Subject subject2 = new Subject(
                "ICTPRG547",
                "Apply Advanced Programming Skills",
                1200.00
            );

            Console.WriteLine("subject1 (no-args constructor):");
            Console.WriteLine(subject1);
            Console.WriteLine();

            Console.WriteLine("subject2 (all-args constructor):");
            Console.WriteLine(subject2);
            Console.WriteLine();

            subject1.SubjectCode = "ICTWEB430";
            subject1.SubjectName = "Produce Server-Side Script for Dynamic Web Pages";
            subject1.SubjectCost = 950.00;

            Console.WriteLine("subject1 after using property assessor methods:");
            Console.WriteLine("Subject Code: " + subject1.SubjectCode);
            Console.WriteLine("Subject Name: " + subject1.SubjectName);
            Console.WriteLine("Subject Cost: " + subject1.SubjectCost);
            Console.WriteLine();

            Console.WriteLine("subject1 ToString():");
            Console.WriteLine(subject1.ToString());
            Console.WriteLine();


            // =========================
            // ENROLMENT TESTS
            // =========================
            Console.WriteLine("===== TESTING ENROLMENT CLASS =====");
            Console.WriteLine();

            Enrolment enrolment1 = new Enrolment();
            Enrolment enrolment2 = new Enrolment(subject1,
                new DateTime(2026, 3, 8),
                "Pass",
                1
            );

            Console.WriteLine("enrolment1 (no-args constructor):");
            Console.WriteLine(enrolment1);
            Console.WriteLine();

            Console.WriteLine("enrolment2 (all-args constructor):");
            Console.WriteLine(enrolment2);
            Console.WriteLine();

            enrolment1.EnrolmentDateEnrolled = new DateTime(2026, 2, 15);
            enrolment1.EnrolmentGrade = "Fail";
            enrolment1.EnrolmentSemester = 2;
            enrolment1.EnrolmentSubject = subject2;

            Console.WriteLine("enrolment1 after using property assessor methods:");
            
            Console.WriteLine("Subject Code: " + enrolment1.EnrolmentSubject);
            Console.WriteLine("Date Enrolled: " + enrolment1.EnrolmentDateEnrolled);
            Console.WriteLine("Grade: " + enrolment1.EnrolmentGrade);
            Console.WriteLine("Semester: " + enrolment1.EnrolmentSemester);
            
            Console.WriteLine();

            Console.WriteLine("enrolment1 ToString():");
            Console.WriteLine(enrolment1.ToString());
            Console.WriteLine();

            


            // =========================
            // debugging UnitTest TESTS
            // =========================

            Student[] students = new Student[]
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

            Console.WriteLine("=== == TESTING UnitTest TESTS on students array == ===");
            Console.WriteLine();
            Console.WriteLine(students[0].ToString());
            Console.WriteLine();
            Console.WriteLine(students[1].ToString());
            Console.WriteLine();
            Console.WriteLine("Students[0]: " + students[0].StudentID + "  //  Students[1]: " + students[1].StudentID);
            Console.WriteLine("students[0] == students[1] " + (students[0] == students[1]));
            Console.WriteLine("students[0] != students[1] " + (students[0] != students[1]));
            Console.WriteLine("students[0] > students[1] " + (students[0] > students[1]));
            Console.WriteLine("students[0] >= students[1] " + (students[0] >= students[1]));
            Console.WriteLine("students[0] < students[1] " + (students[0] < students[1]));
            Console.WriteLine("students[0] <= students[1] " + (students[0] <= students[1]));
            Console.WriteLine();



            // LINEAR SEARCH FOUND
            Student target = students[3];
            int result = Utility.LinearSeachArray(students, target);

            Console.WriteLine("Linear search target found(STU001)....");
            Console.WriteLine("Result: " + result);
            Console.WriteLine();

            // LINEAR SEARCH NOT FOUND
            Student target2 = new Student("STU999", "IT", DateTime.Now, new Enrolment(), "Not Found", "none@email.com", "0499999999", new Address());
            int result2 = Utility.LinearSeachArray(students, target2);
 
            Console.WriteLine("Linear search target NOT found(STU999)....");
            Console.WriteLine("Result: " + result2);
            Console.WriteLine();

            // PRINTING STUDENTS BEFORE SORTING
            Console.WriteLine("Printing students before Selection Sort Ascending... ");
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i].StudentID);

            }

            // SELECTION SORT ASCENDING
            Utility.SelectionSortAscending(students);
            Console.WriteLine();
            Console.WriteLine("Printing students after Selection Sort Ascending... ");

            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i].StudentID);

            }


            // BINARY SEARCH TARGET FOUND
            Student target3 = students[3];
            int result3 = Utility.BinarySearchArray(students, target3);

            Console.WriteLine();
            Console.WriteLine("Binary Search target found (STU004)... ");
            Console.WriteLine("Result: " + result3);

            // BINARY SEARCH TARGET NOT FOUND
            Student target4 = new Student("STU999", "IT", DateTime.Now, new Enrolment(), "Not Found", "none@email.com", "0499999999", new Address());
            int result4 = Utility.BinarySearchArray(students, target4);

            Console.WriteLine();
            Console.WriteLine("Binary Search target NOT found (STU999)... ");
            Console.WriteLine("Result: " + result4);

            // SELECTION SORT DESCENDING
            Utility.SelectionSortDescending(students);
            Console.WriteLine();
            Console.WriteLine("Printing students after Selection Sort Descending... ");
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i].StudentID);

            }

            Console.WriteLine();
            Console.WriteLine("Testing complete. Press any key to exit...");
            Console.ReadKey();



        }
    }
}
