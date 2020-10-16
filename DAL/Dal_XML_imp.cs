
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using BE;

namespace DAL
{
    public class Dal_XML_imp : IDal
    {
        #region Singleton
        // Singleton design pattern:
        // reference to the single instance of IDal
        private static IDal instance = null;

        /// <summary>
        /// initialize all the files- if they does not exists it creates them. if they does exists it load them.
        /// </summary>
        private Dal_XML_imp()
        {
            new DS.DataSourceXML();
        }

        /// <summary>
        /// Singleton design pattern:
        /// reference to the single instance of IDal
        /// </summary>
        /// <returns> the singleton else creates a new one</returns>
        public static IDal GetDal()
        {
            if (instance == null)
                instance = new Dal_XML_imp();
            return instance;
        }

        /// <summary>
        /// adds a test
        /// </summary>
        /// <param name="test">test to add</param>
        public void AddTest(Test test)
        {
           
            var elements = DS.DataSourceXML.TesterList.Elements("Test"); //every test in the file

            var found = elements.FirstOrDefault(t => t.Element("NumOfTest").Value == test.NumOfTest.ToString()); //found = the test with this num of test, if there is no such a test: found = null
            if (found != null)
            {
                throw new Exception("The test is already exist");
            }
            else
            {

                test.NumOfTest = int.Parse(DS.DataSourceXML.Config.Value)+1;//changes the config number in the test
                DS.DataSourceXML.Config.Value = test.NumOfTest.ToString();//loads the new config number in the file
                DS.DataSourceXML.SaveConfig();//saves the config changes
                DS.DataSourceXML.TestList.Add(test.ToXML());//turns test to Xml and adds it to the file
                DS.DataSourceXML.SaveTests();//saves the tests file
            }
        }

        /// <summary>
        /// adds a tester
        /// </summary>
        /// <param name="tsr">tester to add</param>
        public void AddTester(Tester tsr)
        {
            var elements = DS.DataSourceXML.TesterList.Elements("Tester");//every tester in the file

            var found = elements.FirstOrDefault(t => t.Element("TesterId").Value == tsr.TesterId);//found = the tester with this ID ,if there is no such a tester: found = null
            if (found != null)
            {
                throw new Exception("The tester is already exists");
            }
            else
            {
                DS.DataSourceXML.TesterList.Add(tsr.ToXML());//turns tester to Xml and adds it to the file
                DS.DataSourceXML.SaveTesters();//saves the testers file
            }
        }

        /// <summary>
        /// adds a trainee
        /// </summary>
        /// <param name="tr">trainee to add</param>
        public void AddTrainee(Trainee tr)
        {
            var elements = DS.DataSourceXML.TraineeList.Elements("Trainee");//every trainee in the file

            var found = elements.FirstOrDefault(t => t.Element("TraineeId").Value == tr.TraineeId);//found = the trainee with this ID ,if there is no such a trainee: found = null
            if (found != null)
            {
                throw new Exception("The trainee is already exists");
            }
            else
            {
                DS.DataSourceXML.TraineeList.Add(tr.ToXML()); //turns trainee to Xml and adds it to the file
                DS.DataSourceXML.SaveTrainees(); //saves the trainee file
            }

        }

        /// <summary>
        /// deletes a test
        /// </summary>
        /// <param name="t">test to delete</param>
        public void DeleteTest(Test t)
        {
            XElement drivingTests = DS.DataSourceXML.TestList;//the xElement version of tests
            var found = (from d in drivingTests.Elements()
                         where (d.Element("NumOfTest").Value == t.NumOfTest.ToString())
                         select d).FirstOrDefault(); //found = the test with this num of test, if there is no such a test: found = null

            if (found == null)
            {
                throw new Exception("The test does not exist");
            }
            found.Remove(); //deletes the test
            DS.DataSourceXML.SaveTests();//saves the tests file
        }

        /// <summary>
        /// deletes a tester
        /// </summary>
        /// <param name="t">tester to delete</param>
        public void DeleteTester(Tester t)
        {
            XElement testerList = DS.DataSourceXML.TesterList;//the xElement version of testers
            var found = (from d in testerList.Elements()
                         where (d.Element("TesterId").Value == t.TesterId.ToString())
                         select d).FirstOrDefault();//found = the tester with this ID, if there is no such a tester: found = null
            if (found == null)
            {
                throw new Exception("The tester does not exist");
            }
            found.Remove();//deletes the tester
            DS.DataSourceXML.SaveTesters();//saves the testers file
        }

        /// <summary>
        /// deletes a trainee
        /// </summary>
        /// <param name="t"> trainee to delete</param>
        public void DeleteTrainee(Trainee t)
        {
            XElement traineeList = DS.DataSourceXML.TraineeList;//the xElement version of trainees
            var found = (from d in traineeList.Elements()
                         where (d.Element("TraineeId").Value == t.TraineeId.ToString())
                         select d).FirstOrDefault();//found = the trainee with this ID, if there is no such a trainee: found = null
            if (found == null)
            {
                throw new Exception("The trainee does not exist so it cannot be deleted");
            }
            found.Remove();//deletes the trainee
            DS.DataSourceXML.SaveTrainees();//saves the trainees file
        }


        /// <summary>
        /// returns the list
        /// </summary>
        /// <returns>the list of tests</returns>
        public List<Tester> GetTesters()
        {
            //using Linq
            var result = from t in DS.DataSourceXML.TesterList.Elements("Tester")
                         select t.ToTester();
            return result.ToList();
        }

        /// <summary>
        /// returns the list
        /// </summary>
        /// <returns>the list of tests</returns>
        public List<Test> GetTests()
        {
            //using Linq
            var result = from t in DS.DataSourceXML.TestList.Elements("Test")
                         select t.ToTest();
            return result.ToList();
        }

        /// <summary>
        /// returns the list
        /// </summary>
        /// <returns>the list of tests</returns>
        public List<Trainee> GetTrainees()
        {

            //using Linq
            var result = from t in DS.DataSourceXML.TraineeList.Elements("Trainee")
                         select t.ToTrainee();
            return result.ToList();
        }


        /// <summary>
        /// updates  the test,deletes the old one and puts test instead
        /// </summary>
        /// <param name="test">the updated test</param>
        public void UpdateTest(Test test)
        {
            XElement testList = DS.DataSourceXML.TestList;//the xElement version of test
            var found = (from d in testList.Elements()
                         where (d.Element("NumOfTest").Value == test.NumOfTest.ToString())
                         select d).FirstOrDefault();//found = the test with this num of test, if there is no such a test: found = null
            if (found == null)
            {
                throw new Exception("There is no such a test");
            }

            DeleteTest(found.ToTest());//deletes the test
            DS.DataSourceXML.TestList.Add(test.ToXML());//turns test to Xml and adds it to the file
            DS.DataSourceXML.SaveTests();//saves the tests file


        }
        /// <summary>
        /// updates  the tester,deletes the old one and puts tester instead
        /// </summary>
        /// <param name="tester">the updated tester</param>
        public void UpdateTester(Tester tester)
        {
            XElement testerList = DS.DataSourceXML.TesterList;//the xElement version of testers
            var found = (from d in testerList.Elements()
                         where (d.Element("TesterId").Value == tester.TesterId.ToString())
                         select d).FirstOrDefault();//found = the tester with this ID, if there is no such a tester: found = null
            if (found == null)
            {
                throw new Exception("There is no such a tester");
            }
            
            DeleteTester(found.ToTester());//deletes the tester
            DS.DataSourceXML.TesterList.Add(tester.ToXML());//turns tester to Xml and adds it to the file
            DS.DataSourceXML.SaveTesters();//saves the testers file
        }
        /// <summary>
        /// updates  the trainee,deletes the old one and puts trainee instead
        /// </summary>
        /// <param name="t">the updated trainee</param>
        public void UpdateTrainee(Trainee t)
        {
            XElement traineeList = DS.DataSourceXML.TraineeList;//the xElement version of trainee
            var found = (from d in traineeList.Elements()
                         where (d.Element("TraineeId").Value == t.TraineeId.ToString())
                         select d).FirstOrDefault();//found = the trainee with this ID, if there is no such a trainee: found = null
            if (found == null)
            {
                throw new Exception("The trainee does not exist");
            }
            DeleteTrainee(found.ToTrainee());//deletes the trainee it found
            DS.DataSourceXML.TraineeList.Add(t.ToXML());//adds the new trainee
            DS.DataSourceXML.SaveTrainees();//saves the trainees file
        }
        #endregion
    }
}
