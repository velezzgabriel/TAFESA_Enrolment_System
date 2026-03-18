using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System.Model
{
    internal class Subject
    {
        // constants for attributes
        const string DEF_SUBJECTCODE = "No subject code provided";
        const string DEF_SUBJECTNAME = "No subject name provided";
        const double DEF_COST = 0.0;


        // attributes
        private string subjectCode;
        private string subjectName;
        private double cost;

          
        // no args constructor
        public Subject() : this(DEF_SUBJECTCODE, DEF_SUBJECTNAME, DEF_COST)
        {

        }

        // all args constructor
        public Subject(string subjectCode, string subjectName, double cost)
        {
            SubjectCode = subjectCode;
            SubjectName = subjectName;
            SubjectCost = cost;
        }

        // Property Assessor Methods
        public string SubjectCode
        {
            get { return subjectCode; }
            set { subjectCode = value; }
        }
        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }
        public double SubjectCost
        {
            get { return cost; }
            set { cost = value; }
        }

        // override ToString
        /// <summary>
        /// Returns a string that represents the subject, including its code, name, and cost.
        /// </summary>
        /// <returns>A string in the format "Subject Code: {SubjectCode}, Subject Name: {SubjectName}, Cost: {SubjectCost}" that
        /// describes the subject.</returns>
        public override string ToString()
        {
            return "Subject Code: " + SubjectCode + ", Subject Name: " + SubjectName + ", Cost: " + SubjectCost;
        }
    }
}
