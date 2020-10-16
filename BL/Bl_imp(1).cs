using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using DAL;
namespace BL
{


    internal class Bl_imp : IBL
    {


        #region Singelton
       
        DAL.Idal dal;
        #endregion
       
        #region Constructor
        public Bl_imp()
        {
            dal = DALFactory.GetIdal();
            DS.DataSource.initializeList();
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
            TimeSpan Age = DateTime.Now - t.testerBirthDate;
            if (t.testerId.Length != 9)
                throw new Exception("ID must have 9 digits");
            if (t.testerName == "")
                throw new Exception("You must enter a tester's first name");
            if (t.testerLast == "")
                throw new Exception("You must enter a tester's last name");
            if (t.testerBirthDate == null)
                throw new Exception("You must enter the birth date of the tester");
            if (t.testerBirthDate > DateTime.Now)
                throw new Exception("Birth date cannot be in the furture");
            if ((Age.TotalDays / 365) >= Configuration.MinAgeOfTester)
            {//the age in days,we devided it in 365 (days of each year so it will be in years
                try { dal.AddTester(t); }
                catch (Exception e)
                { throw e; }
            }
            

            else
                throw new Exception("You are too young to be a Tester");

        }

        /// <summary>
        /// deletes a tester and confime that it can be deleted
        /// </summary>
        /// <param name="t">tester to delete</param>
        public void DeleteTester(Tester t)
        {
            try
            {
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
            TimeSpan Age = DateTime.Now - t.traineeBirthDate;
            if (t.traineeId.Length != 9)
                throw new Exception("ID must have 9 digits");
            if (t.traineeName == "")
                throw new Exception("You must enter a trainee's first name");
            if (t.traineeLast == "")
                throw new Exception("You must enter a trainee's last name");
            if (t.traineeBirthDate == null)
                throw new Exception("You must enter the birth date of the trainee");
            if (t.traineeBirthDate > DateTime.Now)
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
        /// deletes a trainee and confime that it can be deleted
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
            foreach (Trainee trainee2 in dal.GetTrainees())
            {
                if (trainee2.traineeId == t.TraineeId)
                {
                    if (trainee2.traineeLessons < Configuration.MinNumOfLessons)
                        throw new Exception("You did not do enough lessons");
                }
            }
            foreach (Tester tester2 in dal.GetTesters())
            {
                if (tester2.testerId == t.TesterId)
                {
                    int amount = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        for (int k = 0; k < 7; k++)
                        {
                            if (tester2.testerWorkHours[i, k] == true)
                            {
                                amount++;
                            }
                        }
                    }
                    if (amount >= tester2.testerMaxTests)
                        throw new Exception("Tester reached the maximum amount of tests this week." + '\n' +
                            "You cannot take the test with this tester");
                }
                else throw new Exception("Tester does not exsist");
            }

            bool flag = false;
            Test temp = t;
            //int min = t.traineeId;
            foreach (Test oldTest in dal.GetTests())
            {
                if (t.TraineeId == oldTest.TraineeId)
                {//if he took a test before
                    flag = true;
                    if (oldTest.Datetime > t.Datetime)
                    {
                        temp = oldTest;
                    }
                }
            }
            if (flag)
            {//if got into the previous if so:
                if (temp.Datetime.AddDays(Configuration.MinAmountOfTimeBetweenTests) > t.Datetime) //if the last test's date + 7 days is bigger than the new test to add date it means that 7 days have not passed yet
                    throw new Exception("Cannot do 2 tests in less than 7 days");
            }

            if ((t.Datetime.Year == DateTime.Now.Year) && (t.Datetime.Month == DateTime.Now.Month) && (int)((t.Datetime - DateTime.Now).Days) <= 7) // possibility to set a test for week ahead
            {
                //allows to add a test only if it is in the week that we are at

                var v = from item in dal.GetTesters() // v is a list of testers that are avaliable at the time that the trainee asked for
                        where (item.testerId == t.TesterId && item.testerWorkHours[(int)(t.Datetime.DayOfWeek), (t.Hour - 9)].Equals(true))
                        select item;
                if (v == null)
                {
                    throw new Exception("Tester is unavaliable at this hour");
                }
            }
            else
            {
                throw new Exception("You cannot save a date for the test more than a week before the date you want");
            }
            foreach (Test tl in dal.GetTests())
            {
                if (tl.TraineeId == t.TraineeId && tl.Grade == true && tl.TOfCar == t.TOfCar)
                {
                    throw new Exception("You cannot take a test on this type of viecle because you have passed");
                }
            }
            var tester= from item in dal.GetTesters()
                        where (item.testerId == t.TesterId)
                        select item;
            var trainee = from item in dal.GetTrainees()
                          where (item.traineeId == t.TraineeId)
                          select item;
            if(((Tester)tester).testerProfession!= ((Trainee)trainee).traineeViecle)
            {
                throw new Exception("The tester profession does not fit the trainee's type of car");
            }
            
            try { dal.AddTest(t); }

            catch (Exception e) { throw e; }

        }

        /// <summary>
        /// update a test and confime that it can be updated
        /// </summary>
        /// <param name="t">test to update</param>
        public void UpdateTest(Test t)
        {
            try
            { dal.UpdateTest(t); }
            catch (Exception e)
            { throw e; }
        }
        #endregion

        #region Lists functions
        public List<BE.Tester> GetTesters() { return dal.GetTesters(); }
        public List<BE.Trainee> GetTrainees() { return dal.GetTrainees(); }
        public List<BE.Test> GetTests() { return dal.GetTests(); }
        #endregion

        #region Creative part
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
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 7; k++)
                {
                    if (t.testerWorkHours[i, k] != null)
                    {
                        workingHours++;
                        if (t.testerWorkHours[i, k] == false)
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
            if (ordered)
            {
                result = from item in dal.GetTesters()
                         //where (ordered == true)
                         orderby item.testerProfession
                         group item by item.testerProfession;
            }
            else
            {

                result = from item in dal.GetTesters()
                         group item by item.testerProfession;
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
            if (ordered)
            {
                result = from item in dal.GetTrainees()
                        // where (ordered == true)
                         orderby item.traineeSchool
                         group item by item.traineeSchool;
            }
            else
            {

                result = from item in dal.GetTrainees()
                         group item by item.traineeSchool;
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
            if (ordered)
            {
                result = from item in dal.GetTrainees()
                         //where (ordered == true)
                         orderby item.traineeTeacher
                         group item by item.traineeTeacher;
            }
            else
            {

                result = from item in dal.GetTrainees()
                         group item by item.traineeTeacher;
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
            if (ordered)
            {
                result = from item in dal.GetTrainees()
                             //where (ordered == true)
                         orderby item.TraineeAmountOfTests
                         group item by item.TraineeAmountOfTests;
            }

            else
            {
                result = from item in dal.GetTrainees()
                         group item by item.traineeLessons;
            }
            return result;
        }
        #endregion
        #region additional functions

        /// <summary>
        /// this function recieves an address and returns a list of all the testers that live in a x radius from this address
        /// </summary>
        /// <param name="a">a given address</param>
        /// <returns>list of all the testers that live in a x radius from this address</returns>
        public List<BE.Tester> DistanceCalculate(Address a)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);//randomize different  number each time for the distance
            double x = rnd.Next(0, 300);
            var v = from item in dal.GetTesters()
                    where rnd.Next(0, 300) <= x
                    select item;
            return  (List < BE.Tester > )v;
        }
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
                if (tst.testerWorkHours[(int)t.DayOfWeek,h]==true)
                {
                    foreach (Test item in dal.GetTests())
                    {
                        if (item.TesterId==tst.testerId && item.Datetime==t && item.Hour==h)
                        {
                            avaliableTesters.Add(tst);
                        }
                    }
                }
            }
            return avaliableTesters;
        }
        /// <summary>
        /// this function recieves a bool condition and returns all the tests that  fits the condition
        /// </summary>
        /// <param name="condition">a bool condition</param>
        /// <returns>list of all the tests that fits the condition</returns>
        public List<Test> TestesByCondition(Predicate<Test> condition)
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
            int count = 0;
            foreach (Test test in dal.GetTests())
            {
                if (test.TraineeId.CompareTo(t.traineeId) == 0)
                    count++;
            }
            return count;
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
                if (test.TraineeId.CompareTo(t.traineeId) == 0 && test.Grade)
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
            List<Test> testsByDate = new List<Test>();
            foreach (Test test in dal.GetTests())
            {
                if (test.Datetime.Month == d.Month && test.Datetime.Year == d.Year)
                    testsByDate.Add(test);
            }
            testsByDate.OrderBy(s => s.Datetime);
            return testsByDate;
        }

    }
    #endregion
}
