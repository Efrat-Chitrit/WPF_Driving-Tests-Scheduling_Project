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
using System.Text.RegularExpressions;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for DeleteTestWindow.xaml
    /// </summary>
    public partial class DeleteTestWindow : Window
    {
        IBL BL;
        Test currentTest;
        /// <summary>
        /// deletes a test
        /// </summary>
        public DeleteTestWindow()
        {
            InitializeComponent();
            BL = Bl_imp.GetBl();
            currentTest = new Test { Datetime = new DateTime() };//creates a new test for current test with deafult values 
            DataContext = currentTest;//sets the current test in DataContext
        }


        /// <summary>
        /// This function will insert the appropriate values into the corresponding fields when we press on the button "submit"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void DeleteTestBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show((BL.SearchTest(Int32.Parse(DeleteTestNum_textBox.Text))).ToString(), "Are you sure this is the right test you would like to delete?", MessageBoxButton.OK,MessageBoxImage.Warning);
           
                currentTest = BL.SearchTest(Int32.Parse(DeleteTestNum_textBox.Text));//searchs the test according to the number of test
                BL.DeleteTest(currentTest); //deletes the current test from the list of tests
                currentTest = new Test();//creates a new test for current test so the delete can work again well
                DataContext = currentTest;//sets the current test in DataContext
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// the following function ensure the input property. it does not allow the user to enter inappropriate values.
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void DeleteTestNum_textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only
        }
    }
}
