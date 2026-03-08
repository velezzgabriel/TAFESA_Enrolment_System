using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System.Model
{
    internal class Student: Person
    {

        // constants for all attributes
        const string DEF_STUDENTID = "No student ID provided";
        const string DEF_PROGRAM = "No program provided";
        static DateTime DEF_DATEREGISTERED = DateTime.Now;


        // attributes
        private string studentID;
        private string program;
        private DateTime dateRegistered;


        // no args constructor
        public Student() : this(DEF_STUDENTID, DEF_PROGRAM, DEF_DATEREGISTERED, DEF_NAME, DEF_EMAIL, DEF_PHONENUMBER, DEF_ADDRESS)
        {

        }

        // constructor with only studentID as an argument
        public Student(string studentID) : this(studentID, DEF_PROGRAM, DEF_DATEREGISTERED, DEF_NAME, DEF_EMAIL, DEF_PHONENUMBER, DEF_ADDRESS)
        {

        }

        // all args constructor
        public Student(string studentID, string program, DateTime dateRegistered,
               string name, string email, string phoneNumber, string address)
    : base(name, email, phoneNumber, address)
        {
            this.studentID = studentID;
            this.program = program;
            this.dateRegistered = dateRegistered;
        }



        // Property Assessor Methods
        public string StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }
        public string StudentProgram
        {
            get { return program; }
            set { program = value; }
        }
        public DateTime StudentDateRegistered
        {
            get { return dateRegistered; }
            set { dateRegistered = value; }
        }


        // override ToString
        public override string ToString()
        {
            return "Student ID: " + StudentID + ", Program: " + StudentProgram + ", Date Registered: " + StudentDateRegistered + ", Name: " + PersonName + ", Email: " + PersonEmail + ", Phone Number: " + PersonPhoneNumber + ", Address: " + PersonAddress;

        }


        //override the Equals( ) methods using appropriate properties
        public override bool Equals(object obj)
        {
            if (obj is Student other)
            {
                return this.StudentID == other.StudentID;
            }

            return false;
        }

        // override GetHashCode( ) method
        public override int GetHashCode()
        {
            return StudentID == null ? 0 : StudentID.GetHashCode();
        }

        // overload == operator
        public static bool operator ==(Student s1, Student s2)
        {
            if (ReferenceEquals(s1, s2))
                return true;
            if (ReferenceEquals(s1, null) || ReferenceEquals(s2, null))
                return false;
            return s1.StudentID == s2.StudentID;
        }

        // overload != operator
        public static bool operator !=(Student s1, Student s2)
        {
            return !(s1 == s2);
        }

    }

}
