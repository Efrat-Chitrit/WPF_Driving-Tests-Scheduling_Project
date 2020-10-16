using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Tester
    {
     
        public string TesterId{ set;get;}
        
        public string TesterLast { set; get; }
      
        public string TesterName { set; get; }
      
        public DateTime TesterBirthDate{ set;get; }
     
        public MyEnum.Gender TesterGender { set; get; }
       
        public string TesterPhone { set; get; }
        private Address address = new Address("", 0, "");
        public Address TesterAddress
        {
            set { address = value; }
            get { return address; }
        }
       
       //years of experience
        public int TesterSeniority { set; get; }
       
        public int TesterMaxTests { set; get; }

        //type of car
        public MyEnum.TypeOfCar TesterProfession { set; get; }

        private bool? [,] workHours;//nullable mattrix


        /// <summary>
        /// gets a matrix and do workhours=matrix
        /// </summary>
        public bool? [,] TesterWorkHours
        { set
            {
                workHours = new bool?[Configuration.TesterDays, Configuration.TesterHours];
                //true=avaliable hour,false=working hour,null=doesn't work at all
                for (int day = 0; day < Configuration.TesterDays; day++)
                {
                    for (int hour = 0; hour < Configuration.TesterHours; hour++)
                    {
                        workHours[day,hour] = value[day,hour];
                    }
                }
            }
            get => workHours;
        }
        
        public int TesterMaxDistance { set; get; }

        /// <summary>
        /// Prints the data on a particular tester
        /// </summary>
        /// <returns>string str - contains the details of the Tester</returns>
        public override string ToString()
        {
            string str = "";
            str += "Tester:" + '\n' + "First Name: " + TesterName + '\n' + "Last Name: " + TesterLast + '\n' + "Id: " + TesterId + '\n' + "Birth date: " + TesterBirthDate + '\n' + "Gender: " + TesterGender + '\n' + "Phone Number: " + TesterPhone + '\n' + "Address: " + TesterAddress + '\n' + "Seniority: " + TesterSeniority + '\n' + "Max number of tests: " + TesterMaxTests + '\n' + "Type of car: " + TesterProfession + '\n' +"Available at: " + '\n' + this.MatrixString()+ "Max distance: " + TesterMaxDistance + '\n';
            return str;
        }

        /// <summary>
        /// Turns the matrix into a string where we can see the exact work hours of the tester
        /// </summary>
        private string MatrixString ()
        {
            bool?[,] mat = TesterWorkHours;
            string str = "";
            for (int i = 0; i < Configuration.TesterDays; i++)
            { 
                str += ((MyEnum.Days)i).ToString()+":";
                for (int j = 0; j < Configuration.TesterHours; j++)
                {
                    if(mat[i,j]==true)
                        str += (j + 9) + ":00-"+(j+10)+":00, ";
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
        public Tester(string _id,string _last,string _name,DateTime _birthDate, MyEnum.Gender _gender, string _phone, Address _address,int _seniority, int _maxTests, MyEnum.TypeOfCar _car, int _distance ,bool ?[,]mat=null)
        {
            TesterId = _id;
            TesterLast = _last;
            TesterName = _name;
            TesterBirthDate = _birthDate;
            TesterGender = _gender;
            TesterPhone = _phone;
            TesterAddress = _address;
            TesterSeniority = _seniority;
            TesterMaxTests = _maxTests;
            TesterProfession = _car;
            TesterMaxDistance = _distance;
            workHours = mat;
        }

        /// <summary>
        /// an empty constractor
        /// </summary>
        /// <param name="id">the tester ID</param>
        public Tester() { }
    }  
}
