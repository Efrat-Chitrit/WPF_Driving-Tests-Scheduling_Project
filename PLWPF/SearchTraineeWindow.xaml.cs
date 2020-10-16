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
    /// Interaction logic for SearchTraineeWindow.xaml
    /// </summary>
    public partial class SearchTraineeWindow : Window
    {

        IBL BL;
        string id;

        /// <summary>
        /// This function opens the window of "Search Trainee"
        /// </summary>
        public SearchTraineeWindow()//constractor
        {
            InitializeComponent();
            BL = Bl_imp.GetBl();
        }

        /// <summary>
        /// This function will search a trainee by his ID when we press on the button "Search"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void SearchTraineeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show((BL.SearchTrainee(id)).ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// This function recieves an ID and search the trainee by his ID
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void SearchTraineeId_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            id = SearchTraineeId_textBox.Text;

        }

        /// <summary>
        /// This function ensure the input property. it does not allow the user to enter inappropriate values.
        /// For example: in a first name, it is forbidden to enter numbers etc...
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void SearchTraineeId_textBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only 
        }
    }
}
