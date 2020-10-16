using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using DAL;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Xml;

namespace BL
{


    public class Bl_imp : IBL
    {
        private DAL.IDal dal = DALFactory.GetIdal();
        #region Singleton
        // Singleton design pattern:
        // reference to the single instance of IDal
        private static IBL instance = null;
        private Bl_imp()
        {
            
        }

        public static IBL GetBl()
        {
            if (instance == null)
                instance = new Bl_imp();
            return instance;
        }
        #endregion



 
        #region TesterFunctions
        /// <summary>
        /// adds a tester and confime that it can be added
        /// </summary>
        /// <param name="t">tester to add</param>
        /// <param name="TesterAge">how old he is in years</param>
        /// <param name="TesterMonth">how old he is in months</param>
        /// <param name="TesterDay">how old he is in days</param>
        /// /// <param name="Age">how old he is</param>
        public void AddTester(Tester t)
        {
            TimeSpan Age = DateTime.Now - t.TesterBirthDate;
            if (t.TesterId.Length != 9)
                throw new Exception("ID must have 9 digits");
            if (t.TesterName == "")
                throw new Exception("You must enter a tester's first name");
            if (t.TesterLast == "")
                throw new Exception("You must enter a tester's last name");
            if (t.TesterBirthDate == null)
                throw new Exception("You must enter the birth date of the tester");
            if (t.TesterBirthDate > DateTime.Now)
                throw new Exception("Birth date cannot be in the furture");
            if ((Age.TotalDays / 365) >= Configuration.MinAgeOfTester && (Age.TotalDays / 365)<=Configuration.MaxAgeOfTester)
            {
                //the age in days,we devided it in 365 (days of each year so it will be in years
                try { dal.AddTester(t); }
                catch (Exception e)
                { throw e; }
            }


            else
            {
                if ((Age.TotalDays / 365) > Configuration.MaxAgeOfTester)
                {
                    throw new Exception("You are too old to be a Tester");
                }
                else
                    throw new Exception("You are too young to be a Tester");
            }

        }

        /// <summary>
        /// deletes a tester and confime that it can be deleted
        /// </summary>
        /// <param name="t">tester to delete</param>
        public void DeleteTester(Tester t)
        {
            try
            {
                for (int i = 0; i < Configuration.TesterDays; i++)
                {
                    for (int j = 0; j < Configuration.TesterHours; j++)
                    {
                        if (t.TesterWorkHours[i, j] == false)
                        {
                            throw new Exception("Cannot delete a tester that has tests for this week");
                        }
                    }
                }
                dal.DeleteTester(t);
            }
            catch (Exception e)
            { throw e; }
        }

        /// <summary>
        /// update a tester and confime that it can be updated
        /// </summary>
        /// <param name="t">tester to update</param>
        public void UpdateTester(Tester t)
        {
            try
            {
                dal.UpdateTester(t);
            }
            catch (Exception e)
            { throw e; }
        }
        #endregion
        #region TraineeFunctions

        /// <summary>
        /// adds a trainee and confime that it can be added
        /// </summary>
        /// <param name="t">trainee to add</param>
        /// /// <param name="Age">how old he is</param>
        public void AddTrainee(Trainee t)
        {
            TimeSpan Age = DateTime.Now - t.TraineeBirthDate;
            if (t.TraineeId.Length != 9)
                throw new Exception("ID must have 9 digits");
            if (t.TraineeName == "")
                throw new Exception("You must enter a trainee's first name");
            if (t.TraineeLast == "")
                throw new Exception("You must enter a trainee's last name");
            if (t.TraineeBirthDate == null)
                throw new Exception("You must enter the birth date of the trainee");
            if (t.TraineeBirthDate > DateTime.Now)
                throw new Exception("Birth date cannot be in the furture");
            if ((Age.TotalDays / 365) >= Configuration.MinAgeOfTrainee)
            {
                try
                {
                    dal.AddTrainee(t);
                }
                catch (Exception e)
                { throw e; }
            }
            else
                throw new Exception("You are too young to be a Trainee");
        }

        /// <summary>
        /// deletes a trainee and confirm that it can be deleted
        /// </summary>
        /// <param name="t">trainee to delete</param>
        public void DeleteTrainee(Trainee t)
        {
            try
            {
                dal.DeleteTrainee(t);
            }
            catch (Exception e)
            { throw e; }
        }

        /// <summary>
        /// update a trainee and confime that it can be updated
        /// </summary>
        /// <param name="t">trainee to update</param>
        public void UpdateTrainee(Trainee t)
        {
            try
            { dal.UpdateTrainee(t); }
            catch (Exception e)
            { throw e; }
        }
        #endregion

        #region Tests Functions

        /// <summary>
        /// adds a new test to the list if the student already took the last test more than a week ago or did not tested yet
        /// </summary>
        /// <param name="t">a test to add</param>
        public void AddTest(Test t)
        {
            Trainee trainee = new Trainee();
            bool exists = false; //if the trainee is exists
            foreach (Trainee trainee2 in dal.GetTrainees()) 
            {
                if (trainee2.TraineeId == t.TraineeId)
                {
                    trainee = trainee2;
                    exists = true;
                }
            }
            if (!exists)//the trainee does not exist
            {
                throw new Exception("The trainee does not exist");
            }
            if (exists) //the trainee does exist
            {
                foreach (Test tl in dal.GetTests())//checks if the trainee passed a test on this type of car
                {
                    if (tl.TraineeId == t.TraineeId && tl.Grade == true && tl.TOfCar == t.TOfCar)
                    {
                        throw new Exception("You cannot take a test on this type of viecle because you have passed");
                    }
                }
                if (trainee.TraineeLessons < Configuration.MinNumOfLessons) //checks if the trainee does at least the minimum amount of lessons
                    throw new Exception("You did not do enough lessons");
                bool flag = false; //if the trainee did a test before
                Test lastTest = new Test() { Datetime = new DateTime(0001, 1, 1) };//a fake - the smallest date ever in date picker
                                                                                   // (dal.GetTests()).GetEnumerator() = dal.GetTests()[0];
                foreach (Test oldTest in dal.GetTests()) //the list of tests
                {
                    if (t.TraineeId == oldTest.TraineeId && t.TOfCar == oldTest.TOfCar)//if he took a test before on the same type of car
                    {
                        
                        flag = true;
                        if (oldTest.Datetime > lastTest.Datetime)
                        {
                            //the lates test he did
                            lastTest = oldTest;
                        }
                    }
                }
                if (flag)
                {
                    //if he took a test before on the same type of car
                    lastTest.Datetime.AddDays(Configuration.MinAmountOfTimeBetweenTests);
                    if ((lastTest.Datetime).CompareTo(t.Datetime) == 1) //if the last test's date + 7 days is bigger than the new test to add date it means that 7 days have not passed yet
                        throw new Exception("Cannot do 2 tests in less than 7 days");
                }

                Tester tester2 = new Tester();
                if (t.Datetime<DateTime.Now || (DateTime.Now==t.Datetime && t.Hour<=DateTime.Now.Hour))//if the date is today and the hour already passed, or a date that passed
                {
                    throw new Exception("Cannot add a test for today or a date that passed");
                }

                if ((t.Datetime.Year == DateTime.Now.Year) && (t.Datetime.Month == DateTime.Now.Month) && (int)((t.Datetime - DateTime.Now).Days) <= Configuration.MinAmountOfTimeBetweenTests)// possibility to set a test for week ahead becouse the testers working hours mattrix is just for a week ahead

                {
                    //allows to add a test only if it is in the week that we are at (because the tester's mattrix)
                    int amount = 0; //the amount of tests the tester do in this week
                    bool avaliable = false; //if there is a tester that fits the conditions that we need it will become true

                    foreach (Tester tester in dal.GetTesters())
                    {
                        if (trainee.TraineeVehicle != t.TOfCar)
                            throw new Exception("Cannot add a test on different type of car");

                        if ((tester.TesterWorkHours[(t.Datetime.DayOfWeek).GetHashCode(), (t.Hour - 9).GetHashCode()]).Equals(true) && tester.TesterProfession == trainee.TraineeVehicle )//if the type of car is equal, and the tester is avaliable at this hour
                        {

                            for (int days = 0; days < Configuration.TesterDays; days++) //counts the amount of tests that the tester does this week
                            {
                                for (int hours = 0; hours < Configuration.TesterHours; hours++)
                                {
                                    if (tester.TesterWorkHours[days, hours] == false)
                                    {
                                        //he does tests 
                                        amount++;
                                    }
                                }
                            }
                            if (amount < tester.TesterMaxTests) 
                            {
                                 if (tester.TesterMaxDistance>=Distance(tester.TesterAddress,t.SourceAddress))//calls a function that is the thread, if the distance between those addresses is less or equal to THE TESTER'S  max distance the test shall be added
                                 {
                                    avaliable = true;//there is an avaliave tester 
                                    tester2 = tester;
                                    tester.TesterWorkHours[(t.Datetime.DayOfWeek).GetHashCode(), (t.Hour - 9).GetHashCode()] = false;//the tester will be busy 
                                    UpdateTester(tester); //updates the tester that he have a test - bacause it false
                                    break;//we found a tester that fits what we need
                                }
                            }
                        }
                        if (avaliable)
                        {
                            //gets out of the for each because we found a tester
                            break;
                        }
                    }
                    if (!avaliable)//we didn't found a tester
                        throw new Exception("There are no avaliable tester at that time");
                }

                try
                {
                    //we will add a test
                    t.Grade = false; //didn't pass the test yet
                    t.TesterId = tester2.TesterId;
                    foreach (Test tl in DS.DataSource.testList)
                    {
                        if (t == tl) //checkes if the test is already exist
                        {
                            throw new Exception("The test is already exist");
                        }
                    }
                    trainee.TraineeTest = new StudentTest(t.Datetime, t.Hour); //the date of the test we added is the date of the last test of the trainee
                    trainee.TraineeAmountOfTests++;
                    dal.UpdateTrainee(trainee); //updates the trainee that he have a test 
                    //DS.DataSource.testList.Add(t);
                    dal.AddTest(t); //add the test
                }

                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        /// <summary>
        /// deletes a test and confirm that it can be deleted
        /// </summary>
        /// <param name="t">a test to delete</param>
        public void DeleteTest(Test t)
        {
            try
            {
                dal.DeleteTest(t);
                Tester tester = (from ts in dal.GetTesters()
                              where t.TesterId == ts.TesterId
                              select ts).FirstOrDefault(); //the first tester you fount with this ID, else- puts null
                if (tester!=null)//the tester does exists
                {
                    tester.TesterWorkHours[(t.Datetime.DayOfWeek).GetHashCode(), (t.Hour - 9).GetHashCode()] = true; //he works this hour
                    UpdateTester(tester); //updetes the tester that he works this hour
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// update a test and confime that it can be updated
        /// </summary>
        /// <param name="t">test to update</param>
        public void UpdateTest(Test t)
        {
            try
            {
                dal.UpdateTest(t);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Lists functions
        /// <summary>
        /// the next lists are the lists of the different entities (ישויות)
        /// </summary>
        public List<BE.Tester> GetTesters() { return dal.GetTesters(); }
        public List<BE.Trainee> GetTrainees() { return dal.GetTrainees(); }
        public List<BE.Test> GetTests() { return dal.GetTests(); }
        #endregion

        #region Creative part
        /// <summary>
        /// This function calculates the avarage of students that passed a test this week
        /// </summary>
        /// <returns>avarage</returns>
        public double AvarageOfWeek()
        {
            int passedSum = 0;
            int totalSum = 0;
            foreach (Trainee item in dal.GetTrainees())
            {
                totalSum++;
                if (item.TraineeGrade==true)
                {
                    passedSum++;
                }
            }
            double avg = passedSum / totalSum;
            return avg;
        }
        /// <summary>
        /// this function calculates the number of avialble hours and the number of working hour of the tester so the user can see how many hours the tester is avaliable out of all the hours that he is working
        /// </summary>
        /// <param name="t">tester to check his hours of work</param>
        /// <param name="avaliable">the hours that the tester is avaliable</param>
        /// <param name="workingHours">the amount of hours that he is working</param>
        public void AvaliabilityOftester(Tester t, ref int avaliable, ref int workingHours)
        {
            for (int days = 0; days < Configuration.TesterDays; days++)
            {
                for (int hours = 0; hours < Configuration.TesterHours; hours++)
                {
                    if (t.TesterWorkHours[days, hours] != null)
                    {
                        workingHours++;
                        if (t.TesterWorkHours[days, hours] == true)
                        {
                            avaliable++;
                        }
                    }
                }
            }
        }
        #endregion
        #region Grouping

        /// <summary>
        /// coose a groop of testers by their profession
        /// </summary>
        /// <param name="ordered">determins whether to return the result in a sorted form</param>
        /// <returns></returns>
        public IEnumerable<IGrouping<MyEnum.TypeOfCar,Tester >> TestersByProfession(bool ordered = false)
        {
            IEnumerable<IGrouping<MyEnum.TypeOfCar, Tester>> result;
            if (ordered)//we want the grouping to be ordered
            {
                result = from item in dal.GetTesters()
                         //where (ordered == true)
                         orderby item.TesterProfession
                         group item by item.TesterProfession;
            }
            else
            {

                result = from item in dal.GetTesters()
                         group item by item.TesterProfession;
            }


            return result;
        }

        /// <summary>
        /// coose a groop of trainees by their school
        /// </summary>
        /// <param name="ordered">determins whether to return the result in a sorted form</param>
        /// <returns></returns>
        public IEnumerable<IGrouping<string, Trainee>> TraineesBySchool(bool ordered = false)
        {
            IEnumerable<IGrouping<string, Trainee>> result;
            if (ordered)//we want the grouping to be ordered
            {
                result = from item in dal.GetTrainees()
                        // where (ordered == true)
                         orderby item.TraineeSchool
                         group item by item.TraineeSchool;
            }
            else
            {

                result = from item in dal.GetTrainees()
                         group item by item.TraineeSchool;
            }


            return result;
        }

        /// <summary>
        /// coose a groop of trainees by their teacher
        /// </summary>
        /// <param name="ordered">determins whether to return the result in a sorted form</param>
        /// <returns></returns>
        public IEnumerable<IGrouping<string, Trainee>> TraineesByTeacher(bool ordered = false)
        {
            IEnumerable<IGrouping<string, Trainee>> result;
            if (ordered)//we want the grouping to be ordered
            {
                result = from item in dal.GetTrainees()
                         //where (ordered == true)
                         orderby item.TraineeTeacher
                         group item by item.TraineeTeacher;
            }
            else
            {

                result = from item in dal.GetTrainees()
                         group item by item.TraineeTeacher;
            }


            return result;
        }

        /// <summary>
        /// coose a groop of trainees by their number of tests
        /// </summary>
        /// <param name="ordered">determins whether to return the result in a sorted form</param>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, Trainee>> TraineesByNumOfTests(bool ordered = false)
        {
            IEnumerable<IGrouping<int, Trainee>> result;
            if (ordered)//we want the grouping to be ordered
            {
                result = from item in dal.GetTrainees()
                             //where (ordered == true)
                         orderby item.TraineeAmountOfTests
                         group item by item.TraineeAmountOfTests;
            }

            else
            {
                result = from item in dal.GetTrainees()
                         group item by item.TraineeAmountOfTests;
            }
            return result;
        }
        #endregion
        #region Search
        /// <summary>
        /// this function recieves an id and looks for the trainee according his id
        /// </summary>
        /// <param name="id">id to search</param>
        /// <returns>the matching trainee</returns>
        public Trainee SearchTrainee(string id)
        {
            foreach (Trainee item in dal.GetTrainees())
            {
                if (id == item.TraineeId)
                {
                    return item;
                }
            }
            throw new Exception("The trainee you have been looking for does not exist");
        }
        /// <summary>
        /// this function recieves an id and looks for the tester according his id
        /// </summary>
        /// <param name="id">id to search</param>
        /// <returns>the matching tester</returns>
        public Tester SearchTester(string id)
        {
            foreach (Tester item in dal.GetTesters())
            {
                if (id == item.TesterId)
                {
                    return item;
                }
            }
            throw new Exception("The tester you have been looking for does not exist");
        }
        /// <summary>
        /// this function recieves a number of the test and looks for the test according this number
        /// </summary>
        /// <param name="numOfTest">number of the test that we looking for</param>
        /// <returns>the matching test</returns>
        public Test SearchTest(int numOfTest)
        {
            foreach (Test item in dal.GetTests())
            {
                if (numOfTest == item.NumOfTest)
                {
                    return item;
                }
            }
            throw new Exception("The test you have been looking for does not exist");
        }
        #endregion
        #region Additional Functions 
            /// <summary>
            /// this function recieves a date and a hour and returns all the testers that avaliable at this time
            /// </summary>
            /// <param name="t">date of the test</param>
            /// <param name="h">hour of the test</param>
            /// <returns>a list of all avaliable testers in this time</returns>
        public List<BE.Tester> AvaliableTesters(DateTime t, int h)
        {
            List<Tester> avaliableTesters = new List<Tester>();
            foreach (Tester tst in dal.GetTesters())
            {
                if (tst.TesterWorkHours[((int)t.DayOfWeek),h-9]==true)
                {
                    avaliableTesters.Add(tst);
                }
            }
            return avaliableTesters;
        }
        /// <summary>
        /// this function recieves a bool condition and returns all the tests that  fits the condition
        /// </summary>
        /// <param name="condition">a bool condition</param>
        /// <returns>list of all the tests that fits the condition</returns>
        public List<Test> TestsByCondition(Predicate<Test> condition)
        {
            List<Test> testList = new List<Test>();
            IEnumerable<Test> i = dal.GetTests().Where(c => condition(c));
            foreach (var item in i)
            {
                testList.Add(item); 
            }
            return testList;
        }
        /// <summary>
        /// this function recieves a trainee and returns the amount of tests that he did 
        /// </summary>
        /// <param name="t">the trainee</param>
        /// <returns>amount of tests that the trainee did </returns>
        public int TraineeNumOfTests(BE.Trainee t)
        {
            return t.TraineeAmountOfTests;//we added a field that is promoted when we add tests (there are some students that join this app after they did some tests before
        }

        /// <summary>
        /// this function recieves a trainee and returns if he had passed the test
        /// </summary>
        /// <param name="t">the trainee</param>
        /// <returns>true-if the trainee passed, else-false</returns>
        public bool DeserveDriversLicence(BE.Trainee t)
        {
            foreach(Test test in dal.GetTests())
            {
                if (test.TraineeId.CompareTo(t.TraineeId) == 0 && test.Grade)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// this function recieves a date and returns a list of all the tests that exists in that month
        /// </summary>
        /// <param name="d">the date</param>
        /// <returns>ist of all the tests that exists in that month</returns>
        public List<Test> AllTestsInThisDate(DateTime d)
        {
            List<Test> result= (from t in dal.GetTests()
                      where t.Datetime.Month == d.Month
                      orderby t.Datetime.Day
                      select t).ToList();

            return result;
        }
        
        /// <summary>
        /// calculates the distance between two addresses (using map quest-thread)
        /// </summary>
        /// <param name="addr1">first address</param>
        /// <param name="addr2">second address</param>
        /// <returns>the distance between them</returns>

        private double Distance(Address addr1, Address addr2)
        {
            //string origin = "pisga 45 st. jerusalem"; //or " אחד העם 100 פתח תקווה " etc.
            //string destination = "gilgal 78 st. ramat-gan";//or " ז'בוטינסקי 10 רמת גן " etc. string KEY = @"<PUT_YOUR_KEY_HERE>";

            double result;

           // List<BE.Address> addr = e.Argument as List<BE.Address>;
            //MessageBox.Show(addr[0].ToString());

            string origin = addr1.Street + " " + addr1.NumOfBuilding + " st. " + addr1.City;
            string destination = addr2.Street + " " + addr2.NumOfBuilding + " st. " + addr2.City;
            string KEY = @"Y8yAkZkTWX2AANmEwBcrGb7UIKioTgEB";

            string url = @"https://www.mapquestapi.com/directions/v2/route" +
            @"?key=" + KEY +
            @"&from=" + origin +
            @"&to=" + destination +
            @"&outFormat=xml" +
            @"&ambiguities=ignore&routeType=fastest&doReverseGeocode=false" +
            @"&enhancedNarrative=false&avoidTimedConditions=false";

            //request from MapQuest service the distance between the 2 addresses
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            //the response is given in an XML format
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);
            if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "0")
            //we have the expected answer
            {
                //display the returned distance
                XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                double distInMiles = Convert.ToDouble(distance[0].ChildNodes[0].InnerText);
                // Console.WriteLine("Distance In KM: " + distInMiles * 1.609344);

                result = (distInMiles * 1.609344);

                return result;//if the distance was found it will return

                //display the returned driving time
                // XmlNodeList formattedTime = xmldoc.GetElementsByTagName("formattedTime");
                // string fTime = formattedTime[0].ChildNodes[0].InnerText;
                //  Console.WriteLine("Driving Time: " + fTime);
            }
            else if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "402")
            //we have an answer that an error occurred, one of the addresses is not found
            {
                // Console.WriteLine("an error occurred, one of the addresses is not found. try again.");
                throw new Exception("an error occurred, one of the addresses is not found. try again.");
            }
            else //busy network or other error...
            {
                // Console.WriteLine("We have'nt got an answer, maybe the net is busy...");
                throw new Exception("We have'nt got an answer, maybe the net is busy...");
            }
        }
    }
    #endregion
   
}
