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
    /// Interaction logic for TraineeNumOfTestsWindow.xaml
    /// </summary>
    public partial class TraineeNumOfTestsWindow : Window
    {
        IBL BL;

        /// <summary>
        /// This function opens the window of "Trainee number of tests"
        /// </summary>
        public TraineeNumOfTestsWindow()//constractor
        {
            InitializeComponent();
            BL = Bl_imp.GetBl();
        }

        /// <summary>
        /// This function shows the data (the trainee number of tests) by list view
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TraineeNumOfTests_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();//in case of listview that showed items before
            foreach (var trainee in BL.GetTrainees())
            {
                listView.Items.Add(trainee.TraineeName + " " + trainee.TraineeLast + "'s number of tests: " + trainee.TraineeAmountOfTests);

            }
            if ((BL.GetTrainees()) == null)
            {
                listView.Items.Add("There are no trainees");
            }

        }
    }
}
