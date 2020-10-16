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
    /// Interaction logic for TesterWindow.xaml
    /// </summary>
    public partial class TesterWindow : Window
    {
        IBL BL;

        /// <summary>
        /// This function opens the window of "Tester"
        /// </summary>
        public TesterWindow()//constractor
        {
            InitializeComponent();
            BL = Bl_imp.GetBl();
        }

        /// <summary>
        /// This function adds a new tester when we press on the button "Add Tester"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TesterAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddTester addTesterWind = new AddTester();
            addTesterWind.ShowDialog();
        }

        /// <summary>
        /// This function deletes a tester when we press on the button "Delete Tester"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TesterDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteTester deleteTesterWind = new DeleteTester();
            deleteTesterWind.ShowDialog();
        }

        /// <summary>
        /// This function updates a tester when we press on the button "Update Tester"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TesterUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateTester UpdateTesterWind = new UpdateTester();
            UpdateTesterWind.ShowDialog();
        }

        /// <summary>
        /// This function searches a tester by his ID
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TesterSearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTesterWindow searchTesterWind = new SearchTesterWindow();
            searchTesterWind.ShowDialog();

        }
    }
}
