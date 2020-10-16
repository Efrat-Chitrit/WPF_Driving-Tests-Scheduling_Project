using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DS
{
    public /*static*/ class DataSourceXML
    {
        private static string solutionDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;

        //the first element in the file
        private static XElement traineeRoot = null; 
        private static XElement testerRoot = null;
        private static XElement testRoot = null;
        private static XElement configRoot = null;

        //the names of the files (red color) and directory (DataXML)
        private static string filePath = System.IO.Path.Combine(solutionDirectory, "DS", "DataXML");
        private static string testerPath = Path.Combine(filePath, "Testers.xml");
        private static string traineePath = Path.Combine(filePath, "Trainees.xml");
        private static string testPath = Path.Combine(filePath, "Tests.xml");
        private static string configPath = Path.Combine(filePath, "Config.xml");

        //the label of the beginning and ending of the file(for example <Testers/>)
        private static XElement traineeList;
        private static XElement testerList;
        private static XElement testList;
        private static XElement config;

        /*static */public  DataSourceXML()
        {
            
            bool exists = Directory.Exists(filePath);//exists=true if there is a path to the file
            if (!exists)
            {
                Directory.CreateDirectory(filePath);//creates a new directory with the path we have to the file(sends the files to DataXML)
            }
            //if the files do not exist create them and load them
            if (!File.Exists(traineePath))
            {
                TraineeList = new XElement("Trainees");
            }
            traineeRoot = LoadData(traineePath);
            if (!File.Exists(testerPath))
            {
                TesterList = new XElement("Testers");
            }
            testerRoot = LoadData(testerPath);

            if (!File.Exists(testPath))
            {
                TestList = new XElement("Tests");
            }
            testRoot = LoadData(testPath);

            if (!File.Exists(configPath))
            {
                configRoot = new XElement("numOfTest", BE.Configuration.numOfTest);
                configRoot.Save(configPath);
            }
            configRoot = LoadData(configPath);

        }
        //creates a file
        private static void CreateFile(string typename, string path)
        {
            XElement root = new XElement(typename);
            root.Save(path);
        }
        //loads the data
        private static  XElement LoadData(string path)
        {
            XElement root;
            try
            {
                root = XElement.Load(path);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
            return root;
        }
        //saves the files
        public static void SaveTests()
        {
            testList.Save(testPath);
        }
        public static void SaveTrainees()
        {
            traineeList.Save(traineePath);
        }
        public static void SaveTesters()
        {
            testerList.Save(testerPath);
        }
        public static void SaveConfig()
        {
            config.Save(configPath);
        }

        //properties to get to them (load them  and save them)
        public static XElement Config
        {
            get
            {
                config = XElement.Load(configPath);
                return config;
            }

            set
            {
                config = value;
                config.Save(configPath);
            }
        }
        public static XElement TestList
        {
            get
            {
                testList = XElement.Load(testPath);
                return testList;
            }
            set
            {
                testList = value;
                testList.Save(testPath);
            }
        }

        public static XElement TraineeList
        {
            get
            {
                traineeList = XElement.Load(traineePath);
                return traineeList;
            }
            set
            {
                traineeList = value;
                traineeList.Save(traineePath);
            }
        }

        public static XElement TesterList
        {
            get
            {
                testerList = XElement.Load(testerPath);
                return testerList;
            }
            set
            {
                testerList = value;
                testerList.Save(testerPath);
            }
        }

    }
}
