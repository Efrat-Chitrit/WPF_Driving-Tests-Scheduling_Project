using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Tester
    {
        private string id;
        public string testerId{ set;get;}
        private string last;
        public string testerLast { set; get; }
        private string name;
        public string testerName { set; get; }
        private DateTime birthDate;
        public DateTime testerBirthDate{ set;get; }
        private MyEnum.Gender _gender;
        public MyEnum.Gender testerGender { set; get; }
        private int telephone;
        public int testerPhone { set; get; }
        private Address address;
        public Address testerAddress { set; get; }
        private int seniority;//years of experience
        public int testerSeniority { set; get; }
        private int maxTests;
        public int testerMaxTests { set; get; }
        private MyEnum.TypeOfCar profession; //type of car
        public MyEnum.TypeOfCar testerProfession { set; get; }
        private bool? [,] workHours;//
        /// <summary>
        /// gets a matrix and do workhours=matrix
        /// </summary>
        public bool? [,] testerWorkHours
        { set
            {
                workHours = new bool?[5, 7];
                //0=avaliable hour,1=working hour,null=doesn't work at all
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        workHours[i,j] = value[i,j];
                    }
                }
            }
            get => workHours;
        }

        private int maxDistance;
        public int testerMaxDistance { set; get; }

        /// <summary>
        /// Prints the data on a particular tester
        /// </summary>
        public override string ToString()
        {
            string str = "";
            str += "Tester:" + '\n' + "First Name: " + testerName + '\n' + "Last Name: " + testerLast + '\n' + "Id: " + testerId + '\n' + "Birth date: " + testerBirthDate + '\n' + "Gender: " + testerGender + '\n' + "Phone Number: " + testerPhone + '\n' + "Address: " + testerAddress + '\n' + "Seniority: " + testerSeniority + '\n' + "Max number of tests: " + testerWorkHours + '\n' + "Type of car: " + testerProfession + '\n' +"Available at: " + '\n' + this.MatrixString()+ "Max distance: " + testerMaxDistance + '\n';
            return str;
        }

        /// <summary>
        /// Turns the matrix into a string where we can see the exact work hours of the tester
        /// </summary>
        private string MatrixString ()
        {
            bool?[,] mat = testerWorkHours;
            string str = "";
            for (int i = 0; i < 5; i++)
            { 
                str += ((MyEnum.Days)i).ToString()+":";
                for (int j = 0; j < 7; j++)
                {
                    str += (j + 9) + ":00 , ";
                }
                str += '\n';
            }
            return str;
        }

        /// <summary>
        /// deafult constractor of the tester
        /// </summary>
        /// <param name="_id">the tester's ID</param>
        /// <param name="_last">the tester's last name</param>
        /// <param name="_name">the tester's first name</param>
        /// <param name="_birthDate">the tester's birth date</param>
        /// <param name="_gender">the tester's gender</param>
        /// <param name="_phone">the tester's number of phone</param>
        /// <param name="_address">the tester's address</param>
        /// <param name="_seniority">the tester's seniority</param>
        /// <param name="_maxTests">the tester's number of maximum tests</param>
        /// <param name="_car">the tester's profession</param>
        /// <param name="_distance">the tester's number of maximum distance</param>
        /// <param name="mat">the tester's mattrix of work hours</param>
        public Tester(string _id,string _last,string _name,DateTime _birthDate, MyEnum.Gender _gender, int _phone, Address _address,int _seniority, int _maxTests, MyEnum.TypeOfCar _car, int _distance ,bool ?[,]mat=null)
        {
            testerId = _id;
            testerLast = _last;
            testerName = _name;
            testerBirthDate = _birthDate;
            testerGender = _gender;
            testerPhone = _phone;
            testerAddress = _address;
            testerSeniority = _seniority;
            testerMaxTests = _maxTests;
            testerProfession = _car;
            testerMaxDistance = _distance;
            workHours = mat;
        }

        /// <summary>
        /// an empty constractor
        /// </summary>
        /// <param name="id">the tester ID</param>
        public Tester(string id = "000000000") { }
        //{
        //    testerId = id;
        //    testerName = testerLast = "";
        //    testerBirthDate = new DateTime(01, 01, 1997);
        //    testerGender = MyEnum.Gender.female;
        //    testerPhone = 1234567890;
        //    testerAddress = new Address("Kishon", 9, "Nazareth Illit");
        //    testerSeniority = 0;
        //    testerMaxTests = 0;
        //    testerProfession = MyEnum.TypeOfCar.privateCar;
        //    testerMaxDistance = 0;
        //    workHours = new bool[5, 7];
        //}
    }  
}
