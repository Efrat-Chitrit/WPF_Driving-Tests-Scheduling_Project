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
    /// Interaction logic for TraineeWindow.xaml
    /// </summary>
    public partial class TraineeWindow : Window
    {
        IBL BL;

        /// <summary>
        /// This function open the window of "Trainee"
        /// </summary>
        public TraineeWindow()
        {
            InitializeComponent();
            BL = Bl_imp.GetBl();
        }

        /// <summary>
        /// This function adds a new trainee when we press on the button "Add Trainee"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TraineeAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddTrainee addTraineeWind = new AddTrainee();
            addTraineeWind.ShowDialog();
        }

        /// <summary>
        /// This function deletes a trainee when we press on the button "Delete Trainee"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TraineeDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteTrainee deleteTraineeWind = new DeleteTrainee();
            deleteTraineeWind.ShowDialog();
        }

        /// <summary>
        /// This function updates a trainee when we press on the button "Update Trainee"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TraineeUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            TraineeUpdate UpdateTraineeWind = new TraineeUpdate();
            UpdateTraineeWind.ShowDialog();
        }

        /// <summary>
        /// This function searches a trainee by his ID
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TraineeSearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTraineeWindow searchTraineeWind = new SearchTraineeWindow();
            searchTraineeWind.ShowDialog();
        }
    }
}
