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
    /// Interaction logic for DeserveDriversLicenceWindow.xaml
    /// </summary>
    public partial class DeserveDriversLicenceWindow : Window
    {
        IBL BL;
        bool flag = false;
        public DeserveDriversLicenceWindow()//constractor
        {
            InitializeComponent();
            BL = Bl_imp.GetBl();
            
        }


        /// <summary>
        /// This function returns if the trainee deserves a drivers licence
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void DeserveDriversLicence_Click(object sender, RoutedEventArgs e)
        {
            flag = false;//for reuse
            listView.Items.Clear();//in case of listview that showed items before
            foreach (var trainee in BL.GetTrainees())
            {
                if (BL.DeserveDriversLicence(trainee))//if passed
                {
                    flag= true;
                    listView.Items.Add(trainee);
                }

            }
            if(!flag)
            {
                listView.Items.Add("No One Passed Yet");
            }
           
        }
    }
}
