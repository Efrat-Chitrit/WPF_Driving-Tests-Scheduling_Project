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
using System.Threading;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddTestWindow.xaml
    /// </summary>
    public partial class AddTestWindow : Window
    {
        IBL BL;
        Test currentTest;
        /// <summary>
        /// This function opens a new window to add a new tester
        /// </summary>
        public AddTestWindow()
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
            try
            {
                Thread t = new Thread(() =>
                {
                try
                {
                        Dispatcher.Invoke(() =>
                        {//allows changes in the UI while the thread runs,blocks all the controls
                            submitBtn.IsEnabled = false;
                            tOfCarComboBox.IsEnabled = false;
                            hourTextBox.IsEnabled = false;
                            traineeIdTextBox.IsEnabled = false;
                            numOfBuildingTextBox.IsEnabled = false;
                            cityTextBox.IsEnabled = false;
                            streetTextBox.IsEnabled = false;
                            datetimeDatePicker.IsEnabled = false;
                            
                        });
                        BL.AddTest(currentTest);
                        Dispatcher.Invoke(() =>
                        {
                            currentTest = new Test();//creates a new test for current test so the addition can work again well
                            DataContext = currentTest;//sets the current test in DataContext
                            //enables all the controls after the thread finished and it succeeded
                            submitBtn.IsEnabled = true;
                            tOfCarComboBox.IsEnabled = true;
                            hourTextBox.IsEnabled = true;
                            traineeIdTextBox.IsEnabled = true;
                            numOfBuildingTextBox.IsEnabled = true;
                            cityTextBox.IsEnabled = true;
                            streetTextBox.IsEnabled = true;
                            datetimeDatePicker.IsEnabled = true;
                            
                        });

                }
                catch (Exception exc)
                    {
                    Dispatcher.Invoke(() =>
                    {//enables all the controls after the thread( in case of an exception)
                        MessageBox.Show(exc.Message);
                          submitBtn.IsEnabled = true;
                        tOfCarComboBox.IsEnabled = true;
                        hourTextBox.IsEnabled = true;
                        traineeIdTextBox.IsEnabled = true;
                        numOfBuildingTextBox.IsEnabled = true;
                        cityTextBox.IsEnabled = true;
                        streetTextBox.IsEnabled = true;
                        datetimeDatePicker.IsEnabled = true;
                    });}
                });
                t.Start();
                


            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// This function will place the user's choice in the "TOfCar" (type of car) field of the test
        /// </summary>
        /// <param name="sender">Who is sending the event</param>
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

    }
}
