using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System.Model
{
    internal class Person
    {
        // constants for non-object attributes
        protected const string DEF_NAME = "No name provided";
        protected const string DEF_EMAIL = "No email provided";
        protected const string DEF_PHONENUMBER = "No phone number provided";
        


        // attributes
        private string name;
        private string email;
        private string phoneNumber;
        private Address address; 


        // no args constructor
        public Person() : this(DEF_NAME, DEF_EMAIL, DEF_PHONENUMBER, new Address())
        {

        }

        // all args constructor
        public Person(string name, string email, string phoneNumber, Address address)
        {
            PersonName = name;
            PersonEmail = email;
            PersonPhoneNumber = phoneNumber;
            PersonAddress = address;
        }

        // Property Assessor Methods
        public string PersonName
        {
            get { return name; }
            set { name = value; }
        }
        public string PersonEmail
        {
            get { return email; }
            set { email = value; }
        }
        public string PersonPhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public Address PersonAddress
        {
            get { return address; }
            set { address = value; }
        }

        // override ToString
        /// <summary>
        /// Returns a string that contains the person's name, email address, phone number, and address in a formatted,
        /// human-readable form.
        /// </summary>
        /// <returns>A string representation of the person that includes their name, email address, phone number, and address.</returns>
        public override string ToString()
        {
            return "Name: " + PersonName + ", Email: " + PersonEmail + ", Phone Number: " + PersonPhoneNumber + ", Address: " + PersonAddress;
        }
    }
}
