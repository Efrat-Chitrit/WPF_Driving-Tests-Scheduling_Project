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
    /// Interaction logic for AddTester.xaml
    /// </summary>
    public partial class AddTester : Window
    {
        IBL BL;
        Tester currentTester;
        /// <summary>
        /// puts values in the matrix
        /// </summary>
        /// <param name="value">a value of the checkBox</param>
        /// <returns>true or null dependes on the situation</returns>
        public bool? CheckBoxValue(bool? value)
        {
            if (value == false) return null;
            //if it's not null and not false it must be true
            return true;
        }
        /// <summary>
        /// This function adds a new tester
        /// </summary>
        public AddTester()
        {
            InitializeComponent();
            bool?[,] mat = new bool?[,]
             {
                { true,true,true,true,true,true },
                { true,true,true,true,true,true },
                { true,true,true,true,true,true },
                { true,true,true,true,true,true },
                { true,true,true,true,true,true },

             };

            BL = Bl_imp.GetBl();
            currentTester = new Tester { TesterBirthDate = new DateTime(), TesterWorkHours = mat,TesterAddress=new Address("",0,"") }; //creates a new tester for current tester with deafult values 
            DataContext = currentTester; //sets the current tester in DataContext
            this.testerGenderComboBox.ItemsSource = Enum.GetValues(typeof(BE.MyEnum.Gender));
            this.testerProfessionComboBox.ItemsSource = Enum.GetValues(typeof(BE.MyEnum.TypeOfCar));


            //sets the values of the matrix of the current tester in the user's matrix
            TesterHours.aa.IsChecked = currentTester.TesterWorkHours[0, 0];
            TesterHours.ab.IsChecked = currentTester.TesterWorkHours[0, 1];
            TesterHours.ac.IsChecked = currentTester.TesterWorkHours[0, 2];
            TesterHours.ad.IsChecked = currentTester.TesterWorkHours[0, 3];
            TesterHours.ae.IsChecked = currentTester.TesterWorkHours[0, 4];
            TesterHours.af.IsChecked = currentTester.TesterWorkHours[0, 5];
            TesterHours.ba.IsChecked = currentTester.TesterWorkHours[1, 0];
            TesterHours.bb.IsChecked = currentTester.TesterWorkHours[1, 1];
            TesterHours.bc.IsChecked = currentTester.TesterWorkHours[1, 2];
            TesterHours.bd.IsChecked = currentTester.TesterWorkHours[1, 3];
            TesterHours.be.IsChecked = currentTester.TesterWorkHours[1, 4];
            TesterHours.bf.IsChecked = currentTester.TesterWorkHours[1, 5];
            TesterHours.ca.IsChecked = currentTester.TesterWorkHours[2, 0];
            TesterHours.cb.IsChecked = currentTester.TesterWorkHours[2, 1];
            TesterHours.cc.IsChecked = currentTester.TesterWorkHours[2, 2];
            TesterHours.cd.IsChecked = currentTester.TesterWorkHours[2, 3];
            TesterHours.ce.IsChecked = currentTester.TesterWorkHours[2, 4];
            TesterHours.cf.IsChecked = currentTester.TesterWorkHours[2, 5];
            TesterHours.da.IsChecked = currentTester.TesterWorkHours[3, 0];
            TesterHours.db.IsChecked = currentTester.TesterWorkHours[3, 1];
            TesterHours.dc.IsChecked = currentTester.TesterWorkHours[3, 2];
            TesterHours.dd.IsChecked = currentTester.TesterWorkHours[3, 3];
            TesterHours.de.IsChecked = currentTester.TesterWorkHours[3, 4];
            TesterHours.df.IsChecked = currentTester.TesterWorkHours[3, 5];
            TesterHours.ea.IsChecked = currentTester.TesterWorkHours[4, 0];
            TesterHours.eb.IsChecked = currentTester.TesterWorkHours[4, 1];
            TesterHours.ec.IsChecked = currentTester.TesterWorkHours[4, 2];
            TesterHours.ed.IsChecked = currentTester.TesterWorkHours[4, 3];
            TesterHours.ee.IsChecked = currentTester.TesterWorkHours[4, 4];
            TesterHours.ef.IsChecked = currentTester.TesterWorkHours[4, 5];
        }
        /// <summary>
        /// This function will insert the appropriate values into the corresponding fields when we press on the button "submit"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
           try
           {
                // the value that exists in the matrix is put in the current tester
            currentTester.TesterWorkHours[0, 0] = CheckBoxValue(TesterHours.aa.IsChecked.Value);
            currentTester.TesterWorkHours[0, 1] = CheckBoxValue(TesterHours.ab.IsChecked.Value);
            currentTester.TesterWorkHours[0, 2] = CheckBoxValue(TesterHours.ac.IsChecked.Value);
            currentTester.TesterWorkHours[0, 3] = CheckBoxValue(TesterHours.ad.IsChecked.Value);
            currentTester.TesterWorkHours[0, 4] = CheckBoxValue(TesterHours.ae.IsChecked.Value);
            currentTester.TesterWorkHours[0, 5] = CheckBoxValue(TesterHours.af.IsChecked.Value);
            currentTester.TesterWorkHours[1, 0] = CheckBoxValue(TesterHours.ba.IsChecked.Value);
            currentTester.TesterWorkHours[1, 1] = CheckBoxValue(TesterHours.bb.IsChecked.Value);
            currentTester.TesterWorkHours[1, 2] = CheckBoxValue(TesterHours.bc.IsChecked.Value);
            currentTester.TesterWorkHours[1, 3] = CheckBoxValue(TesterHours.bd.IsChecked.Value);
            currentTester.TesterWorkHours[1, 4] = CheckBoxValue(TesterHours.be.IsChecked.Value);
            currentTester.TesterWorkHours[1, 5] = CheckBoxValue(TesterHours.bf.IsChecked.Value);
            currentTester.TesterWorkHours[2, 0] = CheckBoxValue(TesterHours.ca.IsChecked.Value);
            currentTester.TesterWorkHours[2, 1] = CheckBoxValue(TesterHours.cb.IsChecked.Value);
            currentTester.TesterWorkHours[2, 2] = CheckBoxValue(TesterHours.cc.IsChecked.Value);
            currentTester.TesterWorkHours[2, 3] = CheckBoxValue(TesterHours.cd.IsChecked.Value);
            currentTester.TesterWorkHours[2, 4] = CheckBoxValue(TesterHours.ce.IsChecked.Value);
            currentTester.TesterWorkHours[2, 5] = CheckBoxValue(TesterHours.cf.IsChecked.Value);
            currentTester.TesterWorkHours[3, 0] = CheckBoxValue(TesterHours.da.IsChecked.Value);
            currentTester.TesterWorkHours[3, 1] = CheckBoxValue(TesterHours.db.IsChecked.Value);
            currentTester.TesterWorkHours[3, 2] = CheckBoxValue(TesterHours.dc.IsChecked.Value);
            currentTester.TesterWorkHours[3, 3] = CheckBoxValue(TesterHours.dd.IsChecked.Value);
            currentTester.TesterWorkHours[3, 4] = CheckBoxValue(TesterHours.de.IsChecked.Value);
            currentTester.TesterWorkHours[3, 5] = CheckBoxValue(TesterHours.df.IsChecked.Value);
            currentTester.TesterWorkHours[4, 0] = CheckBoxValue(TesterHours.ea.IsChecked.Value);
            currentTester.TesterWorkHours[4, 1] = CheckBoxValue(TesterHours.eb.IsChecked.Value);
            currentTester.TesterWorkHours[4, 2] = CheckBoxValue(TesterHours.ec.IsChecked.Value);
            currentTester.TesterWorkHours[4, 3] = CheckBoxValue(TesterHours.ed.IsChecked.Value);
            currentTester.TesterWorkHours[4, 4] = CheckBoxValue(TesterHours.ee.IsChecked.Value);
            currentTester.TesterWorkHours[4, 5] = CheckBoxValue(TesterHours.ef.IsChecked.Value);
                if (testerMaxTestsTextBox.Text=="")
                    throw new Exception("Must have max distance");
                if (testerMaxTestsTextBox.Text == "")
                    throw new Exception("Must have a maximum amount of tests");
                MessageBox.Show(currentTester.ToString()); //shows the tester detaild on the screen
            
                BL.AddTester(currentTester); //adds the current tester to the list of testers
                currentTester = new Tester(); //creates a new tester for current tester so the addition can work again well
                DataContext = currentTester; //sets the current tester in DataContext

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }


        /// <summary>
        /// This function will place the user's choice in the "Gender" field of the tester
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TesterGenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentTester.TesterGender = (BE.MyEnum.Gender)(testerGenderComboBox.SelectedItem);
        }

        /// <summary>
        /// This function will place the user's choice in the "Profession" (type of car) field of the tester
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

    }
}
////////////////
///
