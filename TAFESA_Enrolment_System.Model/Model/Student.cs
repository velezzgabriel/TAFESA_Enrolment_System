using System;

namespace TAFESA_Enrolment_System.Model
{
    public class Student: Person  , IComparable , IComparable<Student>
    {

        // constants for all attributes
        const string DEF_STUDENTID = "No student ID provided";
        const string DEF_PROGRAM = "No program provided";
        
        


        // attributes
        private string studentID;
        private string program;
        private DateTime dateRegistered;
        private Enrolment enrolment;


        // no args constructor
        public Student() : this(DEF_STUDENTID, DEF_PROGRAM, DateTime.Now, new Enrolment(), DEF_NAME, DEF_EMAIL, DEF_PHONENUMBER, new Address())
        {
        }

        // constructor with only studentID as an argument
        public Student(string studentID) : this(studentID, DEF_PROGRAM, DateTime.Now,new Enrolment(), DEF_NAME, DEF_EMAIL, DEF_PHONENUMBER, new Address())
        {
        }

        // all args constructor
        public Student(string studentID, string program, DateTime dateRegistered, Enrolment enrolment, string name, string email, string phoneNumber, Address address)
    : base(name, email, phoneNumber, address)
        {
            StudentID = studentID;
            StudentProgram = program;
            StudentDateRegistered = dateRegistered;
            StudentEnrolment = enrolment;
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

        public Enrolment StudentEnrolment
        {
            get { return enrolment; }
            set { enrolment = value; }
        }


        /// <summary>
        /// Returns a string that represents the current student, including their ID, program, registration date, name,
        /// email, phone number, and address.
        /// </summary>
        /// <returns>A formatted string containing the student's details, suitable for display or logging purposes.</returns>
        public override string ToString()
        {
            return base.ToString() + ", Student ID: " + StudentID + ", Program: " + StudentProgram + ", Date Registered: " + StudentDateRegistered + ", Enrolment: " + StudentEnrolment;

        }



        /// <summary>
        /// Determines whether the specified object is equal to the current Student instance based on the StudentID
        /// property.
        /// </summary>
        /// <remarks>This method overrides Object.Equals to provide value equality for Student objects
        /// based on their StudentID. Use this method to compare Student instances for logical equality rather than
        /// reference equality.</remarks>
        /// <param name="obj">The object to compare with the current Student instance. This parameter can be another Student object or
        /// null.</param>
        /// <returns>true if the specified object is a Student and has the same StudentID as the current instance; otherwise,
        /// false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType())
                return false;

            Student other = (Student)obj;
            return StudentID == other.StudentID;
        }





        /// <summary>
        /// Returns a hash code for the current instance based on the value of the StudentID property.  
        /// </summary>
        /// <remarks>This override ensures that the hash code is consistent with the equality comparison
        /// for StudentID. Do not modify the StudentID property while the object is used as a key in a hash-based
        /// collection, as this may lead to unexpected behavior.</remarks>
        /// <returns>A 32-bit signed integer hash code derived from the StudentID property, or zero if StudentID is null.</returns>
        public override int GetHashCode()
        {
            return StudentID == null ? 0 : StudentID.GetHashCode();
        }




        /// <summary>
        /// Determines whether two Student instances are considered equal based on their StudentID values.
        /// </summary>
        /// <remarks>This operator first checks for reference equality. If both references are null, they
        /// are considered equal. If only one is null, they are not equal. Otherwise, equality is determined by
        /// comparing the StudentID property of each instance.</remarks>
        /// <param name="s1">The first Student instance to compare, or null.</param>
        /// <param name="s2">The second Student instance to compare, or null.</param>
        /// <returns><see langword="true"/> if both Student instances are equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(Student s1, Student s2)
        {
            return object.Equals(s1, s2);
        }



        /// <summary>
        /// Determines whether two instances of the <see cref="Student"/> class are not equal.
        /// </summary>
        /// <remarks>This operator overload provides a way to compare two <see cref="Student"/> objects
        /// for inequality by negating the result of the equality operator.</remarks>
        /// <param name="s1">The first <see cref="Student"/> instance to compare.</param>
        /// <param name="s2">The second <see cref="Student"/> instance to compare.</param>
        /// <returns>Returns <see langword="true"/> if the two instances are not equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(Student s1, Student s2)
        {
            return !object.Equals(s1, s2);
        }


        /// <summary>
        /// Determines whether two specified objects are equal.
        /// </summary>
        /// <remarks>This method first checks for reference equality. If both objects are null, they are
        /// considered equal. If only one is null, they are not equal. If both are non-null, the method calls the Equals
        /// method of the first object to determine equality.</remarks>
        /// <param name="obj1">The first object to compare. This parameter can be null.</param>
        /// <param name="obj2">The second object to compare. This parameter can be null.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        //public static bool Equals(object obj1, object obj2)
        //{
        //    if (obj1 == obj2)
        //        return true;
        //    if (obj1 == null || obj2 == null)
        //        return false;
        //    else
        //        return obj1.Equals(obj2);
        //}



        // Implementation of IComparable
        public int CompareTo(object other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other), "Object to compare cannot be null.");
            if ( !(other is Student))
                throw new ArgumentException("Object must be of type Student.", nameof(other));
           
            return CompareTo((Student)other);
        }

        // Implementation of IComparable<Student>
        public int CompareTo(Student other)
        {
            if (other == null)
                return 1;  // null sorts before any real student

            if (StudentID == null && other.studentID == null)
                return 0;

            if (StudentID == null)
                return -1;

            return StudentID.CompareTo(other.studentID);
        }

              
        public static bool operator < (Student left, Student right)
        {
            if (ReferenceEquals(left, null))
            {
                return !ReferenceEquals(right, null);
            }

            return left.CompareTo(right) < 0;
        }

        public static bool operator > (Student left, Student right)
        {
            if (ReferenceEquals(left, null))
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        public static bool operator <= (Student left, Student right)
        {
            if (ReferenceEquals(left, null))
            {
                return true;
            }

            return !(left.CompareTo(right) > 0);
        }

        public static bool operator >= (Student left, Student right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return !(left.CompareTo(right) < 0);
        }


        }

}
