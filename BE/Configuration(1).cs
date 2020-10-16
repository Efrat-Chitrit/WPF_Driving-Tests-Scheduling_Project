using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Configuration
    {
        public static int numOfTest = 00000000;//ctor++
        public static int MinNumOfLessons =20;
        public static int MaxAgeOfTester =70;//we decided that the age 70 is the age when testers will retire
        public static int MinAgeOfTester = 40;
        public static int MinAgeOfTrainee =18;
        public static double MinAmountOfTimeBetweenTests =7;
    }
}
