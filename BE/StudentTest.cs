using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// a struct for comfortable using, holds the time of the student's last test
    /// </summary>
    public struct StudentTest
    {
        int hour;
        //allows access to the data of the struct

        public DateTime GetDate { set; get; }
  

        public int GetHour
        {
            get { return hour; }
            set { hour = value; }
        }

        /// <summary>
        /// constractor with parameters
        /// </summary>
        /// <param name="t">date</param>
        /// <param name="h">hour</param>
        public StudentTest(DateTime t, int h) 
        {
            GetDate = t;
            hour = h;
        }
        /// <summary>
        /// this function will check if the tests are on the same time
        /// </summary>
        /// <param name="t">StudentTest to compare with</param>
        /// <returns></returns>
        public bool IsEqual(StudentTest t)
        {
            return (this.hour == t.hour && this.GetDate == t.GetDate);
        }

        /// <summary>
        /// this function will check if the first test is bigger than the second
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsBigger(StudentTest t)
        {
            if (this.GetDate > t.GetDate) return true;
            else
            {
                if (this.GetDate == t.GetDate)
                    if (this.hour > t.hour)
                        return true;
                return false;
            }
        }
    }

}
