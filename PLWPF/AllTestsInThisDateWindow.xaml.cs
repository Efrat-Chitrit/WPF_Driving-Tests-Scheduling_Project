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
    /// Interaction logic for AllTestsInThisDateWindow.xaml
    /// </summary>
    public partial class AllTestsInThisDateWindow : Window
    {
        DateTime date;
        IBL BL;
        public AllTestsInThisDateWindow()
        {
            InitializeComponent();
            BL = Bl_imp.GetBl();
        }
        /// <summary>
        /// This function returns all the avaliavle testers in this month
        /// This is a sighnup function for a click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void AllTestsInThisDate_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();//in case of listview that showed items before
            var tests = BL.AllTestsInThisDate(date);
            listView.Items.Add("Month: "+date.Month);
            foreach (var test in tests)
            {
                    listView.Items.Add(test);  
            }
        }

        /// <summary>
        /// when we changing the date on the DatePicker it will change in "date" also
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void DatePicker_selectledDateChanged(object sender, SelectionChangedEventArgs e)
        {
            date =(DateTime) (datePicker.SelectedDate);
        }
    }
}
