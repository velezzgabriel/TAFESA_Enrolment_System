using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System.Model
{
    internal class Enrolment
    {

        // constants for all attributes
        static Student DEF_STUDENTID = new Student();
        static Subject DEF_SUBJECTCODE = new Subject();
        static DateTime DEF_DATEENROLLED = DateTime.Now;
        const string DEF_GRADE = "No grade provided";
        const int DEF_SEMESTER = 0;


        // attributes
        private Student studentID; //fk
        private Subject subjectCode; // fk
        private DateTime dateEnrolled;
        private string grade;
        private int semester;


        // no args constructor
        public Enrolment() : this(DEF_STUDENTID, DEF_SUBJECTCODE, DEF_DATEENROLLED, DEF_GRADE, DEF_SEMESTER)
        {

        }

        // all args constructor
        public Enrolment(Student studentID, Subject subjectCode, DateTime dateEnrolled, string grade, int semester)
        {
            this.studentID = studentID;
            this.subjectCode = subjectCode;
            this.dateEnrolled = dateEnrolled;
            this.grade = grade;
            this.semester = semester;
        }

        // Property Assessor Methods
        public Student EnrolmentStudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }
        public Subject EnrolmentSubjectCode
        {
            get { return subjectCode; }
            set { subjectCode = value; }
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
            return "Student ID: " + EnrolmentStudentID + ", Subject Code: " + EnrolmentSubjectCode + ", Date Enrolled: " + EnrolmentDateEnrolled + ", Grade: " + EnrolmentGrade + ", Semester: " + EnrolmentSemester;
        }


    }
}
