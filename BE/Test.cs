using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BE
{
    public class Test
    {

        public int NumOfTest
        {
            set; get;
        }
        public string TesterId { set; get; }
        public string TraineeId { set; get; }
        public DateTime Datetime { set; get; }
        public int Hour { set; get; }
        private Address address = new Address("", 0, ""); //xml רק ככה זה עובד ב
        public Address SourceAddress
        {
            set { address = value; }
            get { return address; }
        }
        public bool Grade { get; set; }
        public string Note { get; set; }
        public MyEnum.TypeOfCar TOfCar { get; set; }
        public bool Mirror { get; set; }
        public bool Vinkers { get; set; }
        public bool PathTransition { get; set; }
        public bool ProperSpeed { get; set; }
        public bool ReverseParking { get; set; }
        public bool KeepingDistance { get; set; }


        /// <summary>
        /// deafult constractor of test
        /// </summary>
        /// <param name="tester_id">the tester's ID</param>
        /// <param name="trainee_id">the trainee's ID</param>
        /// <param name="_date">the date of the test</param>
        /// <param name="_hour">the hour of the test</param>
        /// <param name="s_address">the source address</param>
        /// <param name="t_car">the type of car</param>
        /// <param name="_grade">the trainee's grade at the test: passed or failed</param>
        /// <param name="_note">the tester's note to the trainee</param>
        public Test(string tester_id, string trainee_id, DateTime _date, int _hour, Address s_address, MyEnum.TypeOfCar t_car, bool _grade = false, string _note = "",bool _mirror = false, bool _vinkers = false, bool _path = false, bool _speed = false, bool _reverse = false, bool _distance = false)
        {

            TesterId = tester_id;
            TraineeId = trainee_id;
            Datetime = _date;
            Hour = _hour;
            SourceAddress = s_address;
            TOfCar = t_car;
            Grade = _grade;
            Note = _note;
            Mirror = _mirror;
            Vinkers = _vinkers;
            PathTransition = _path;
            ProperSpeed = _speed;
            ReverseParking = _reverse;
            KeepingDistance = _distance;

        }
        /// <summary>
        /// Prints the data on a particular Test
        /// </summary>
        /// <returns>string str - contains the details of the Test</returns>
        public override string ToString()
        {
            string str = "";
            str += "tester id:" + TesterId + '\n' + "trainee id:" + TraineeId + '\n' + "date:" + Datetime.AddHours(Hour) + "\n"  + "address:" +'\n'+ SourceAddress + '\n'+ "Grade:"+ Grade;
            if (Note != "")
            {
                str += '\n' + "Note:" + '\n' + Note;
            }
            return str;
        }
        /// <summary>
        /// empty constractor
        /// </summary>
        public Test() { }
       
    }
}
