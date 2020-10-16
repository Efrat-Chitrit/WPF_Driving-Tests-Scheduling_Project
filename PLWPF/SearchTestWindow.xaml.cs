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
    /// Interaction logic for SearchTestWindow.xaml
    /// </summary>
    public partial class SearchTestWindow : Window
    {
        IBL BL;
        int numOfTest;

        /// <summary>
        /// This function opens the window of "Search Test"
        /// </summary>
        public SearchTestWindow()//constractor
        {
            InitializeComponent();
            BL = Bl_imp.GetBl();
        }

        /// <summary>
        /// This function will search a test by its number when we press on the button "Search"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void SearchTestBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show((BL.SearchTest(numOfTest)).ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// This function recieves a number and search the test by its number
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void SearchTestNum_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            numOfTest = int.Parse(SearchTestNum_textBox.Text);
        }

        /// <summary>
        /// This function ensure the input property. it does not allow the user to enter inappropriate values.
        /// For example: in a first name, it is forbidden to enter numbers etc...
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void SearchTestNum_textBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only 
        }
    }
}
