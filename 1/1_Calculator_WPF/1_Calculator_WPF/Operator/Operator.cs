using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1_Calculator_WPF
{
    /// <summary>
    /// This delegate determines the signature of this calculator methods.
    /// </summary>
    /// <param name="value1">first user value</param>
    /// <param name="value2">second user value</param>
    /// <returns></returns>
    public delegate double CalculateDelegate ( double value1, double value2 );



    /// <summary>
    /// This class describes methods of the calculator.
    /// </summary>
    public class Operator : IOperator
    {
        /// <summary>
        /// It is an addition.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public double Add ( double value1, double value2 )
        {
            return value1 + value2;
        }



        /// <summary>
        /// It is a subtraction.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public double Subtraction ( double value1, double value2 )
        {
            return value1 - value2;
        }



        /// <summary>
        /// It is a multiplication.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public double Multiplication ( double value1, double value2 )
        {
            return value1 * value2;
        }



        /// <summary>
        /// It is a division.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public double Division ( double value1, double value2 )
        {
            if ( value2 == 0 )
            {
                MessageBox.Show ( "Division to zero!!!" );
                return 99999999999999;
            }
            return value1 / value2;
        }



        /// <summary>
        /// It is a division 1/x.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public double Division1ToX ( double value1, double value2 )
        {
            if ( value1 == 0 )
            {
                MessageBox.Show ( "Division to zero!!!" );
                return 99999999999999;
            }

            return 1 / value1;
        }



        /// <summary>
        /// It is a squer root.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public double Sqrt ( double value1, double value2 )
        {
            if ( value1 < 0 )
            {
                MessageBox.Show ( "Sqrt from negative number!!!" );
                return 0;
            }
            return Math.Sqrt ( value1 );
        }
    }
}
