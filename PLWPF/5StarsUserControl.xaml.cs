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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for _5StarsUserControl.xaml
    /// </summary>
    public partial class _5StarsUserControl : UserControl
    {
        public _5StarsUserControl()
        {
            InitializeComponent();
        }
        Tester currentTester;
        SolidColorBrush yellow = new SolidColorBrush(Color.FromRgb(255, 204, 0));//creates the color yellow by its RGB values of the star
        SolidColorBrush white = new SolidColorBrush(Color.FromRgb(255, 255, 255));//creates the color white by its RGB values of the star
        int selected = 0; //at the begining nothing is selected


        /// <summary>
        /// This function colors the first star in yellow and the rest of the stars will be white when the mouse is on the first star
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void S1_MouseEnter(object sender, MouseEventArgs e)
        {
            s1.Fill = yellow;//when the mouse is on the first star, the star will be yellow and the rest of the stars will be white
            s2.Fill = white;
            s3.Fill = white;
            s4.Fill = white;
            s5.Fill = white; 
        }

        /// <summary>
        /// This function colors the 2 first stars in yellow and the rest of the stars will be white when the mouse is on the second star
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void S2_MouseEnter(object sender, MouseEventArgs e)
        {
            //when the mouse is on the second star, the first star and the second star will be yellow and the rest of the stars will be white
            s1.Fill = yellow;
            s2.Fill = yellow;
            s3.Fill = white;
            s4.Fill = white;
            s5.Fill = white;
        }

        /// <summary>
        /// This function colors the 3 first stars in yellow and the rest of the stars will be white when the mouse is on the third star
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void S3_MouseEnter(object sender, MouseEventArgs e)
        {
            //when the mouse is on the third star, the first star, the second star and the third star will be yellow and the rest of the stars will be white
            s1.Fill = yellow;
            s2.Fill = yellow;
            s3.Fill = yellow;
            s4.Fill = white;
            s5.Fill = white;
        }

        /// <summary>
        /// This function colors the 4 first stars in yellow and the rest of the stars will be white when the mouse is on the forth star
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void S4_MouseEnter(object sender, MouseEventArgs e)
        {
            //when the mouse is on the forth star, the first star, the second star, the third star and the forth star will be yellow
            //and the rest of the stars will be white
            s1.Fill = yellow;
            s2.Fill = yellow;
            s3.Fill = yellow;
            s4.Fill = yellow;
            s5.Fill = white;
        }

        /// <summary>
        /// This function colors the 5 stars in yellow when the mouse is on the forth star
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void S5_MouseEnter(object sender, MouseEventArgs e)
        {
            //when the mouse is on the fifth star, the first star, the second star, the third star, the forth star and the fifth star will be yellow
            s1.Fill = yellow;
            s2.Fill = yellow;
            s3.Fill = yellow;
            s4.Fill = yellow;
            s5.Fill = yellow;
        }

        /// <summary>
        /// This function colors the first star in white when the mouse leaves the star
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void S1_MouseLeave(object sender, MouseEventArgs e)
        {
            s1.Fill = white; //when the mouse leaves the first star, the star will be white again
        }

        /// <summary>
        /// This function colors the 2 first stars in white when the mouse leaves the second star
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void S2_MouseLeave(object sender, MouseEventArgs e)
        {
            //when the mouse leaves the second star, the first star and the second star will be white again
            s1.Fill = white;
            s2.Fill = white;
        }

        /// <summary>
        /// This function colors the 3 first stars in white when the mouse leaves the third star
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void S3_MouseLeave(object sender, MouseEventArgs e)
        {
            //when the mouse leaves the third star, the first star, the second star and the third star will be white again
            s1.Fill = white;
            s2.Fill = white;
            s3.Fill = white;
        }

        /// <summary>
        /// This function colors the 4 first stars in white when the mouse leaves the forth star
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void S4_MouseLeave(object sender, MouseEventArgs e)
        {
            //when the mouse leaves the forth star, the first star, the second star, the third star and the forth star will be white again
            s1.Fill = white;
            s2.Fill = white;
            s3.Fill = white;
            s4.Fill = white;
        }

        /// <summary>
        /// This function colors all of the stars in white when the mouse leaves the fifth star
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void S5_MouseLeave(object sender, MouseEventArgs e)
        {
            //when the mouse leaves the fifth star, the first star, the second star, the third star, the forth star and the fifth star will be white again
            s1.Fill = white;
            s2.Fill = white;
            s3.Fill = white;
            s4.Fill = white;
            s5.Fill = white;
        }

        /// <summary>
        /// This function colors the first star in yellow and the rest of the stars in white when the mouse leaves the first star
        /// it is like the click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void S1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selected = 1; //we selected the first star
            currentTester.TesterRatingList.Add(selected); //add the number of stars that the user choose to the list of all the tester's rating
            s1.Fill = yellow;
            s2.Fill = white;
            s3.Fill = white;
            s4.Fill = white;
            s5.Fill = white;
        }

        /// <summary>
        /// This function colors the 2 first stars in yellow and the rest of the stars in white when the mouse leaves the second star
        /// it is like the click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void S2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selected = 2; //we selected the first star and the second star
            currentTester.TesterRatingList.Add(selected); //add the number of stars that the user choose to the list of all the tester's rating
            s1.Fill = yellow;
            s2.Fill = yellow;
            s3.Fill = white;
            s4.Fill = white;
            s5.Fill = white;
        }

        /// <summary>
        /// This function colors the 3 first stars in yellow and the rest of the stars in white when the mouse leaves the third star
        /// it is like the click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void S3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selected = 3;//we selected the first star the second star and the third star
            currentTester.TesterRatingList.Add(selected); //add the number of stars that the user choose to the list of all the tester's rating
            s1.Fill = yellow;
            s2.Fill = yellow;
            s3.Fill = yellow;
            s4.Fill = white;
            s5.Fill = white;
        }

        /// <summary>
        /// This function colors the 4 first stars in yellow and the rest of the stars in white when the mouse leaves the forth star
        /// it is like the click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void S4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selected = 4;//we selected the first star the second star the third star and the forth star
            currentTester.TesterRatingList.Add(selected); //add the number of stars that the user choose to the list of all the tester's rating
            s1.Fill = yellow;
            s2.Fill = yellow;
            s3.Fill = yellow;
            s4.Fill = yellow;
            s5.Fill = white;
        }

        /// <summary>
        /// This function colors all of the stars in yellow when the mouse leaves the fifth star
        /// it is like the click event
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void S5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selected = 5;//we selected the first star the second star the third star the forth star and the fifth star
            currentTester.TesterRatingList.Add(selected); //add the number of stars that the user choose to the list of all the tester's rating
            s1.Fill = yellow;
            s2.Fill = yellow;
            s3.Fill = yellow;
            s4.Fill = yellow;
            s5.Fill = yellow;
        }


        /// <summary>
        /// This function colors the corresponding stars in the appropriate colors and leaves the selection even after exiting the user control range
        /// </summary>
        /// <param name="sender">Who is sensing the event</param>
        /// <param name="e">Details of the event occurred</param>
        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            if (selected == 1)
            {
                s1.Fill = yellow;
                s2.Fill = white;
                s3.Fill = white;
                s4.Fill = white;
                s5.Fill = white;
            }

            if (selected == 2)
            {
                s1.Fill = yellow;
                s2.Fill = yellow;
                s3.Fill = white;
                s4.Fill = white;
                s5.Fill = white;
            }

            if (selected == 3)
            {
                s1.Fill = yellow;
                s2.Fill = yellow;
                s3.Fill = yellow;
                s4.Fill = white;
                s5.Fill = white;
            }

            if (selected == 4)
            {
                s1.Fill = yellow;
                s2.Fill = yellow;
                s3.Fill = yellow;
                s4.Fill = yellow;
                s5.Fill = white;
            }

            if (selected == 5)
            {
                s1.Fill = yellow;
                s2.Fill = yellow;
                s3.Fill = yellow;
                s4.Fill = yellow;
                s5.Fill = yellow;
            }
        }
    }
}
