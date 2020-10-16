using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Configuration
    {
        public static int numOfTest = 10000003;//when we create a new test: numOfTest++
        public static int MinNumOfLessons =20;
        public static int MaxAgeOfTester =70;//we decided that the age 70 is the age when testers will retire
        public static int MinAgeOfTester = 40;
        public static int MinAgeOfTrainee =18;
        public static double MinAmountOfTimeBetweenTests =7;
        public static int TesterHours = 6; //working hours of the tester: from 9:00 to 15:00 
        public static int TesterDays = 5; //working days of the tester: from sunday to thursday

    }
}
