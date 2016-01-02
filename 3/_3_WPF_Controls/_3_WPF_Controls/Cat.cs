using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_WPF_Controls
{
    public class Cat
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public CatBreeds Breed { get; set; }
    }



    public enum CatBreeds { British, Pers, Sfinks, Unknown }
}
