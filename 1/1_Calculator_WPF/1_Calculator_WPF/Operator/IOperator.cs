using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Calculator_WPF
{
    /// <summary>
    /// This Interface describes mandatory methodes of Operator class.
    /// </summary>
    public interface IOperator
    { 
        double Add ( double value1, double value2 );

        double Subtraction ( double value1, double value2 );

        double Multiplication ( double value1, double value2 );

        double Division ( double value1, double value2 );

        double Division1ToX ( double value1, double value2 );

        double Sqrt ( double value1, double value2 );
    }
}
