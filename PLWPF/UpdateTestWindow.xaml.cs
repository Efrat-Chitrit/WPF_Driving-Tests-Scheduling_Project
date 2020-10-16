using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for UpdateTestWindow.xaml
    /// </summary>
    public partial class UpdateTestWindow : Window
    {
        IBL BL;
        Test currentTest;
        /// <summary>
        /// This function updates a new tester
        /// </summary>
        public UpdateTestWindow()
        {
            InitializeComponent();

            BL = Bl_imp.GetBl();
            currentTest = new Test { Datetime = new DateTime() };//creates a new test for current test with deafult values 
            DataContext = currentTest;//sets the current test in DataContext
            this.tOfCarComboBox.ItemsSource = Enum.GetValues(typeof(BE.MyEnum.TypeOfCar));
        }

        /// <summary>
        /// This function will insert the appropriate values into the corresponding fields when we press on the button "submit"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show(currentTest.ToString());
            int count = 0;
            try
            {   //checks the criterions for pass the test:
                if (mirrorCheckBox.IsChecked.Value == false) count++;
                if (VinkersCheckBox.IsChecked.Value == false) count++;
                if (pathTransitionCheckBox.IsChecked.Value == false) count++;
                if (properSpeedCheckBox.IsChecked.Value == false) count++;
                if (reverseParkingCheckBox.IsChecked.Value == false) count++;
                if (keepingDistanceCheckBox.IsChecked.Value == false) count++;

                if (count > 2) //if there were more then 2 mistakes the traunee can't pass the test and the Grade's checkbox.IsChecked will be false so it will not be open to changes
                {
                    (gradeCheckBox.IsChecked) = false;
                }
                else // the trainee passed the test
                {
                    (gradeCheckBox.IsChecked) = true;
                }
                BL.UpdateTest(currentTest);
                currentTest = new Test();//creates a new test for current test so that the update can work again well
                DataContext = currentTest;//sets the current test in DataContext so that the update can work again well
                traineeIdTextBox.IsEnabled = true;
                testerIdTextBox.IsEnabled = true;
                numOfTestTextBox.IsEnabled = true;
                (gradeCheckBox.IsChecked) = false;
                hourTextBox.IsEnabled = true;
                datetimeDatePicker.IsEnabled = true;
                cityTextBox.IsEnabled = true;
                numOfBuildingTextBox.IsEnabled = true;
                streetTextBox.IsEnabled = true;

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// This function will place the user's choice in the "TOfCar" (type of car) field of the test
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TOfCarComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentTest.TOfCar = (BE.MyEnum.TypeOfCar)(tOfCarComboBox.SelectedItem);
        }


        /// <summary>
        /// All of the following functions ensure the input property. they do not allow the user to enter inappropriate values.
        /// For example: in a first name, it is forbidden to enter numbers etc...
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void HourTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only
        }

        private void NoteTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-z,A-Z]+").IsMatch(e.Text);//accepts letters only 
        }

        private void NumOfTestTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only
        }

        private void TesterIdTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only
        }

        private void TraineeIdTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only
        }

        private void CityTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-z,A-Z]+").IsMatch(e.Text);//accepts letters only
        }

        private void NumOfBuildingTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only
        }

        private void StreetTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-z,A-Z]+").IsMatch(e.Text);//accepts letters only
        }


        /// <summary>
        /// Event lost focus - when we found a test with this number it shows the test details and locks this text box
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void NumOfTestTextBox(object sender, RoutedEventArgs e)
        {
            try
            {
                currentTest = BL.SearchTest(Int32.Parse(numOfTestTextBox.Text));
                DataContext = currentTest;
                traineeIdTextBox.IsEnabled = false;
                testerIdTextBox.IsEnabled = false;
                numOfTestTextBox.IsEnabled = false;
                hourTextBox.IsEnabled = false;
                datetimeDatePicker.IsEnabled = false;
                cityTextBox.IsEnabled = false;
                numOfBuildingTextBox.IsEnabled = false;
                streetTextBox.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

     
    }

}
