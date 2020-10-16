using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DAL
{
    static class BE_Extentions
    {
        /// <summary>
        /// this function converts a trainee to xml 
        /// </summary>
        /// <param name="t">a trainee </param>
        /// <returns>xml version of trainee</returns>
        public static XElement ToXML(this Trainee t)
        {
            return new XElement("Trainee",
                new XElement("TraineeId", t.TraineeId),
                new XElement("TraineeName", t.TraineeName),
                new XElement("TraineeLast", t.TraineeLast),
                new XElement("TraineeGender", t.TraineeGender.ToString()),
                new XElement("TraineeBirthDate", t.TraineeBirthDate.ToString()),
                new XElement("TraineeGrade", t.TraineeGrade.ToString()),
                new XElement("TraineePhone", t.TraineePhone),
                new XElement("TraineeAddress",
                    new XElement("Street",t.TraineeAddress.Street),
                    new XElement("NumOfBuilding", t.TraineeAddress.NumOfBuilding),
                    new XElement("City",t.TraineeAddress.City)),
                new XElement("TraineeVehicle", t.TraineeVehicle.ToString()),
                new XElement("TraineeGear", t.TraineeGear.ToString()),
                new XElement("TraineeSchool", t.TraineeSchool),
                new XElement("TraineeTeacher", t.TraineeTeacher),
                new XElement("TraineeLessons", t.TraineeLessons.ToString()),
                new XElement("TraineeTest",
                    new XElement("GetDate", t.TraineeTest.GetDate.ToString()),
                    new XElement("GetHour", t.TraineeTest.GetHour.ToString())),
                new  XElement("TraineeAmountOfTests", t.TraineeAmountOfTests.ToString())
                );
        }

        /// <summary>
        /// this function converts a tester to xml 
        /// </summary>
        /// <param name="t">a tester </param>
        /// <returns>xml version of tester</returns>
        public static XElement ToXML(this Tester t)
        {
            return new XElement("Tester",
                new XElement("TesterId", t.TesterId),
                new XElement("TesterName", t.TesterName),
                new XElement("TesterLast", t.TesterLast),
                new XElement("TesterGender", t.TesterGender.ToString()),
                new XElement("TesterBirthDate", t.TesterBirthDate.ToString()),
                new XElement("TesterPhone", t.TesterPhone),
                new XElement("TesterWorkHours", t.TesterWorkHours.SceduleToString()),
                new XElement("TesterAddress",
                    new XElement("Street", t.TesterAddress.Street),
                    new XElement("NumOfBuilding", t.TesterAddress.NumOfBuilding),
                    new XElement("City", t.TesterAddress.City)),
                new XElement("TesterProfession", t.TesterProfession.ToString()),
                new XElement("TesterSeniority", t.TesterSeniority),
                new XElement("TesterMaxTests", t.TesterMaxTests.ToString()),
                new XElement("TesterMaxDistance", t.TesterMaxDistance.ToString())

                );
        }

        /// <summary>
        /// this function converts a test to xml 
        /// </summary>
        /// <param name="t">a test </param>
        /// <returns>xml version of test</returns>
        public static XElement ToXML(this Test t)
        {
            return new XElement("Test",
                new XElement("NumOfTest", t.NumOfTest.ToString()),
                new XElement("TesterId", t.TesterId),
                new XElement("TraineeId", t.TraineeId),
                new XElement("TOfCar", t.TOfCar.ToString()),
                new XElement("Datetime", t.Datetime.ToString()),
                new XElement("Hour", t.Hour.ToString()),
                new XElement("SourceAddress",
                    new XElement("Street", t.SourceAddress.Street),
                    new XElement("NumOfBuilding", t.SourceAddress.NumOfBuilding),
                    new XElement("City", t.SourceAddress.City)),
                new XElement("Grade", t.Grade.ToString()),
                new XElement("Note", t.Note),
                new XElement("KeepingDistance", t.KeepingDistance.ToString()),
                new XElement("Mirror", t.Mirror.ToString()),
                new XElement("Vinkers", t.Vinkers.ToString()),
                new XElement("PathTransition", t.PathTransition.ToString()),
                new XElement("ProperSpeed", t.ProperSpeed.ToString()),
                new XElement("ReverseParking", t.ReverseParking.ToString())
                );
        }
        /// <summary>
        /// converts a xelement to test
        /// </summary>
        /// <param name="elem">a xelement to convert to test</param>
        /// <returns>test version of elem</returns>
        public static Test ToTest(this XElement elem)
        {
            return new Test
            {
                SourceAddress = new Address
                {
                    City = elem.Element("SourceAddress").Element("City").Value,
                    NumOfBuilding = Int32.Parse(elem.Element("SourceAddress").Element("NumOfBuilding").Value),
                    Street = elem.Element("SourceAddress").Element("Street").Value
                },
                TesterId = elem.Element("TesterId").Value,
                TraineeId = elem.Element("TraineeId").Value,
                Hour =int.Parse(elem.Element("Hour").Value),
                Datetime = DateTime.Parse(elem.Element("Datetime").Value),
                TOfCar = (BE.MyEnum.TypeOfCar)Enum.Parse(typeof(BE.MyEnum.TypeOfCar), elem.Element("TOfCar").Value),
                NumOfTest = int.Parse(elem.Element("NumOfTest").Value),
                Grade = bool.Parse(elem.Element("Grade").Value),
                Note = elem.Element("Note").Value,
                KeepingDistance = bool.Parse(elem.Element("KeepingDistance").Value),
                Mirror = bool.Parse(elem.Element("Mirror").Value),
                Vinkers = bool.Parse(elem.Element("Vinkers").Value),
                PathTransition = bool.Parse(elem.Element("PathTransition").Value),
                ProperSpeed = bool.Parse(elem.Element("ProperSpeed").Value),
                ReverseParking = bool.Parse(elem.Element("ReverseParking").Value)

            };
        }
        /// <summary>
        /// converts a xelement to tester
        /// </summary>
        /// <param name="elem">a xelement to convert to tester</param>
        /// <returns>tester version of elem</returns>
        public static Tester ToTester(this XElement elem)
        {
            return new Tester
            {
                TesterAddress = new Address
                {
                    City = elem.Element("TesterAddress").Element("City").Value,
                    NumOfBuilding = Int32.Parse(elem.Element("TesterAddress").Element("NumOfBuilding").Value),
                    Street = elem.Element("TesterAddress").Element("Street").Value
                },
                TesterId = elem.Element("TesterId").Value,
                TesterName = elem.Element("TesterName").Value,
                TesterLast = elem.Element("TesterLast").Value,
                TesterBirthDate = DateTime.Parse(elem.Element("TesterBirthDate").Value),
                TesterGender = (BE.MyEnum.Gender)Enum.Parse(typeof(BE.MyEnum.Gender), elem.Element("TesterGender").Value),
                TesterProfession = (BE.MyEnum.TypeOfCar)Enum.Parse(typeof(BE.MyEnum.TypeOfCar), elem.Element("TesterProfession").Value),
                TesterPhone = elem.Element("TesterPhone").Value,
                TesterMaxDistance = int.Parse(elem.Element("TesterMaxDistance").Value),
                TesterSeniority = int.Parse(elem.Element("TesterSeniority").Value),
                TesterMaxTests = int.Parse(elem.Element("TesterMaxTests").Value),
                TesterWorkHours = (elem.Element("TesterWorkHours").Value).StringToScedule()

            };
        }
        /// <summary>
        /// converts a xelement to trainee
        /// </summary>
        /// <param name="elem">a xelement to convert to trainee</param>
        /// <returns>trainee version of elem</returns>
        public static Trainee ToTrainee(this XElement elem)
        {
            Trainee tr = new Trainee
            {
                TraineeAddress = new Address
                {
                    City = elem.Element("TraineeAddress").Element("City").Value,
                    NumOfBuilding = Int32.Parse(elem.Element("TraineeAddress").Element("NumOfBuilding").Value),
                    Street = elem.Element("TraineeAddress").Element("Street").Value
                },
                TraineeId = elem.Element("TraineeId").Value,
                TraineeName = elem.Element("TraineeName").Value,
                TraineeLast = elem.Element("TraineeLast").Value,
                TraineeAmountOfTests = Int32.Parse(elem.Element("TraineeAmountOfTests").Value),
                TraineeBirthDate = DateTime.Parse(elem.Element("TraineeBirthDate").Value),
                TraineeGear = (BE.MyEnum.GearBox)Enum.Parse(typeof(BE.MyEnum.GearBox), elem.Element("TraineeGear").Value),
                TraineeGender = (BE.MyEnum.Gender)Enum.Parse(typeof(BE.MyEnum.Gender), elem.Element("TraineeGender").Value),
                TraineeGrade = Boolean.Parse(elem.Element("TraineeGrade").Value),
                TraineeLessons = int.Parse(elem.Element("TraineeLessons").Value),
                TraineePhone = elem.Element("TraineePhone").Value,
                TraineeSchool = elem.Element("TraineeSchool").Value,
                TraineeTeacher = elem.Element("TraineeTeacher").Value,
                TraineeVehicle= (BE.MyEnum.TypeOfCar)Enum.Parse(typeof(BE.MyEnum.TypeOfCar), elem.Element("TraineeVehicle").Value),
                TraineeTest = new StudentTest
                {
                    GetDate = DateTime.Parse(elem.Element("TraineeTest").Element("GetDate").Value),
                    GetHour = int.Parse(elem.Element("TraineeTest").Element("GetHour").Value)
                }
            };
          
            return tr;
        }
        /// <summary>
        /// using predicate that saves source as xml to a file 
        /// </summary>
        /// <typeparam name="T">a generic type</typeparam>
        /// <param name="source">someone to save to xml</param>
        /// <param name="fullfilename">the file name to save to </param>
        public static void SaveToXml<T>(this T source, string fullfilename)
        {
            using (FileStream file = new FileStream(fullfilename, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
                xmlSerializer.Serialize(file, source);
                file.Close();
            }
        }

        /// <summary>
        /// converts the tester's scedule to a string
        /// </summary>
        /// <param name="scedule">the tester's scedule</param>
        /// <returns>string version of the tester's scedule</returns>
        public static string SceduleToString(this bool?[,] scedule)
        {
            string sceduleXML = "";
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 6; j++)
                {
                    if(scedule[i, j]==null)
                        sceduleXML +="null"+ ",";
                    else
                       sceduleXML += scedule[i, j].ToString() + ",";
                }
                    
            return sceduleXML.Remove(sceduleXML.Length - 1);   //delete the last comma (',')
        }

        /// <summary>
        /// converts the tester's scedule from a string to xml
        /// </summary>
        /// <param name="sceduleXML">string version of the tester's scedule</param>
        /// <returns>xml version of the tester's scedule</returns>
        public static bool?[,] StringToScedule(this string sceduleXML) 
        {
            string[] arrayScedule = sceduleXML.Split(',');
            bool?[,] boolScedule = new bool?[5, 6];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 6; j++)
                {
                    if (arrayScedule[i * 6 + j].ToLower() == "null")
                    {
                        boolScedule[i, j] = null;
                    }
                    else
                    {
                        boolScedule[i, j] = bool.Parse(arrayScedule[i * 6 + j].ToLower()); 
                    }
                }

            return boolScedule;
        }

        /// <summary>
        /// converts a string to a generic type
        /// </summary>
        /// <typeparam name="T">a generic type</typeparam>
        /// <param name="toDeserialize">a string we recieve</param>
        /// <returns>a generic type of the string</returns>
        public static T ToObject<T>(this string toDeserialize)
        {
            using (StringReader textReader = new StringReader(toDeserialize))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }
        /// <summary>
        /// converts a string to xml
        /// </summary>
        /// <typeparam name="T">a generic type</typeparam>
        /// <param name="toSerialize">the string we recieve</param>
        /// <returns>xml version of the string</returns>
        public static string ToXMLstring<T>(this T toSerialize)
        {
            using (StringWriter textWriter = new StringWriter())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
    }
}

 