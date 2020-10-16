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
using BE;
using BL;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for QueryWindow.xaml
    /// </summary>
    public partial class QueryWindow : Window
    {
        IBL BL;
        public QueryWindow()//constractor
        {
            InitializeComponent();
            BL = Bl_imp.GetBl();
        }

        /// <summary>
        /// This function creates a window that shows us all the trainees by their number of tests.
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TraineeNumOfTests_Click(object sender, RoutedEventArgs e)
        {
            TraineeNumOfTestsWindow traineeNumOfTestsWind = new TraineeNumOfTestsWindow();
            traineeNumOfTestsWind.ShowDialog();
        }

        /// <summary>
        /// This function creates a window that shows us all the trainees that deserve a drivers licence.
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void DeserveDriversLicence_Click(object sender, RoutedEventArgs e)
        {
            DeserveDriversLicenceWindow deserveDriversLicenceWind = new DeserveDriversLicenceWindow();
            deserveDriversLicenceWind.ShowDialog();
        }

        /// <summary>
        /// This function creates a window that shows us all the tests that occure in the same month.
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void AllTestsInThisDate_Click(object sender, RoutedEventArgs e)
        {
            AllTestsInThisDateWindow allTestsInThisDateWind = new AllTestsInThisDateWindow();
            allTestsInThisDateWind.ShowDialog();
        }
        /// <summary>
        /// This function creates a window that shows us all the tests that the trainee failed them
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TestsByConditionXml_Click(object sender, RoutedEventArgs e)
        {
            TestsByConditionWindow testsByConditionWind = new TestsByConditionWindow();
            testsByConditionWind.ShowDialog();
        }
    }
}
