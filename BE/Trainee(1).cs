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
        public string traineeId
        {
            set
            {
                if (value.Length == 9)
                    id = value;
                else throw new Exception("incorrect ID");
            }
            get => id;
        }
        private string last;
        public string traineeLast { set; get; }
        private string name;
        public string traineeName { set; get; }
        private DateTime birthDate;
        public DateTime traineeBirthDate
        {
            //  get => birthDate;
            set; get;
        }
        private bool grade;
        public bool TraineeGrade { set; get; }
        private MyEnum.Gender _gender;
        public MyEnum.Gender traineeGender { set; get; }
        private int telephone;
        public int traineePhone { set; get; }
        private Address address;
        public Address traineeAddress { set; get; }
        private MyEnum.TypeOfCar viecle; //type of car
        public MyEnum.TypeOfCar traineeViecle { set; get; }
        private MyEnum.GearBox _gear;
        public MyEnum.GearBox traineeGear { set; get; }
        private string school;
        public string traineeSchool { set; get; }
        private string teacher;
        public string traineeTeacher { set; get; }
        private int numOfLessons;
        public int traineeLessons { set; get; }
        private StudentTest date;
        public StudentTest TraineeTest { set; get; }
        private int traineeAmountOfTests;
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
        public override string ToString()
        {
            string str = "";
            str += "Trainee:" + '\n' + "First Name: " + traineeName + '\n' + "Last Name: " + traineeLast + '\n' + "Id: " + traineeId + '\n' + "Birth date: " + traineeBirthDate + '\n' + "Gender: " + traineeGender + '\n' + "Phone Number: " + traineePhone + '\n' + "Address: " + traineeAddress + '\n' + "Type of car: " + traineeViecle + '\n' + "Type of gear box: " + traineeGear + '\n' + "School name: " + traineeSchool + '\n' + "Teacher name: " + traineeTeacher + '\n'+"Number of lessons: "+traineeLessons  +'\n' + "Tnumber of tests: " + TraineeAmountOfTests+'\n' +"Is passed:"+'\n'+grade+'\n';
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
        public Trainee(string _id, string _last, string _name, DateTime _Bday, MyEnum.Gender _gender, int _phone, Address _address, MyEnum.TypeOfCar _car, MyEnum.GearBox _gear, string _school, string _teacher, int _nOfLassons, int _nOfTests=0 )
        {
            traineeId = _id;
            traineeLast = _last;
            traineeName = _name;
            traineeBirthDate = _Bday;
            traineeGender = _gender;
            traineePhone = _phone;
            traineeAddress = _address;
            traineeViecle = _car;
            traineeGear = _gear;
            traineeSchool = _school;
            traineeTeacher = _teacher;
            traineeLessons = _nOfLassons;
            traineeAmountOfTests = _nOfTests;
        }

        /// <summary>
        /// an empty constractor
        /// </summary>
        /// <param name="id">the trainee's ID</param>
        public Trainee(string id = "000000000") { }
        //{
        //    traineeId = id;
        //    traineeName = traineeLast = "";
        //    traineeBirthDate = new DateTime(01,01,1997);
        //    traineeGender = MyEnum.Gender.female;
        //    traineePhone = 1234567890;
        //    traineeAddress = new Address("Kishon",9,"Nazareth Illit");
        //    traineeViecle = MyEnum.TypeOfCar.privateCar;
        //    traineeGear = MyEnum.GearBox.automatic;
        //    traineeSchool = "school";
        //    traineeTeacher = "teacher";
        //    traineeLessons = 0;
        //}
    }
}
