using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Trainee
    {
        private string id;
        

        public string TraineeId
        {
            set { id = value; }
            get { return id; }
        }

        public string TraineeLast { set; get; }

        public string TraineeName { set; get; }

        public DateTime TraineeBirthDate
        {
            set; get;
        }
        public bool TraineeGrade { set; get; }
        public MyEnum.Gender TraineeGender { set; get; }
        public string TraineePhone { set; get; }
        
        private Address address=new Address("",0,"");
        public Address TraineeAddress
        {
            set { address = value; }
            get { return address; } }
        public MyEnum.TypeOfCar TraineeVehicle { set; get; }//type of car
        public MyEnum.GearBox TraineeGear { set; get; }
        public string TraineeSchool { set; get; }
        public string TraineeTeacher { set; get; }
        public int TraineeLessons { set; get; }
        public StudentTest TraineeTest { set; get; }
        public int TraineeAmountOfTests { set; get; }
        //public DateTime Datetime { set; get; }
        //private int hour;
        //public int Hour { set; get; }
        //private List <> traineeTests;
        //public StudentTest TraineeTests
        //{ set => traineeTests.Add(value); get => traineeTests. }


        /// <summary>
        /// Prints the data on a particular trainee
        /// </summary>
        /// <returns>string str - contains the details of the Trainee</returns>
        public override string ToString()
        {
            string str = "";
            str += "Trainee:" + '\n' + "First Name: " + TraineeName + '\n' + "Last Name: " + TraineeLast + '\n' + "Id: " + TraineeId + '\n' + "Birth date: " + TraineeBirthDate + '\n' + "Gender: " + TraineeGender + '\n' + "Phone Number: " + TraineePhone + '\n' + "Address: " + TraineeAddress.ToString() + '\n' + "Type of car: " + TraineeVehicle + '\n' + "Type of gear box: " + TraineeGear + '\n' + "School name: " + TraineeSchool + '\n' + "Teacher name: " + TraineeTeacher + '\n' + "Number of lessons: " + TraineeLessons + '\n' + "number of tests: " + TraineeAmountOfTests + '\n' + "Is passed:" + '\n' + TraineeGrade + '\n' ;
            if (TraineeTest.GetDate!=null) //if the date exists
            {
                str += "Student last test: " + TraineeTest.GetDate + ", " + TraineeTest.GetHour + '\n';
            }
            return str;
        }

        /// <summary>
        /// deafult constractor of trainee
        /// </summary>
        /// <param name="_id">the trainee's ID</param>
        /// <param name="_last">the trainee's last name</param>
        /// <param name="_name">the trainee's first name</param>
        /// <param name="_Bday">the trainee's birth date</param>
        /// <param name="_gender">the trainee's gender</param>
        /// <param name="_phone">the trainee's phone</param>
        /// <param name="_address">the trainee's address</param>
        /// <param name="_car">the trainee's type of car</param>
        /// <param name="_gear">the trainee's type of gear box</param>
        /// <param name="_school">the trainee's school</param>
        /// <param name="_teacher">the trainee's teacher</param>
        /// <param name="_nOfLassons">the trainee's number of lessons</param>
        /// <param name="__nOfTests">the trainee's number of tests</param>
        public Trainee(string _id, string _last, string _name, DateTime _Bday, MyEnum.Gender _gender, string _phone, Address _address, MyEnum.TypeOfCar _car, MyEnum.GearBox _gear, string _school, string _teacher, int _nOfLassons, int _nOfTests = 0)
        {
            TraineeId = _id;
            TraineeLast = _last;
            TraineeName = _name;
            TraineeBirthDate = _Bday;
            TraineeGender = _gender;
            TraineePhone = _phone;
            TraineeAddress = _address;
            TraineeVehicle = _car;
            TraineeGear = _gear;
            TraineeSchool = _school;
            TraineeTeacher = _teacher;
            TraineeLessons = _nOfLassons;
            TraineeAmountOfTests = _nOfTests;
        }
        
        /// <summary>
        /// an empty constractor
        /// </summary>
        /// <param name="id">the trainee's ID</param>
        public Trainee() { }
    }
}
