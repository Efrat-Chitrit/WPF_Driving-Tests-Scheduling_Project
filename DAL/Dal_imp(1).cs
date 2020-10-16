using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    public class Dal_imp:Idal
    {
        /// <summary>
        /// this function adds a tester if s/he is not exists in the list
        /// </summary>
        /// <param name="t">tester to add to the list</param>
        /// <param name="tl">tester in the list</param>
        public void AddTester(Tester t)
        {
            foreach (Tester tl in DS.DataSource.testerList)
            {
                if (t.testerId == tl.testerId)
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
                if (t.testerId == tl.testerId)
                {
                    DS.DataSource.testerList.Remove(t);
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
            var v = from item in DS.DataSource.testerList
                    where (t.testerId == item.testerId)
                    select item;
            if (v != null)
            {//the tester was found
                DS.DataSource.testerList.Remove((Tester)v);
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
            var v = from item in DS.DataSource.traineeList
                    where (t.traineeId == item.traineeId)
                    select item;
            if(v!=null)//the trainee was already been found
                throw new Exception("The trainee is already exists");
            else
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
                if (t.traineeId == tl.traineeId)
                {
                    DS.DataSource.traineeList.Remove(t);
                    return;
                }       
            }
            throw new Exception("The tester does not exist");
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
                if (t.traineeId == tl.traineeId)
                {
                    DS.DataSource.traineeList.Remove(tl);
                    DS.DataSource.traineeList.Add(t);
                    return;
                }
            }
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
                if (t.NumOfTest == tl.NumOfTest)
                {
                    throw new Exception("The test is already exist");
                }
            }
            BE.Configuration.numOfTest++;
            t.NumOfTest = BE.Configuration.numOfTest;
            var v = from trainee in DS.DataSource.traineeList
                    where (trainee.traineeId == t.TraineeId)
                    select trainee;
            ((Trainee)v).TraineeAmountOfTests++;
            DS.DataSource.testList.Add(t);
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
                    var v = from item in DS.DataSource.testerList
                            where item.testerId == t.TesterId
                            select item;
                    ((Tester)v).testerWorkHours[(int)(t.Datetime.DayOfWeek), (t.Hour - 9)] = true;
                     UpdateTester((Tester)v);
                    var temp = from item in DS.DataSource.traineeList
                            where item.traineeId == t.TraineeId
                               select item;
                    StudentTest tryTest = new StudentTest(t.Datetime, t.Hour);
                    if (tryTest.IsBigger(((Trainee)temp).TraineeTest))
                    {
                        ((Trainee)temp).TraineeTest = new StudentTest(t.Datetime, t.Hour);
                        ((Trainee)temp).TraineeAmountOfTests++;
                        UpdateTrainee((Trainee)temp);
                        return;
                    }
                      
                    if (tryTest.IsEqual(((Trainee)temp).TraineeTest)) throw new Exception("The test's time is equal so it shall not be changed");
                    else
                    {
                        if ((tryTest.GetDate() < DateTime.Now) || (tryTest.GetDate() == DateTime.Now && tryTest.GetHour() < (int)(DateTime.Now.Hour)))//if the new date of the test already occurred the time will not be changed
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
        public List<BE.Trainee> GetTrainees() { return DS.DataSource.traineeList; }
        /// <summary>
        /// returns the list
        /// </summary>
        /// <returns>the list of tests</returns>
        public List<BE.Test> GetTests() { return DS.DataSource.testList; }



    }
}
