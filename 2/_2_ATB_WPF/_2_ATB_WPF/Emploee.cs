using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ATB_WPF
{
    public class Emploee
    {
        public string FirstName {  get; set;  }

        public string LastName   { get; set; }

        public string ImgFileName { get; set; }

        public Positions Position { get; set; }

        public int Salary { get; set; }
        
        public string Phone { get; set; }



        public Emploee ( )
        {
            this.FirstName = "unknown";
            this.LastName = "unknown";
            this.ImgFileName = "indefinite.img";
            this.Position = Positions.INDEFINITE;
            this.Salary = 0;
            this.Phone = "unknown";
        }


        public Emploee ( string FirstName, string LastName, string PathToImg, Positions Position, int Salary, string Phone )
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.ImgFileName = PathToImg;
            this.Position = Position;
            this.Salary = Salary;
            this.Phone = Phone;
        }
    }



    public enum Positions
    {
        CASHIER,
        GUARD,
        PORTER,
        KEEPER,
        LOGISTIC,
        ACCOUNTER,
        INDEFINITE
    }
}
