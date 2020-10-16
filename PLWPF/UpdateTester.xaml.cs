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
    /// Interaction logic for UpdateTester.xaml
    /// </summary>
    public partial class UpdateTester : Window
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
        /// This function updates a new tester
        /// </summary>
        public UpdateTester()
        {
            InitializeComponent();
            BL = Bl_imp.GetBl();
            bool?[,] mat = new bool?[, ]
            {
                { true,true,true,true,true,true },
                { true,true,true,true,true,true },
                { true,true,true,true,true,true },
                { true,true,true,true,true,true },
                { true,true,true,true,true,true },
                
             };
            //creates a new tester for current tester with deafult values
            currentTester = new Tester { TesterBirthDate = new DateTime() ,TesterWorkHours=mat };
            DataContext = currentTester;//sets the current tester in DataContext
            this.testerGenderComboBox.ItemsSource = Enum.GetValues(typeof(BE.MyEnum.Gender));
            this.testerProfessionComboBox.ItemsSource = Enum.GetValues(typeof(BE.MyEnum.TypeOfCar));
            try
            {
                //in all the lines where there is null, we do not allow clicking the button because it is not part of the tester's working hours
                TesterHours.aa.IsChecked = currentTester.TesterWorkHours[0, 0];
                if (currentTester.TesterWorkHours[0, 0] == null) TesterHours.aa.IsEnabled = false;
                TesterHours.ab.IsChecked = currentTester.TesterWorkHours[0, 1];
                if (currentTester.TesterWorkHours[0, 1] == null) TesterHours.ab.IsEnabled = false;
                TesterHours.ac.IsChecked = currentTester.TesterWorkHours[0, 2];
                if (currentTester.TesterWorkHours[0, 2] == null) TesterHours.ac.IsEnabled = false;
                TesterHours.ad.IsChecked = currentTester.TesterWorkHours[0, 3];
                if (currentTester.TesterWorkHours[0, 3] == null) TesterHours.ad.IsEnabled = false;
                TesterHours.ae.IsChecked = currentTester.TesterWorkHours[0, 4];
                if (currentTester.TesterWorkHours[0, 4] == null) TesterHours.ae.IsEnabled = false;
                TesterHours.af.IsChecked = currentTester.TesterWorkHours[0, 5];
                if (currentTester.TesterWorkHours[0, 5] == null) TesterHours.af.IsEnabled = false;
                TesterHours.ba.IsChecked = currentTester.TesterWorkHours[1, 0];
                if (currentTester.TesterWorkHours[1, 0] == null) TesterHours.ba.IsEnabled = false;
                TesterHours.bb.IsChecked = currentTester.TesterWorkHours[1, 1];
                if (currentTester.TesterWorkHours[1, 1] == null) TesterHours.bb.IsEnabled = false;
                TesterHours.bc.IsChecked = currentTester.TesterWorkHours[1, 2];
                if (currentTester.TesterWorkHours[1, 2] == null) TesterHours.bc.IsEnabled = false;
                TesterHours.bd.IsChecked = currentTester.TesterWorkHours[1, 3];
                if (currentTester.TesterWorkHours[1, 3] == null) TesterHours.bd.IsEnabled = false;
                TesterHours.be.IsChecked = currentTester.TesterWorkHours[1, 4];
                if (currentTester.TesterWorkHours[1, 4] == null) TesterHours.be.IsEnabled = false;
                TesterHours.bf.IsChecked = currentTester.TesterWorkHours[1, 5];
                if (currentTester.TesterWorkHours[1, 5] == null) TesterHours.bf.IsEnabled = false;
                TesterHours.ca.IsChecked = currentTester.TesterWorkHours[2, 0];
                if (currentTester.TesterWorkHours[2, 0] == null) TesterHours.ca.IsEnabled = false;
                TesterHours.cb.IsChecked = currentTester.TesterWorkHours[2, 1];
                if (currentTester.TesterWorkHours[2, 1] == null) TesterHours.cb.IsEnabled = false;
                TesterHours.cc.IsChecked = currentTester.TesterWorkHours[2, 2];
                if (currentTester.TesterWorkHours[2, 2] == null) TesterHours.cc.IsEnabled = false;
                TesterHours.cd.IsChecked = currentTester.TesterWorkHours[2, 3];
                if (currentTester.TesterWorkHours[2, 3] == null) TesterHours.cd.IsEnabled = false;
                TesterHours.ce.IsChecked = currentTester.TesterWorkHours[2, 4];
                if (currentTester.TesterWorkHours[2, 4] == null) TesterHours.ce.IsEnabled = false;
                TesterHours.cf.IsChecked = currentTester.TesterWorkHours[2, 5];
                if (currentTester.TesterWorkHours[2, 5] == null) TesterHours.cf.IsEnabled = false;
                TesterHours.da.IsChecked = currentTester.TesterWorkHours[3, 0];
                if (currentTester.TesterWorkHours[3, 0] == null) TesterHours.da.IsEnabled = false;
                TesterHours.db.IsChecked = currentTester.TesterWorkHours[3, 1];
                if (currentTester.TesterWorkHours[3, 1] == null) TesterHours.db.IsEnabled = false;
                TesterHours.dc.IsChecked = currentTester.TesterWorkHours[3, 2];
                if (currentTester.TesterWorkHours[3, 2] == null) TesterHours.dc.IsEnabled = false;
                TesterHours.dd.IsChecked = currentTester.TesterWorkHours[3, 3];
                if (currentTester.TesterWorkHours[3, 3] == null) TesterHours.dd.IsEnabled = false;
                TesterHours.de.IsChecked = currentTester.TesterWorkHours[3, 4];
                if (currentTester.TesterWorkHours[3, 4] == null) TesterHours.de.IsEnabled = false;
                TesterHours.df.IsChecked = currentTester.TesterWorkHours[3, 5];
                if (currentTester.TesterWorkHours[3, 5] == null) TesterHours.df.IsEnabled = false;
                TesterHours.ea.IsChecked = currentTester.TesterWorkHours[4, 0];
                if (currentTester.TesterWorkHours[4, 0] == null) TesterHours.ea.IsEnabled = false;
                TesterHours.eb.IsChecked = currentTester.TesterWorkHours[4, 1];
                if (currentTester.TesterWorkHours[4, 1] == null) TesterHours.eb.IsEnabled = false;
                TesterHours.ec.IsChecked = currentTester.TesterWorkHours[4, 2];
                if (currentTester.TesterWorkHours[4, 2] == null) TesterHours.ec.IsEnabled = false;
                TesterHours.ed.IsChecked = currentTester.TesterWorkHours[4, 3];
                if (currentTester.TesterWorkHours[4, 3] == null) TesterHours.ed.IsEnabled = false;
                TesterHours.ee.IsChecked = currentTester.TesterWorkHours[4, 4];
                if (currentTester.TesterWorkHours[4, 4] == null) TesterHours.ee.IsEnabled = false;
                TesterHours.ef.IsChecked = currentTester.TesterWorkHours[4, 5];
                if (currentTester.TesterWorkHours[4, 5] == null) TesterHours.ef.IsEnabled = false;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cannot add false to the matrix!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// This function will insert the appropriate values into the corresponding fields when we press on the button "submit"
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            //if you can click the button, we will enter the value in the appropriate field
            if(TesterHours.aa.IsEnabled)currentTester.TesterWorkHours[0, 0] = CheckBoxValue(TesterHours.aa.IsChecked.Value);
            if (TesterHours.ab.IsEnabled) currentTester.TesterWorkHours[0, 1] = CheckBoxValue(TesterHours.ab.IsChecked.Value);
            if (TesterHours.ac.IsEnabled) currentTester.TesterWorkHours[0, 2] = CheckBoxValue(TesterHours.ac.IsChecked.Value);
            if (TesterHours.ad.IsEnabled) currentTester.TesterWorkHours[0, 3] = CheckBoxValue(TesterHours.ad.IsChecked.Value);
            if (TesterHours.ae.IsEnabled) currentTester.TesterWorkHours[0, 4] = CheckBoxValue(TesterHours.ae.IsChecked.Value);
            if (TesterHours.af.IsEnabled) currentTester.TesterWorkHours[0, 5] = CheckBoxValue(TesterHours.af.IsChecked.Value);
            if (TesterHours.ba.IsEnabled) currentTester.TesterWorkHours[1, 0] = CheckBoxValue(TesterHours.ba.IsChecked.Value);
            if (TesterHours.bb.IsEnabled) currentTester.TesterWorkHours[1, 1] = CheckBoxValue(TesterHours.bb.IsChecked.Value);
            if (TesterHours.bc.IsEnabled) currentTester.TesterWorkHours[1, 2] = CheckBoxValue(TesterHours.bc.IsChecked.Value);
            if (TesterHours.bd.IsEnabled) currentTester.TesterWorkHours[1, 3] = CheckBoxValue(TesterHours.bd.IsChecked.Value);
            if (TesterHours.be.IsEnabled) currentTester.TesterWorkHours[1, 4] = CheckBoxValue(TesterHours.be.IsChecked.Value);
            if (TesterHours.bf.IsEnabled) currentTester.TesterWorkHours[1, 5] = CheckBoxValue(TesterHours.bf.IsChecked.Value);
            if (TesterHours.ca.IsEnabled) currentTester.TesterWorkHours[2, 0] = CheckBoxValue(TesterHours.ca.IsChecked.Value);
            if (TesterHours.cb.IsEnabled) currentTester.TesterWorkHours[2, 1] = CheckBoxValue(TesterHours.cb.IsChecked.Value);
            if (TesterHours.cc.IsEnabled) currentTester.TesterWorkHours[2, 2] = CheckBoxValue(TesterHours.cc.IsChecked.Value);
            if (TesterHours.cd.IsEnabled) currentTester.TesterWorkHours[2, 3] = CheckBoxValue(TesterHours.cd.IsChecked.Value);
            if (TesterHours.ce.IsEnabled) currentTester.TesterWorkHours[2, 4] = CheckBoxValue(TesterHours.ce.IsChecked.Value);
            if (TesterHours.cf.IsEnabled) currentTester.TesterWorkHours[2, 5] = CheckBoxValue(TesterHours.cf.IsChecked.Value);
            if (TesterHours.da.IsEnabled) currentTester.TesterWorkHours[3, 0] = CheckBoxValue(TesterHours.da.IsChecked.Value);
            if (TesterHours.db.IsEnabled) currentTester.TesterWorkHours[3, 1] = CheckBoxValue(TesterHours.db.IsChecked.Value);
            if (TesterHours.dc.IsEnabled) currentTester.TesterWorkHours[3, 2] = CheckBoxValue(TesterHours.dc.IsChecked.Value);
            if (TesterHours.dd.IsEnabled) currentTester.TesterWorkHours[3, 3] = CheckBoxValue(TesterHours.dd.IsChecked.Value);
            if (TesterHours.de.IsEnabled) currentTester.TesterWorkHours[3, 4] = CheckBoxValue(TesterHours.de.IsChecked.Value);
            if (TesterHours.df.IsEnabled) currentTester.TesterWorkHours[3, 5] = CheckBoxValue(TesterHours.df.IsChecked.Value);
            if (TesterHours.ea.IsEnabled) currentTester.TesterWorkHours[4, 0] = CheckBoxValue(TesterHours.ea.IsChecked.Value);
            if (TesterHours.eb.IsEnabled) currentTester.TesterWorkHours[4, 1] = CheckBoxValue(TesterHours.eb.IsChecked.Value);
            if (TesterHours.ec.IsEnabled) currentTester.TesterWorkHours[4, 2] = CheckBoxValue(TesterHours.ec.IsChecked.Value);
            if (TesterHours.ed.IsEnabled) currentTester.TesterWorkHours[4, 3] = CheckBoxValue(TesterHours.ed.IsChecked.Value);
            if (TesterHours.ee.IsEnabled) currentTester.TesterWorkHours[4, 4] = CheckBoxValue(TesterHours.ee.IsChecked.Value);
            if (TesterHours.ef.IsEnabled) currentTester.TesterWorkHours[4, 5] = CheckBoxValue(TesterHours.ef.IsChecked.Value);

            MessageBox.Show(currentTester.ToString());
            try
            {
                BL.UpdateTester(currentTester);
                currentTester = new Tester();//creates a new tester for current tester so the update can work well again
                DataContext = currentTester;//sets the current test in DataContext so the update can work well again
                testerIdTextBox.IsEnabled = true; //so the update can work well again
                //initialize all the buttons in the matri so that they can be pressed
                TesterHours.aa.IsEnabled = TesterHours.ab.IsEnabled = TesterHours.ac.IsEnabled = TesterHours.ad.IsEnabled = TesterHours.ae.IsEnabled = TesterHours.af.IsEnabled = TesterHours.ba.IsEnabled = TesterHours.bb.IsEnabled = TesterHours.bc.IsEnabled = TesterHours.bd.IsEnabled = TesterHours.be.IsEnabled = TesterHours.bf.IsEnabled = TesterHours.ca.IsEnabled = TesterHours.cb.IsEnabled = TesterHours.cc.IsEnabled = TesterHours.cd.IsEnabled = TesterHours.ce.IsEnabled = TesterHours.cf.IsEnabled = TesterHours.da.IsEnabled = TesterHours.db.IsEnabled = TesterHours.dc.IsEnabled = TesterHours.dd.IsEnabled = TesterHours.de.IsEnabled = TesterHours.df.IsEnabled = TesterHours.ea.IsEnabled = TesterHours.eb.IsEnabled = TesterHours.ec.IsEnabled = TesterHours.ed.IsEnabled = TesterHours.ee.IsEnabled = TesterHours.ef.IsEnabled = true;
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }


        /// <summary>
        /// This function will place the user's new choice in the "Gender" field of the tester
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void TesterGenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentTester.TesterGender = (BE.MyEnum.Gender)(testerGenderComboBox.SelectedItem);
        }

        /// <summary>
        /// This function will place the user's new choice in the "Profession" (type of car) field of the tester
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
        /// Event lost focus - when we found a tester with this ID it shows his details and locks this text box
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
                //sets the values in the user's matrix 
                TesterHours.aa.IsChecked = currentTester.TesterWorkHours[0, 0];
                if (currentTester.TesterWorkHours[0, 0] == null) TesterHours.aa.IsEnabled = false;
                TesterHours.ab.IsChecked = currentTester.TesterWorkHours[0, 1];
                if (currentTester.TesterWorkHours[0, 1] == null) TesterHours.ab.IsEnabled = false;
                TesterHours.ac.IsChecked = currentTester.TesterWorkHours[0, 2];
                if (currentTester.TesterWorkHours[0, 2] == null) TesterHours.ac.IsEnabled = false;
                TesterHours.ad.IsChecked = currentTester.TesterWorkHours[0, 3];
                if (currentTester.TesterWorkHours[0, 3] == null) TesterHours.ad.IsEnabled = false;
                TesterHours.ae.IsChecked = currentTester.TesterWorkHours[0, 4];
                if (currentTester.TesterWorkHours[0, 4] == null) TesterHours.ae.IsEnabled = false;
                TesterHours.af.IsChecked = currentTester.TesterWorkHours[0, 5];
                if (currentTester.TesterWorkHours[0, 5] == null) TesterHours.af.IsEnabled = false;
                TesterHours.ba.IsChecked = currentTester.TesterWorkHours[1, 0];
                if (currentTester.TesterWorkHours[1, 0] == null) TesterHours.ba.IsEnabled = false;
                TesterHours.bb.IsChecked = currentTester.TesterWorkHours[1, 1];
                if (currentTester.TesterWorkHours[1, 1] == null) TesterHours.bb.IsEnabled = false;
                TesterHours.bc.IsChecked = currentTester.TesterWorkHours[1, 2];
                if (currentTester.TesterWorkHours[1, 2] == null) TesterHours.bc.IsEnabled = false;
                TesterHours.bd.IsChecked = currentTester.TesterWorkHours[1, 3];
                if (currentTester.TesterWorkHours[1, 3] == null) TesterHours.bd.IsEnabled = false;
                TesterHours.be.IsChecked = currentTester.TesterWorkHours[1, 4];
                if (currentTester.TesterWorkHours[1, 4] == null) TesterHours.be.IsEnabled = false;
                TesterHours.bf.IsChecked = currentTester.TesterWorkHours[1, 5];
                if (currentTester.TesterWorkHours[1, 5] == null) TesterHours.bf.IsEnabled = false;
                TesterHours.ca.IsChecked = currentTester.TesterWorkHours[2, 0];
                if (currentTester.TesterWorkHours[2, 0] == null) TesterHours.ca.IsEnabled = false;
                TesterHours.cb.IsChecked = currentTester.TesterWorkHours[2, 1];
                if (currentTester.TesterWorkHours[2, 1] == null) TesterHours.cb.IsEnabled = false;
                TesterHours.cc.IsChecked = currentTester.TesterWorkHours[2, 2];
                if (currentTester.TesterWorkHours[2, 2] == null) TesterHours.cc.IsEnabled = false;
                TesterHours.cd.IsChecked = currentTester.TesterWorkHours[2, 3];
                if (currentTester.TesterWorkHours[2, 3] == null) TesterHours.cd.IsEnabled = false;
                TesterHours.ce.IsChecked = currentTester.TesterWorkHours[2, 4];
                if (currentTester.TesterWorkHours[2, 4] == null) TesterHours.ce.IsEnabled = false;
                TesterHours.cf.IsChecked = currentTester.TesterWorkHours[2, 5];
                if (currentTester.TesterWorkHours[2, 5] == null) TesterHours.cf.IsEnabled = false;
                TesterHours.da.IsChecked = currentTester.TesterWorkHours[3, 0];
                if (currentTester.TesterWorkHours[3, 0] == null) TesterHours.da.IsEnabled = false;
                TesterHours.db.IsChecked = currentTester.TesterWorkHours[3, 1];
                if (currentTester.TesterWorkHours[3, 1] == null) TesterHours.db.IsEnabled = false;
                TesterHours.dc.IsChecked = currentTester.TesterWorkHours[3, 2];
                if (currentTester.TesterWorkHours[3, 2] == null) TesterHours.dc.IsEnabled = false;
                TesterHours.dd.IsChecked = currentTester.TesterWorkHours[3, 3];
                if (currentTester.TesterWorkHours[3, 3] == null) TesterHours.dd.IsEnabled = false;
                TesterHours.de.IsChecked = currentTester.TesterWorkHours[3, 4];
                if (currentTester.TesterWorkHours[3, 4] == null) TesterHours.de.IsEnabled = false;
                TesterHours.df.IsChecked = currentTester.TesterWorkHours[3, 5];
                if (currentTester.TesterWorkHours[3, 5] == null) TesterHours.df.IsEnabled = false;
                TesterHours.ea.IsChecked = currentTester.TesterWorkHours[4, 0];
                if (currentTester.TesterWorkHours[4, 0] == null) TesterHours.ea.IsEnabled = false;
                TesterHours.eb.IsChecked = currentTester.TesterWorkHours[4, 1];
                if (currentTester.TesterWorkHours[4, 1] == null) TesterHours.eb.IsEnabled = false;
                TesterHours.ec.IsChecked = currentTester.TesterWorkHours[4, 2];
                if (currentTester.TesterWorkHours[4, 2] == null) TesterHours.ec.IsEnabled = false;
                TesterHours.ed.IsChecked = currentTester.TesterWorkHours[4, 3];
                if (currentTester.TesterWorkHours[4, 3] == null) TesterHours.ed.IsEnabled = false;
                TesterHours.ee.IsChecked = currentTester.TesterWorkHours[4, 4];
                if (currentTester.TesterWorkHours[4, 4] == null) TesterHours.ee.IsEnabled = false;
                TesterHours.ef.IsChecked = currentTester.TesterWorkHours[4, 5];
                if (currentTester.TesterWorkHours[4, 5] == null) TesterHours.ef.IsEnabled = false;


            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    
    }
}
