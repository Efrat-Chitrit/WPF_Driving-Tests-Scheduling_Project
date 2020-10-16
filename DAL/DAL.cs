using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface IDal
    {
        void AddTester(Tester t);
        void DeleteTester(Tester t);
        void UpdateTester(Tester t);

        void AddTrainee(Trainee t);
        void DeleteTrainee(Trainee t);
        void UpdateTrainee(Trainee t);

        void AddTest(Test t);
        void DeleteTest(Test t);
        void UpdateTest(Test t);

        List<BE.Tester> GetTesters();
        List<BE.Trainee> GetTrainees();
        List<BE.Test> GetTests();

        List<int> GetTesterRating(Tester t);


    }
  
}
