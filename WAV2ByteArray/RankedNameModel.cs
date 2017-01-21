using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Collections;

namespace WAV2ByteArray
{
    public abstract class RankedNameModel <T> where T : FrameworkElement //generic input must implement the name property
    {
        private int lastRankedItem;

        protected Grid gridReference;
        private T elementReference;    

        public abstract string StringPartOfConventionalName { get; }

        public RankedNameModel (Grid inputGrid)
        {
            gridReference = inputGrid;
            elementReference = GetReferenceLastRankedItem();
        }

        /// <summary>
        /// Attempts to find the a domain object model element which is ranked using its conventionalName. 
        /// Derivations of this class must implement their own conventionalName.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>The object reference of type specified.</returns>
        public T GetReferenceLastRankedItem()
        {
            T outputObject = default (T);
            lastRankedItem = -1;       
           
            IEnumerable <T> genericQuery = (from element1 in gridReference.Children.OfType <ListBox>()
                                            from boxItem in element1.Items.OfType <T>()
                                            select boxItem)
                                            
                                            .Concat (from element2 in gridReference.Children.OfType <T>()
                                            select element2);                                           
                        
            foreach (var match in genericQuery)
            {            
                string[] choppedUp = match.Name.ToString().Split ('_');
                int parseResult;
                    
                if (choppedUp.Length == 2 && //not all type T elements will have a conventional name.
                    choppedUp[0] == StringPartOfConventionalName && //different types of the same element type will have a different ranking.
                    int.TryParse (choppedUp[1], out parseResult))
                {
                    if (parseResult > lastRankedItem)
                    {
                        outputObject = match;
                        lastRankedItem = parseResult;
                    }
                }
            }     

            if (outputObject == null)
            {
                try
                {
                    Type convertingGeneric = typeof (T);
                    string stringOfT = convertingGeneric.ToString();
                    throw new ViewElementNotFoundException ("Cant find any elements of type " + stringOfT + " in grid " + gridReference.Name + ".");
                }

                catch (Exception e)
                {
                    MessageBox.Show (e.ToString());
                    Process.GetCurrentProcess().Kill();
                }
            }                                                            
            return outputObject;
        }

        /// <summary>
        /// Tests an object to see whether it is the last ranked item of type T.
        /// </summary>
        /// <param name="inputItem"></param>
        /// <returns>
        /// Returns the input object converted to type T if successful.
        /// If test failed, returns the default value of T. null for reference types, and miscellaneous for value types.
        /// </returns>
        private T CheckItemIsLastRanked (object inputItem)
        {
            T outputObject = default (T);            
            T castToInputType = inputItem as T;

            if (castToInputType != null)
            {
                
            }
            return outputObject;
        }

        public string GetLatestRankedName()
        {            
            FrameworkElement lastItem = GetReferenceLastRankedItem();
            int latestRank = lastRankedItem + 1;
            string name = StringPartOfConventionalName + "_" + latestRank.ToString();
            return name;
        }   
    }
}
