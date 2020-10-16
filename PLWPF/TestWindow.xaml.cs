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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {

        /// <summary>
        /// This function opens the window of "Test"
        /// </summary>
        public TestWindow()//constractor
        {
            InitializeComponent();
        }

        /// <summary>
        /// This function adds a new test when we press on the button "Add Test"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TestAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddTestWindow addTestWind = new AddTestWindow();
            addTestWind.ShowDialog();
        }

        /// <summary>
        /// This function deletes a test when we press on the button "Delete Test"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TestDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteTestWindow deleteTestWind = new DeleteTestWindow();
            deleteTestWind.ShowDialog();
        }

        /// <summary>
        /// This function updates a test when we press on the button "Update Test"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TestUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateTestWindow updateTestWind = new UpdateTestWindow();
            updateTestWind.ShowDialog();
        }

        /// <summary>
        /// This function searches a test by its number
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TestSearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTestWindow searchTestWind = new SearchTestWindow();
            searchTestWind.ShowDialog();
        }
    }
}
