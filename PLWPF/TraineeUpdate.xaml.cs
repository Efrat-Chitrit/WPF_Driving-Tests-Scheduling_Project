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
    /// Interaction logic for TraineeUpdate.xaml
    /// </summary>
    public partial class TraineeUpdate : Window
    {
        IBL BL;
        Trainee currentTrainee;

        /// <summary>
        /// This function updates a trainee 
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        public TraineeUpdate()
        {
            InitializeComponent();

            BL = Bl_imp.GetBl();
            currentTrainee = new Trainee { TraineeBirthDate = new DateTime() };// creates a new trainee for current trainee with deafult values
 
             DataContext = currentTrainee;//sets the current trainee in DataContext
            this.traineeGenderComboBox.ItemsSource = Enum.GetValues(typeof(BE.MyEnum.Gender));
            this.traineeGearComboBox.ItemsSource = Enum.GetValues(typeof(BE.MyEnum.GearBox));
            this.traineeVehicleComboBox.ItemsSource = Enum.GetValues(typeof(BE.MyEnum.TypeOfCar));
        }


        /// <summary>
        /// This function will insert the appropriate values into the corresponding fields when we press on the button "submit"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(currentTrainee.ToString());
            try
            {
                BL.UpdateTrainee(currentTrainee);
                currentTrainee = new Trainee();//creates a new trainee for current trainee so that the update can work again well
                DataContext = currentTrainee;//sets the current trainee in DataContext so that the update can work again well
                traineeIdTextBox.IsEnabled = true;

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// This function will place the user's new choice in the "Gear Box" field of the trainee
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TraineeGearComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentTrainee.TraineeGear = (BE.MyEnum.GearBox)(traineeGearComboBox.SelectedItem);
        }

        /// <summary>
        /// This function will place the user's new choice in the "Gender" field of the trainee
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TraineeGenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentTrainee.TraineeGender = (BE.MyEnum.Gender)(traineeGenderComboBox.SelectedItem);
        }

        /// <summary>
        /// This function will place the user's new choice in the "Viecle" (type of car) field of the trainee
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TraineeVehicleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentTrainee.TraineeVehicle = (BE.MyEnum.TypeOfCar)(traineeVehicleComboBox.SelectedItem);
        }


        /// <summary>
        /// All of the following functions ensure the input property. they do not allow the user to enter inappropriate values.
        /// For example: in a first name, it is forbidden to enter numbers etc...
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TraineeAmountOfTestsTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only 
        }

        private void TraineeIdTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only
        }

        private void TraineeLastTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-z,A-Z]+").IsMatch(e.Text);//accepts letters only
        }

        private void TraineeLessonsTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only
        }

        private void TraineeNameTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-z,A-Z]+").IsMatch(e.Text);//accepts letters only
        }

        private void TraineePhoneTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only
        }

        private void TraineeSchoolTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-z,A-Z]+").IsMatch(e.Text);//accepts letters only
        }

        private void TraineeTeacherTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-z,A-Z]+").IsMatch(e.Text);//accepts letters only
        }

        private void TraineeStreetTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-z,A-Z]+").IsMatch(e.Text);//accepts letters only
        }

        private void TraineeNumOfBuildingTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);//accepts numbers only
        }

        private void TraineeCityTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-z,A-Z]+").IsMatch(e.Text);//accepts letters only
        }

        /// <summary>
        /// Event lost focus - when we found a trainee with this ID it shows the trainee details and locks this text box
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TraineeIdTextBox(object sender, RoutedEventArgs e)
        {
            try
            {
                currentTrainee = BL.SearchTrainee(traineeIdTextBox.Text);
                DataContext = currentTrainee;
                traineeVehicleComboBox.SelectedItem=(currentTrainee.TraineeVehicle);
                traineeIdTextBox.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
