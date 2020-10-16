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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;

using BL;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL BL;
        public MainWindow()//constractor
        {
            InitializeComponent();
            BL = Bl_imp.GetBl();
        }


        /// <summary>
        /// This function will open the window of a new trainee when we press on the button "Trainee"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TraineeButton_Click(object sender, RoutedEventArgs e)
        {
            TraineeWindow traineeWind = new TraineeWindow();
            traineeWind.ShowDialog();
        }

        /// <summary>
        /// This function will open the window of a new tester when we press on the button "Tester"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TesterButton_Click(object sender, RoutedEventArgs e)
        {
            TesterWindow testerWind = new TesterWindow();
            testerWind.ShowDialog();
        }

        /// <summary>
        /// This function will open the window of a new test when we press on the button "Test"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            TestWindow testWind = new TestWindow();
            testWind.ShowDialog();
        }

        /// <summary>
        /// This function will open the window of grouping when we press on the button "Grouping"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void grouping_Click(object sender, RoutedEventArgs e)
        {
            GroupingWindow groupingWind = new GroupingWindow();
            groupingWind.ShowDialog();
        }

        /// <summary>
        /// This function will open the window of query when we press on the button "Query"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void Query_Click(object sender, RoutedEventArgs e)
        {
            QueryWindow queryWind = new QueryWindow();
            queryWind.ShowDialog();
        }

    }
}
