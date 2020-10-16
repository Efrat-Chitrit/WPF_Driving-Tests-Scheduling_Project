using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    public class Dal_imp:IDal
    {
        /// <summary>
        /// this function adds a tester if s/he is not exists in the list
        /// </summary>
        /// <param name="t">tester to add to the list</param>
        /// <param name="tl">tester in the list</param>

        #region Singleton
        // Singleton design pattern:
        // reference to the single instance of IDal
        private static IDal instance = null;

        private Dal_imp()
        {
            DS.DataSource.InitializeList();
        }
        //returns the singleton else creates a new one
        public static IDal GetDal()
        {
            if (instance == null)
                instance = new Dal_imp();
            return instance;
        }
        #endregion
        /// <summary>
        /// adds a tester to the list of testers if s/he does not exists
        /// </summary>
        /// <param name="t">tester to add</param>
        public void AddTester(Tester t)
        {
            foreach (Tester tl in DS.DataSource.testerList)
            {
                if (t.TesterId == tl.TesterId)
                    throw new Exception("The tester is already exists");
            }
            DS.DataSource.testerList.Add(t);
        }

        /// <summary>
        /// this function removes a tester if s/he is exists in the list
        /// </summary>
        /// <param name="t">tester to remove from the list</param>
        /// <param name="tl">tester in the list</param>
        public void DeleteTester(Tester t)
        {
            foreach (Tester tl in DS.DataSource.testerList)
            {
                if (t.TesterId == tl.TesterId)
                {
                    DS.DataSource.testerList.Remove(tl);
                    return;
                }     
            }
            throw new Exception("The tester does not exist");
        }
        /// <summary>
        /// updates  the tester,deletes the old one and puts t instead
        /// </summary>
        /// <param name="t">the updated tester</param>
        /// <param name="tl">tester in the list</param>
        public void UpdateTester(Tester t)
        {
            Tester v = (Tester)(from item in DS.DataSource.testerList
                    where (t.TesterId == item.TesterId)
                    select item).FirstOrDefault();
            if (!(v.Equals(null)))
            {//the tester was found
                DS.DataSource.testerList.Remove(v);
                DS.DataSource.testerList.Add(t);
                return;
            }
            throw new Exception("There is no such a tester");  
        } 

            /// <summary>
            /// this function adds a trainee if s/he is not exists in the list
            /// </summary>
            /// <param name="t">trainee to add to the list</param>
            /// <param name="tl">trainee in the list</param>
        public void AddTrainee(Trainee t)
        {
            foreach (Trainee tl in DS.DataSource.traineeList)
            {
                if (t.TraineeId == tl.TraineeId)
                    throw new Exception("The trainee is already exists");
            }
            DS.DataSource.traineeList.Add(t);
        }

        /// <summary>
        /// this function removes a trainee if s/he is exists in the list
        /// </summary>
        /// <param name="t">trainee to remove from the list</param>
        /// <param name="tl">trainee in the list</param>
        public void DeleteTrainee(Trainee t)
        {
            foreach (Trainee tl in DS.DataSource.traineeList)
            {
                if (t.TraineeId == tl.TraineeId)
                {
                    DS.DataSource.traineeList.Remove(tl);
                    return;
                }       
            }
            throw new Exception("The trainee does not exist so it cannot be deleted");
        }
        /// <summary>
        /// updates  the trainee,deletes the old one and puts t instead
        /// </summary>
        /// <param name="t">the updated trainee</param>
        /// <param name="tl">trainee in the list</param>
        public void UpdateTrainee(Trainee t)
        {
            foreach (Trainee tl in DS.DataSource.traineeList)
            {
                if (t.TraineeId == tl.TraineeId)
                {
                    DS.DataSource.traineeList.Remove(tl);
                    DS.DataSource.traineeList.Add(t);
                    return;
                }
            }
            throw new Exception("The trainee does not exist so it cannot be updated");
        }
        /// <summary>
        /// adds a test to the tests list if it doesn't exist
        /// </summary>
        /// <param name="t">test to add to the list</param>
        /// <param name="tl">test in the list</param>
        public void AddTest(Test t)
        {
            foreach (Test tl in DS.DataSource.testList)
            {
                if (t== tl)
                {
                    throw new Exception("The test is already exist");
                }
            }
            BE.Configuration.numOfTest++;
            t.NumOfTest = BE.Configuration.numOfTest;
            Tester tester = (Tester)(from item in DS.DataSource.testerList
                                     where item.TesterId == t.TesterId
                                     select item).FirstOrDefault();
            (tester).TesterWorkHours[(int)(t.Datetime.DayOfWeek), (t.Hour - 9)] = false;
            UpdateTester(tester);
            Trainee someTrainee = (Trainee)(from trainee in DS.DataSource.traineeList
                    where (trainee.TraineeId == t.TraineeId)
                    select trainee).FirstOrDefault();
            someTrainee.TraineeAmountOfTests++;
            DS.DataSource.testList.Add(t);
        }
        /// <summary>
        /// deletes a test if it exists
        /// </summary>
        /// <param name="t">a test to delete</param>
        public void DeleteTest(Test t)
        {
            foreach (Test tl in DS.DataSource.testList)
            {
                if (t.NumOfTest == tl.NumOfTest && t.TesterId==tl.TesterId && t.TraineeId==tl.TraineeId && t.Datetime==tl.Datetime && t.Hour==tl.Hour && t.TOfCar==tl.TOfCar)
                {//if it is the same test
                    DS.DataSource.testList.Remove(tl);
                    return;
                }
            }
            throw new Exception("The test does not exist");
        }
        /// <summary>
        /// updates  the test,deletes the old one and puts t instead
        /// </summary>
        /// <param name="t">the updated test</param>
        /// <param name="tl">test in the list</param>
        public void UpdateTest(Test t)
        {
            foreach (Test tl in DS.DataSource.testList)
            {
                if (t.NumOfTest == tl.NumOfTest)
                {
                    DS.DataSource.testList.Remove(tl);
                    DS.DataSource.testList.Add(t);
                    Tester tester = (Tester)(from item in DS.DataSource.testerList
                            where item.TesterId == t.TesterId
                            select item).FirstOrDefault();
                    (tester).TesterWorkHours[(int)(t.Datetime.DayOfWeek), (t.Hour - 9)] = false;
                     UpdateTester(tester);
                    Trainee trainee = (Trainee)(from item in DS.DataSource.traineeList
                            where item.TraineeId == t.TraineeId
                               select item).FirstOrDefault();
                    StudentTest tryTest = new StudentTest { GetDate=t.Datetime, GetHour=t.Hour};
                    if (tryTest.IsBigger((trainee).TraineeTest))
                    {
                        (trainee).TraineeTest = new StudentTest { GetDate = t.Datetime, GetHour = t.Hour };
                        (trainee).TraineeAmountOfTests++;
                        (trainee).TraineeGrade = t.Grade;
                        UpdateTrainee(trainee);
                        return;
                    }
                      
                    if (tryTest.IsEqual(((Trainee)trainee).TraineeTest))
                        throw new Exception("The test's time is equal so it shall not be changed");
                    else
                    {
                        if ((tryTest.GetDate < DateTime.Now) || (tryTest.GetDate == DateTime.Now && tryTest.GetHour < (int)(DateTime.Now.Hour)))//if the new date of the test already occurred the time will not be changed
                            throw new Exception("The test's time has been already, you can't take a test in the past");
                    }
                  
                        
                }
            }
        }
        /// <summary>
        /// returns the list
        /// </summary>
        /// <returns>the list of testers</returns>
        public List<BE.Tester> GetTesters() { return DS.DataSource.testerList; }
        /// <summary>
        /// returns the list
        /// </summary>
        /// <returns>the list of trainees</returns>
        public List<BE.Trainee> GetTrainees()
        {
            return  DS.DataSource.traineeList;
        }
        /// <summary>
        /// returns the list
        /// </summary>
        /// <returns>the list of tests</returns>
        public List<BE.Test> GetTests() { return DS.DataSource.testList; }



    }
}
