using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public struct Address
    {
        string street;
        int numOfBuilding;
        string city;
        public Address(string s, int n, string c)
        {
            street = s;
            numOfBuilding = n;
            city = c;
        }
        //public Address() { }
    }
    /// <summary>
    /// a struct for comfortable using, holds the time of the student's test
    /// </summary>
    public struct StudentTest
    {
        DateTime date;
        int hour;
        public StudentTest(DateTime t, int h)
        {
            date = t;
            hour = h;
        }

        //allows access to the data of the struct
        public DateTime GetDate()
        {
            return date;
        }
        public int GetHour()
        {
            return hour;
        }
        /// <summary>
        /// this function will check if the tests are on the same time
        /// </summary>
        /// <param name="t">StudentTest to compare with</param>
        /// <returns></returns>
        public bool IsEqual(StudentTest t)
        {
            return (this.hour == t.hour && this.date == t.date);
        }
        /// <summary>
        /// this function will check if the first test is bigger than the second
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsBigger(StudentTest t)
        {
            if( this.date > t.date) return true;
            else
            {
                if (this.date == t.date)
                    if (this.hour > t.hour)
                        return true;
                return false;
            }
        }
    }
    public class BE
    {
       
    }
}
