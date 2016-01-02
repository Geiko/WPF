using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_WPF_Controls
{
    /// <summary>
    /// It represents a base for storage cats info.
    /// </summary>
    public class CatDB
    {
        /// <summary>
        /// Cat's Storage.
        /// </summary>
        public ArrayList catDB;


        /// <summary>
        /// It is deep copy of Cat's ArrayList.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="deepCopy"></param>
        public void CopyCats ( ArrayList source, ArrayList deepCopy )
        {
            deepCopy.Clear ( );
            foreach ( object cat in source )
            {
                deepCopy.Add (
                                new Cat
                                {
                                    Breed = ( cat as Cat ).Breed,
                                    Name = ( cat as Cat ).Name,
                                    Age = ( cat as Cat ).Age
                                } );
            }
        }


        /// <summary>
        /// It is a query to Cat's DataBase.
        /// </summary>
        /// <param name="catCollection"></param>
        /// <param name="breedIndex"></param>
        /// <param name="ageFrom"></param>
        /// <param name="ageTo"></param>
        /// <param name="catName"></param>
        /// <param name="ANY"></param>
        public void SelectCats ( ArrayList catCollection, int breedIndex, double ageFrom, double ageTo, 
            string catName, string ANY )
        {
            for ( int i = catCollection.Count - 1; i >= 0; i-- )
            {
                Cat cat = ( catCollection [ i ] as Cat );

                if ( ( int ) cat.Breed != breedIndex   &&   breedIndex != -1 ||
                             cat.Age < ageFrom ||
                             cat.Age > ageTo   ||
                             !string.Equals ( cat.Name, catName, StringComparison.OrdinalIgnoreCase ) && 
                             catName != ANY )
                {
                    catCollection.RemoveAt ( i );
                }
            }
        }



    }
}
