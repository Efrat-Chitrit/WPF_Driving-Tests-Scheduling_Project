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
    /// Interaction logic for GroupingWindow.xaml
    /// </summary>
    public partial class GroupingWindow : Window
    {

        IBL BL;

        bool isOrdered = false;
        public GroupingWindow()//constractor
        {
            InitializeComponent();
            BL = Bl_imp.GetBl();
        }

        /// <summary>
        /// This function returns all the testers that their profession is equal.
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void GroupingTestersByProfession_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();//in case of listview that showed items before
            var testers = BL.TestersByProfession(isOrdered);
            foreach (var ienumerator in testers)
            {
                listView.Items.Add("Profession: "+ienumerator.Key);

                listView.Items.Add("----");
                foreach (var tester in ienumerator)
                {
                    listView.Items.Add(tester);
                }
            }
            isOrdered = false;
            order_checkBox.IsChecked = false;
        }

        /// <summary>
        /// This function returns all the trainees that learned at the same school.
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void GroupingTraineesBySchool_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();//in case of listview that showed items before
            var trainees = BL.TraineesBySchool(isOrdered);
            foreach (var ienumerator in trainees)
            {
                listView.Items.Add("School: " + ienumerator.Key);

                listView.Items.Add("----");
                foreach (var trainee in ienumerator)
                {
                    listView.Items.Add(trainee);
                }
            }
            isOrdered = false;
            order_checkBox.IsChecked = false;
        }

        /// <summary>
        /// This function returns all the trainees that have the same teacher.
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void GroupingTraineesByTeacher_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();//in case of listview that showed items before
            var trainees = BL.TraineesByTeacher(isOrdered);
            foreach (var ienumerator in trainees)
            {
                listView.Items.Add("Teacher: " + ienumerator.Key);

                listView.Items.Add("----");
                foreach (var trainee in ienumerator)
                {
                    listView.Items.Add(trainee);
                }
            }
            isOrdered = false;
            order_checkBox.IsChecked = false;
        }

        /// <summary>
        /// This function returns all the trainees that their number of tests is equal.
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void GroupingTraineesByNumOfTests_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();//in case of listview that showed items before
            var trainees = BL.TraineesByNumOfTests(isOrdered);
            foreach (var ienumerator in trainees)
            {
                listView.Items.Add("Number Of Tests: " + ienumerator.Key);

                listView.Items.Add("----");
                foreach (var trainee in ienumerator)
                {
                    listView.Items.Add(trainee);
                }
            }
            isOrdered = false;
            order_checkBox.IsChecked = false;
        }

        /// <summary>
        /// This function decides if the grouping will be orderd or not
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void Order_checkBox_Checked(object sender, RoutedEventArgs e)
        {
            isOrdered = (bool)(order_checkBox.IsChecked);
        }
    }
}
