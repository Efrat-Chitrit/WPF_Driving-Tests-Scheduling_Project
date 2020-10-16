using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BL;
using BE;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for TestsByConditionWindow.xaml
    /// </summary>
    public partial class TestsByConditionWindow : Window
    {
        IBL BL;
        public TestsByConditionWindow()
        {
            InitializeComponent();
            BL = Bl_imp.GetBl();
        }
        /// <summary>
        /// This function opens the window of "Failed tests-Tests By condition"
        /// </summary>
        private void FailedTestesXml_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();//in case of listview that showed items before
            List<Test> testsByCondition = BL.TestsByCondition(r => r.Grade == false);
            foreach (Test test in testsByCondition)
            {
                listView.Items.Add("Number of test: " + test.NumOfTest + '\n' + "Tester's ID: " + test.TesterId + '\n' + "Trainee ID: " + test.TraineeId + '\n');
            }

            if ((BL.GetTrainees()) == null)
            {
                listView.Items.Add("There are no tests that failed");
            }

        }
    }
}
