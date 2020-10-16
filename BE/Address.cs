using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// This class represents an adrdress according to: street, number of building, city
    /// </summary>
    public class Address
    {
        public string Street { set; get; }
        public int NumOfBuilding { set; get; }
        public string City { set; get; }
        public Address(string s, int n, string c)
        {
            Street = s;
            NumOfBuilding = n;
            City = c;
        }
        /// <summary>
        /// copy constractor
        /// </summary>
        /// <param name="a"> the address we want to copy </param>
        public Address(Address a)
        {
            Street = a.Street;
            NumOfBuilding = a.NumOfBuilding;
            City = a.City;
        }
        /// <summary>
        /// empty constractor
        /// </summary>
        public Address()
        {

        }
        /// <summary>
        /// Prints the data on a particular address
        /// </summary>
        /// <returns>string str - contains the details of the address</returns>
        public override string ToString()
        {
            string str = "";
            str += "Street: " + Street + ", Number of building: " + NumOfBuilding + ", City: " + City;
            return str;
        }
    }

}
