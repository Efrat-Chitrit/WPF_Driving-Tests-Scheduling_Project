using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;


namespace PL
{
    public class Program
    {
        static BL.IBL bl = BL.BLFactory.GetIbl();
        static void Main(string[] args)
        {
            
            string id = "123456";
            int choice, typeOfCar = 10;
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

                    Console.WriteLine("out=0,new tester=1 ,new trainee=2 ,new test=3 ,delete tester=4, delete trainee=5 ");
                    choice = int.Parse(Console.ReadLine());
                    
                    switch (choice)
                    {
                        case 1:
                            bl.AddTester(new Tester());
                            Console.WriteLine("Enter a new tester:");
                            bl.AddTester(new Tester(id));
                           
                            break;
                        case 2:
                            Console.WriteLine("Enter a new trainee:");
                            bl.AddTrainee(new Trainee(id));
                            break;
                        case 3:
                            Console.WriteLine("Enter a new test:");
                            bl.AddTester(new Tester("318627264", "levi", "roni", new DateTime(1970, 2, 2), MyEnum.Gender.male, 0557287705, new Address("kishon", 10, "nazareth"), 20, 6, MyEnum.TypeOfCar.privateCar, 200, mat));
                            bl.AddTrainee(new Trainee("321654987"));
                            bl.AddTest(new Test("318627264", "321654987", DateTime.Now.AddHours(10), 10, new Address("kishon", 10, "nazareth"), (MyEnum.TypeOfCar)typeOfCar, false, " "));
                            break;
                        case 4:
                            Console.WriteLine("Enter a tester to delete:");
                            bl.DeleteTester(new Tester(id));
                            break;
                        case 5:
                            Console.WriteLine("Enter a trainee to delete:");
                            bl.DeleteTrainee(new Trainee("123456999"));
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
