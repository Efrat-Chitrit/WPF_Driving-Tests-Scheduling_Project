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
            set;get;
        }
        private string testerId;
        public string TesterId { set; get; }
        private string traineeId;
        public string TraineeId { set; get; }
        private DateTime date;
        public DateTime Datetime { set; get; }
        private int hour;
        public int Hour { set; get; }
        private Address sourceAddress;
        public Address SourceAddress { set; get; }
        private bool grade;
        public bool Grade { get; set; }
        private string note;
        public string Note { get; set; }
        private MyEnum.TypeOfCar tOfCar; 
        public MyEnum.TypeOfCar TOfCar { get; set; }

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
        public Test(string tester_id, string trainee_id, DateTime _date, int _hour, Address s_address,  MyEnum.TypeOfCar t_car, bool _grade = false, string _note = "")
        {
            
            TesterId = tester_id;
            TraineeId = trainee_id;
            Datetime = _date;
            Hour = _hour;
            SourceAddress = s_address;
            tOfCar = t_car;
            Grade = _grade;
            Note = _note;
            
        }
        public Test() { }
        //{
        //    numOfTest++;
        //    TesterId = tester_id;
        //    TraineeId = trainee_id;
        //    Datetime = _date;
        //    Hour = _hour;
        //    SourceAddress = s_address;
        //    Grade = _grade;
        //    Note = _note;
        //}
    }
}
