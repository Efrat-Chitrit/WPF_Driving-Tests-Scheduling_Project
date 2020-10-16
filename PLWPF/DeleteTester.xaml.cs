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
    /// Interaction logic for DeleteTester.xaml
    /// </summary>
    public partial class DeleteTester : Window
    {
       
        IBL BL;
        Tester currentTester;
        /// <summary>
        /// Interaction logic to DeleteTester.Bl_imp
        /// </summary>
        public DeleteTester()
        {
            InitializeComponent();
            BL = Bl_imp.GetBl();
            currentTester = new Tester { TesterBirthDate = new DateTime() };//creates a new tester for current tester with deafult values 
            DataContext = currentTester; //sets the current tester in DataContext
            this.testerGenderComboBox.ItemsSource = Enum.GetValues(typeof(BE.MyEnum.Gender));
            this.testerProfessionComboBox.ItemsSource = Enum.GetValues(typeof(BE.MyEnum.TypeOfCar));
        }

        /// <summary>
        /// This function will insert the appropriate values into the corresponding fields when we press on the button "submit"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(currentTester.ToString());
            try
            {
                BL.DeleteTester(currentTester);//deletes the current tester from the list of testers
                currentTester = new Tester();//creates a new tester for current tester so the delete can work again well
                DataContext = currentTester;//sets the current tester in DataContext
                testerIdTextBox.IsEnabled = true;//so the delete can work again well
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }


        /// <summary>
        /// This function will place the user's choice in the "Gender" field of the tester that needs to be deleted
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TesterGenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentTester.TesterGender = (BE.MyEnum.Gender)(testerGenderComboBox.SelectedItem);
        }

        /// <summary>
        /// This function will place the user's choice in the "Profession" (type of car) field of the tester that needs to be deleted
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TesterProfessionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentTester.TesterProfession = (BE.MyEnum.TypeOfCar)(testerProfessionComboBox.SelectedItem);
        }


        /// <summary>
        /// All of the following functions ensure the input property. they do not allow the user to enter inappropriate values.
        /// For example: in a first name, it is forbidden to enter numbers etc...
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TesterIdTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only
        }

        private void TesterLastTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-z,A-Z]+").IsMatch(e.Text);//accepts letters only
        }

        private void TesterMaxDistanceTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only
        }

        private void TesterMaxTestsTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only
        }

        private void TesterNameTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-z,A-Z]+").IsMatch(e.Text);//accepts letters only
        }

        private void TesterPhoneTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only
        }

        private void TesterSeniorityTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only
        }

        private void TesterStreetTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-z,A-Z]+").IsMatch(e.Text);//accepts letters only
        }

        private void TesterNumOfBuildingTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only
        }

        private void TesterCityTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-z,A-Z]+").IsMatch(e.Text);//accepts letters only
        }

        /// <summary>
        /// Event lost focus - when we found a tester with this ID it shows the tester details and locks the this text box
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TesterIdTextBox(object sender, RoutedEventArgs e)
        {
            try
            {
                currentTester = BL.SearchTester(testerIdTextBox.Text);
                DataContext = currentTester;
                testerIdTextBox.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
