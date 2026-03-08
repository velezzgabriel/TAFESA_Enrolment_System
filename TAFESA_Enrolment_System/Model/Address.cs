using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System.Model
{
    internal class Address
    {
        //constants for all attributes
        const string DEF_STREETNUM = "No streetNum provided";
        const string DEF_STREETNAME = "No streetName provided";
        const string DEF_SUBURB = "No suburb provided";
        const string DEF_POSTCODE = "No postcode provided";
        const string DEF_STATE = "No state provided";

        // attributes
        private string streetNum;
        private string streetName;
        private string suburb;
        private string postcode;
        private string state;


        //no args constructor
        public Address() : this(DEF_STREETNUM, DEF_STREETNAME, DEF_SUBURB, DEF_POSTCODE, DEF_STATE)
        {

        }

        // all args constructor
        public Address (string streetNum, string streetName, string suburb, string postcode, string state)
        {
            this.streetNum = streetNum;
            this.streetName = streetName;
            this.suburb = suburb;
            this.postcode = postcode;
            this.state = state;
        }


        //Property Assessor Methods

        public string AddressStreetNum
        {
            get { return streetNum; }
            set { streetNum = value; }
        }
        public string AddressStreetName
        {
            get { return streetName; }
            set { streetName = value; }
        }
        public string AddressSuburb
        {
            get { return suburb; }
            set { suburb = value; }
        }
        public string AddressPostcode
        {
            get { return postcode; }
            set { postcode = value; }
        }
        public string AddressState
        {
            get { return state; }
            set { state = value; }
        }


        // override ToString
        /// <summary>
        /// Returns a string that represents the address, including the street number, street name, suburb, postcode,
        /// and state in a human-readable format.
        /// </summary>
        /// <returns>A formatted string containing the street number, street name, suburb, postcode, and state of the address.</returns>
        public override string ToString()
        {
            return "Street Number: "+AddressStreetNum + ", Street Name: " + AddressStreetName + ", Suburb: " + AddressSuburb + ", Postcode: " + AddressPostcode + ", State: " + AddressState;
        }


    }
}
