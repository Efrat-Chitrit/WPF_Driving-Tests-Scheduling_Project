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
using System.Text.RegularExpressions;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for SearchTesterWindow.xaml
    /// </summary>
    public partial class SearchTesterWindow : Window
    {
       
        IBL BL;
        string id;

        /// <summary>
        /// This function opens the window of "Search Tester"
        /// </summary>
        public SearchTesterWindow()//constractor
        {
            InitializeComponent();
            BL = Bl_imp.GetBl();
        }

        /// <summary>
        /// This function will search a tester by his ID when we press on the button "Search"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void SearchTesterBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show((BL.SearchTester(id)).ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// This function recieves an ID and search the tester by his ID
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void SearchTesterId_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
          id= SearchTesterId_textBox.Text;
        
        }

        /// <summary>
        /// This function ensure the input property. it does not allow the user to enter inappropriate values.
        /// For example: in a first name, it is forbidden to enter numbers etc...
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void SearchTesterId_textBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only 
        }
    }
}
