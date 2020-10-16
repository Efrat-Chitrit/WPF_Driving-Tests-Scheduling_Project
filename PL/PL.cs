using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;
using DS;


namespace PL
{
    public class PL
    {
        static void Main(string[] args)
        {
            BL.IBL bl = Bl_imp.GetBl();

            //string id = "123456";
            int choice;
            //int typeOfCar = 10; //for a exception
            bool?[,] mat = new bool?[5, 7]
            {
                { true,true,true,true,true,true,true },//sunday
                { true,true,true,true,true,true,true },//monday
                { true,true,true,true,true,true,true },//etc.
                { true,true,true,true,true,false,null },
                { true,true,true,true,true,false,null }
            };
            try
            {

                do
                {

                    Console.WriteLine("out=0,new tester=1 ,new trainee=2 ,new test=3 ,delete tester=4, delete trainee=5,all the tests by date=6 ,testers by profession=7 ,update tester(from case 3)=8 ,update trainee=9 ,update test=10 ,TraineesBySchool=11 ,trainee by teacher=12, TraineesByNumOfTests=13 , AvaliableTesters=14 , DeserveDriversLicence=15 , TraineeNumOfTests=16 , TestsByCondition=17");
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            bl.AddTester(new Tester("318627264", "levi", "roni", new DateTime(1970, 2, 2), MyEnum.Gender.male, "0557287705", new Address("kishon", 10, "nazareth"), 20, 6, MyEnum.TypeOfCar.privateCar, 200, mat));
                            Console.WriteLine("Enter a new tester:");
                            foreach (var item in bl.GetTesters())
                            {
                                Console.WriteLine(item);
                            }
                            //   bl.AddTester(new Tester(id));       //throws exception


                            break;
                        case 2:
                            Console.WriteLine("Enter a new trainee:");
                            bl.AddTrainee(new Trainee("258691734", "white", "snow", new DateTime(1999, 03, 24), 0, "0585807116", new Address("grifindor", 6, "hogworts"), (MyEnum.TypeOfCar)3, (MyEnum.GearBox)1, "Hogworts", "Mcgonagel", 30, 3));
                            foreach (var item in bl.GetTrainees())
                            {
                                Console.WriteLine(item);
                            }
                            // bl.AddTrainee(new Trainee(id));//throws exception
                            break;
                        case 3:
                            Console.WriteLine("Enter a new test:");
                            bl.AddTester(new Tester("666258974", "levi", "eli", new DateTime(1970, 2, 2), MyEnum.Gender.male, "0557287605", new Address("kishon", 10, "nazareth"), 20, 6, (MyEnum.TypeOfCar)3, 120, mat));

                            bl.AddTest(new Test("666258974", "098765432", new DateTime(2019,1,3), 10, new Address("kishon", 10, "nazareth"), (MyEnum.TypeOfCar)3, false, ""));
                            foreach (var item in bl.GetTests())
                            {
                                Console.WriteLine(item);
                            }
                            /*bl.AddTest(new Test("318627264", "321654987", DateTime.Now.AddHours(10), 10, new Address("kishon", 10, "nazareth"), (MyEnum.TypeOfCar)typeOfCar, false, " "));*/
                            //throws exception
                            break;
                        case 4:
                            Console.WriteLine("Enter a tester to delete:");
                            bl.DeleteTester(new Tester("318627264", "levi", "roni", new DateTime(1970, 2, 2), MyEnum.Gender.male, "0557287705", new Address("kishon", 10, "nazareth"), 20, 6, MyEnum.TypeOfCar.privateCar, 200, mat));
                            foreach (var item in bl.GetTesters())
                            {
                                Console.WriteLine(item);
                            }
                            //bl.DeleteTester(new Tester(id)); //throws exception
                            break;
                        case 5:
                            Console.WriteLine("Enter a trainee to delete:");
                            bl.DeleteTrainee(new Trainee("258691734", "white", "snow", new DateTime(1999, 03, 24), 0, "0585807116", new Address("grifindor", 6, "hogworts"), (MyEnum.TypeOfCar)3, (MyEnum.GearBox)1, "Hogworts", "Mcgonagel", 30, 3));
                            foreach (var item in bl.GetTrainees())
                            {
                                Console.WriteLine(item);
                            }
                            // bl.DeleteTrainee(new Trainee("123456999"));//throws exception
                            break;
                            case 6:
                            List<Test> tests=bl.AllTestsInThisDate(DateTime.Now);
                            foreach (var item in tests)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        case 7:
                            IEnumerable<IGrouping<MyEnum.TypeOfCar,Tester>> t=bl.TestersByProfession(true);
                            foreach (var group in t)
                            {
                                Console.WriteLine(group.Key+":");
                                foreach (Tester tester in group)
                                {
                                    Console.WriteLine(tester);
                                }
                            }

                            break;
                        case 8:
                            bl.UpdateTester(new Tester("666258974", "levi", "eli", new DateTime(1970, 2, 2), MyEnum.Gender.male, "0557287605", new Address("komemiut", 3, "nazareth"), 20, 6, (MyEnum.TypeOfCar)3, 120, mat));
                            foreach (Tester tester in bl.GetTesters())
                            {
                                Console.WriteLine(tester);
                            }
                            break;
                        case 9:
                             bl.UpdateTrainee(new Trainee("258691734", "white", "snow", new DateTime(1999, 03, 24), 0, "0585807116", new Address("grifindor", 6, "hogworts"), (MyEnum.TypeOfCar)3, (MyEnum.GearBox)1, "Hogworts", "Snape", 30, 3));
                            foreach (Trainee trainee in bl.GetTrainees())
                            {
                                Console.WriteLine(trainee);
                            }
                            break;
                        case 10:
                            bl.UpdateTest(new Test("666258974", "098765432", new DateTime(2019, 1, 3), 10, new Address("kishon", 10, "nazareth"), (MyEnum.TypeOfCar)3, true, "finally you have passed "));
                            foreach (Test test in bl.GetTests())
                            {
                                Console.WriteLine(test);
                            }
                            break;
                        case 11:
                            
                            IEnumerable<IGrouping<string, Trainee>> schools = bl.TraineesBySchool(true);
                            foreach (var group in schools)
                            {
                                Console.WriteLine(group.Key + ":");
                                foreach (Trainee trainee in group)
                                {
                                    Console.WriteLine(trainee);
                                }
                            }
                            break;
                        case 12:
                            IEnumerable<IGrouping<string, Trainee>> teachers = bl.TraineesByTeacher(true);
                            foreach (var group in teachers)
                            {
                                Console.WriteLine(group.Key + ":");
                                foreach (Trainee trainee in group)
                                {
                                    Console.WriteLine(trainee);
                                }
                            }
                            break;
                        case 13:
                            
                            IEnumerable<IGrouping<int, Trainee>> numberOfTests = bl.TraineesByNumOfTests(true);
                            foreach (var group in numberOfTests)
                            {
                                Console.WriteLine(group.Key + ":");
                                foreach (Trainee trainee in group)
                                {
                                    Console.WriteLine(trainee);
                                }
                            }
                            break;
                        case 14:
                            List<Tester> testers = bl.AvaliableTesters(new DateTime(2019, 1, 3), 10);
                            foreach (Tester item in testers)
                            {
                                Console.WriteLine(item);
                            }

                            break;
                        case 15:
                            bool flag = false;
                            foreach (Trainee item in bl.GetTrainees())
                            {
                                if (bl.DeserveDriversLicence(item))
                                {
                                    flag = true;
                                    Console.WriteLine(item);
                                }
                            }
                            if (!flag)
                            {
                                Console.WriteLine("no one deserve a driver's licence");
                            }
                            break;
                        case 16:
                            foreach (Trainee item in bl.GetTrainees())
                            {
                                Console.WriteLine(item+ (bl.TraineeNumOfTests(item)).ToString());
                            }
                            break;
                        case 17:
                            List<Test> testsByCondition = bl.TestsByCondition(r => r.TesterId == "318627247");
                            foreach (Test test in testsByCondition)
                            {
                                Console.WriteLine(test);
                            }
                            break;
                        default:
                            break;

                    }
                } while (choice != 0);
            }
            catch (Exception c)
            {
                Console.WriteLine(c.Message);
            }

        }
    }
}
