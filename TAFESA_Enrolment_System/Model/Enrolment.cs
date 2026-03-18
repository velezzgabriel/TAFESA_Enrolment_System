using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System.Model
{
    internal class Enrolment
    {

        // constants for non-object attributes      
        const string DEF_GRADE = "No grade provided";
        const int DEF_SEMESTER = 0;


        // attributes
        
        private Subject subject; // fk
        private DateTime dateEnrolled;
        private string grade;
        private int semester;


        // no args constructor
        public Enrolment() : this(new Subject(), DateTime.Now, DEF_GRADE, DEF_SEMESTER)
        {

        }

        // all args constructor
        public Enrolment(Subject subject, DateTime dateEnrolled, string grade, int semester)
        {
            
            EnrolmentSubject = subject;
            EnrolmentDateEnrolled = dateEnrolled;
            EnrolmentGrade = grade;
            EnrolmentSemester = semester;
        }

        // Property Assessor Methods
 
        public Subject EnrolmentSubject
        {
            get { return subject; }
            set { subject = value; }
        }
        public DateTime EnrolmentDateEnrolled
        {
            get { return dateEnrolled; }
            set { dateEnrolled = value; }
        }
        public string EnrolmentGrade
        {
            get { return grade; }
            set { grade = value; }
        }
        public int EnrolmentSemester
        {
            get { return semester; }
            set { semester = value; }
        }

        // override ToString
        /// <summary>
        /// Returns a string that represents the enrollment details, including the student ID, subject code, enrollment
        /// date, grade, and semester.
        /// </summary>
        /// <returns>A formatted string containing the student ID, subject code, enrollment date, grade, and semester for the
        /// enrollment.</returns>
        public override string ToString()
        {
            return "Subject: " + EnrolmentSubject + ", Date Enrolled: " + EnrolmentDateEnrolled + ", Grade: " + EnrolmentGrade + ", Semester: " + EnrolmentSemester;
        }


    }
}
