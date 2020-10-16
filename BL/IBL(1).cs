using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BL
{
    public interface IBL
    {
       
        void AddTester(Tester t);
        void DeleteTester(Tester t);
        void UpdateTester(Tester t);

        void AddTrainee(Trainee t);
        void DeleteTrainee(Trainee t);
        void UpdateTrainee(Trainee t);

        void AddTest(Test t);
        void UpdateTest(Test t);

        List<BE.Tester> GetTesters();
        List<BE.Trainee> GetTrainees();
        List<BE.Test> GetTests();
        /*signatures of google maps functions */


         List<BE.Tester> DistanceCalculate(Address a);
         List<BE.Tester> AvaliableTesters(DateTime t, int h);
         List<Test> TestesByCondition(Predicate<Test> condition);
        int TraineeNumOfTests(BE.Trainee t);
        bool DeserveDriversLicence(BE.Trainee t);
        List<Test> AllTestsInThisDate(DateTime d);     
        /////////////////////////////////////
        
        IEnumerable<IGrouping< MyEnum.TypeOfCar,Tester>> TestersByProfession(bool ordered = false);
        IEnumerable<IGrouping<string, Trainee>>TraineesBySchool(bool ordered = false);
        IEnumerable<IGrouping<string,Trainee>> TraineesByTeacher(bool ordered = false);
        IEnumerable<IGrouping<int,Trainee>> TraineesByNumOfTests(bool ordered = false);
        /////////////////////////////////////
        ///the creative part functions///

        double AvarageOfWeek();
        void AvaliabilityOftester(Tester t,ref int avaliable, ref int workingHours);
            

    }
    public class BL
    {
    }
}
