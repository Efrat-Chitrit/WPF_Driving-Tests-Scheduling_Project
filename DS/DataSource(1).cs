using BE;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Collections.Generic.List;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class DataSource
    {
       
        public static List<BE.Tester> testerList =new List<Tester>();//the list of testers
        public static List<BE.Trainee> traineeList=new List<Trainee>();//the list of trainee
        public static List<BE.Test> testList=new List<Test>();//the list of tests

        /// <summary>
        /// a function to initialize values... only to test the program so far
        /// </summary>
        public static void initializeList()
        {
            bool?[,] mat = new bool?[5, 7]
            {
                { true,true,true,true,true,true,true },
                { true,true,true,true,true,true,true },
                { true,true,true,true,true,true,true },
                { true,true,true,true,true,false,null },
                { true,true,true,true,true,false,null }
            };
            Tester Avi = new Tester("123456789", "avraham", "Avi", new DateTime(1970, 01, 04), 0, 0545866441, new Address("street", 1, "city"), 20, 5, (MyEnum.TypeOfCar)0, 50, mat);
            Tester Koby = new Tester("318627247", "maimon", "Koby", new DateTime(1983, 04, 01), 0, 0524407205, new Address("vila", 5, "vilecula"), 10, 3, (MyEnum.TypeOfCar)2, 40, mat);
            testerList.Add(Avi);
            testerList.Add(Koby);

            Trainee Harry = new Trainee("098765432", "Potter", "Harry", new DateTime(1999, 03, 13), 0, 0585807116, new Address("grifindor", 5, "hogworts"), (MyEnum.TypeOfCar)3, (MyEnum.GearBox)1, "Hogworts", "Mcgonagel", 28, 1);
            Trainee Simba = new Trainee("123123123", "lionKing", "Simba", new DateTime(1983, 12, 05), 0, 1256987456, new Address("tzook", 5, "hatikva"), (MyEnum.TypeOfCar)1, (MyEnum.GearBox)0, "HacunaMatata", "Pumba", 15, 2);
            traineeList.Add(Harry);
            traineeList.Add(Simba);

            //Harry is Avi's trainee
            Test t1 = new Test("123456789", "098765432", new DateTime(2019, 1, 1), 11, new Address("street", 1, "city"), (MyEnum.TypeOfCar)3, false, "you are a wizard Harry");

            //Simba is Koby's trainee
            Test t2 = new Test("318627247", "123123123", new DateTime(2019, 1, 1), 9, new Address("vila", 1, "vilecula"), (MyEnum.TypeOfCar)1, false, "i killed Mufasa");
            testList.Add(t1);
            testList.Add(t2);

        }
    }
}
