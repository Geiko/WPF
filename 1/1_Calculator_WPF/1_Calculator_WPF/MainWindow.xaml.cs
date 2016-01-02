/*
    1.  С использыванием wpf создать приложение калькулятор. 
    Интерфейс приложения создать декларативно средствами языка XAML
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace _1_Calculator_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// First user value.
        /// </summary>
        public double Value1 { get; set; }



        /// <summary>
        /// Second user value.
        /// </summary>
        public double Value2 { get; set; }



        /// <summary>
        /// Reference to Operator Interface.
        /// </summary>
        IOperator _oper;



        /// <summary>
        /// Reference to user method of calculation.
        /// </summary>
        CalculateDelegate CurrentDelegate;
        


        /// <summary>
        /// It is a Constructor.
        /// </summary>
        public MainWindow ( )
        {
            InitializeComponent ( );

            this.Value1 = 0;
            this.Value2 = 0;

            _oper = new Operator ( );

        }



        #region Digital Block
        /// <summary>
        /// It is a Hendler for button "+/-".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b6_Click ( object sender, RoutedEventArgs e )
        {
            if ( !this.textBoxResult.Text.StartsWith ( "-" ) && double.Parse ( this.textBoxResult.Text ) != 0)
            {
                this.textBoxResult.Text = "-" + this.textBoxResult.Text;
                return;
            }

            if ( this.textBoxResult.Text.StartsWith ( "-" ) )
            {
                this.textBoxResult.Text = this.textBoxResult.Text.Substring ( 1 );       
            }
        }

        /// <summary>
        /// It is a Hendler for button "0".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b7_Click ( object sender, RoutedEventArgs e )
        {
            PrintVar ( "0" );
        }

        /// <summary>
        /// It is a Hendler for button ".".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b8_Click ( object sender, RoutedEventArgs e )
        {
            if ( this.textBoxResult.Text.Contains ( "." ) )
                return;

            if ( this.textBoxResult.Text == "0" )
            {
                this.textBoxResult.Text += ".";
                return;
            }

            this.textBoxResult.Text += ".";            
        }

        /// <summary>
        /// It is a Hendler for button "1".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b11_Click ( object sender, RoutedEventArgs e )
        {
            PrintVar ( "1" );
        }


        /// <summary>
        /// It is a Hendler for button "2".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b12_Click ( object sender, RoutedEventArgs e )
        {
            PrintVar ( "2" );
        }


        /// <summary>
        /// It is a Hendler for button "3".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b13_Click ( object sender, RoutedEventArgs e )
        {
            PrintVar ( "3" );
        }


        /// <summary>
        /// It is a Hendler for button "4".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b16_Click ( object sender, RoutedEventArgs e )
        {
            PrintVar ( "4" );
        }


        /// <summary>
        /// It is a Hendler for button "5".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b17_Click ( object sender, RoutedEventArgs e )
        {
            PrintVar ( "5" );
        }


        /// <summary>
        /// It is a Hendler for button "6".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b18_Click ( object sender, RoutedEventArgs e )
        {
            PrintVar ( "6" );
        }


        /// <summary>
        /// It is a Hendler for button "7".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b21_Click ( object sender, RoutedEventArgs e )
        {
            PrintVar ( "7" );
        }


        /// <summary>
        /// It is a Hendler for button "8".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b22_Click ( object sender, RoutedEventArgs e )
        {
            PrintVar ( "8" );
        }


        /// <summary>
        /// It is a Hendler for button "9".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b23_Click ( object sender, RoutedEventArgs e )
        {
            PrintVar ( "9" );
        }


        /// <summary>
        /// This method adds a symbol to the string of the textBox (result window).
        /// </summary>
        /// <param name="Symbol"></param>
        private void PrintVar ( string Symbol )
        {
            if ( this.textBoxResult.Text == "0" )
            {
                this.textBoxResult.Text = Symbol;
                return;
            }

            this.textBoxResult.Text += Symbol;
        }
        #endregion



        #region Operator Blok
        /// <summary>
        /// It is a Hendler for button "sqrt".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bSqrt_Click ( object sender, RoutedEventArgs e )
        {
            assignValue1 ( );

            this.CurrentDelegate = _oper.Sqrt;

            this.textBoxResult.Text = Calculate ( this.CurrentDelegate, this.Value1, this.Value2 );
        }



        /// <summary>
        /// It is a Hendler for button "1/x".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bDivision1ToX_Click ( object sender, RoutedEventArgs e )
        {
            assignValue1 ( );

            this.CurrentDelegate = _oper.Division1ToX;

            this.textBoxResult.Text = Calculate ( this.CurrentDelegate, this.Value1, this.Value2 );
        }



        /// <summary>
        /// It is a Hendler for button "+".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bPlus_Click ( object sender, RoutedEventArgs e )
        {
            assignValue1 ( );

            this.CurrentDelegate = _oper.Add;
        }



        /// <summary>
        /// It is a Hendler for button "-".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bMinus_Click ( object sender, RoutedEventArgs e )
        {
            assignValue1 ( );

            this.CurrentDelegate = _oper.Subtraction;
        }



        /// <summary>
        /// It is a Hendler for button "*".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bMultiplication_Click ( object sender, RoutedEventArgs e )
        {
            assignValue1 ( );

            this.CurrentDelegate = _oper.Multiplication;
        }



        /// <summary>
        /// It is a Hendler for button "/".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bDivision_Click ( object sender, RoutedEventArgs e )
        {
            assignValue1 ( );

            this.CurrentDelegate = _oper.Division;
        }



        /// <summary>
        /// It is a Hendler for button "C".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bClear_Click ( object sender, RoutedEventArgs e )
        {
            this.Value1 = 0;
            this.Value2 = 0;
            this.textBoxResult.Text = "0";
        }



        /// <summary>
        /// It is a Hendler for button "=".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bResult_Click ( object sender, RoutedEventArgs e )
        {
            if ( this.CurrentDelegate != null )
            {
                double result;

                if ( double.TryParse ( this.textBoxResult.Text, out result ) )
                {
                    this.Value2 = result;
                }

                this.textBoxResult.Text = Calculate ( this.CurrentDelegate, this.Value1, this.Value2 );
            }
        }


        /// <summary>
        /// This method returns a result as a string.
        /// </summary>
        /// <param name="method">It is a reference to user method - a delegate.</param>
        /// <param name="value1">It is a first user value.</param>
        /// <param name="value2">It is a second user value.</param>
        /// <returns></returns>
        private string Calculate ( CalculateDelegate method, double value1, double value2 )
        {
            return method ( value1, value2 ).ToString ( );
        }


        /// <summary>
        /// This method assigns first user value.
        /// </summary>
        private void assignValue1 ( )
        {
            double result;
            if ( double.TryParse ( this.textBoxResult.Text, out result ) )
            {
                this.Value1 = result;
            }

            this.textBoxResult.Text = "0";
        }
        #endregion
    }
}
