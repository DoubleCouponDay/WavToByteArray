using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WAV2ByteArray
{
    abstract class RankedNameModel <T> where T : FrameworkElement //generic input must implement the name property
    {
        protected Grid gridReference;
        private T elementReference;

        protected virtual string StringPartOfConventionalName { get; }

        public RankedNameModel (Grid inputGrid)
        {
            gridReference = inputGrid;
            int notNeeded;
            elementReference = GetReferenceLastRankedItem <T> (out notNeeded);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lastRank"></param>
        /// <returns>The object reference of type specified.</returns>
        public T1 GetReferenceLastRankedItem <T1, T2> (out int lastRank)
        {
            T outputObject = default (T);
            lastRank = -1;
            IEnumerable <object> elementQuery = from superItems in gridReference.Children
                                                from subItems in gridReference.Children.
                                           
            foreach (T element in elementQuery)
            {
                FrameworkElement castToCommon = element as FrameworkElement;

                if (castToCommon != null)
                {
                    string[] choppedUp = castToCommon.Name.ToString().Split ('_');
                    int parseResult;
                    
                    if (choppedUp.Length == 2 && //not all type T elements will have a conventional name.
                        choppedUp[0] == StringPartOfConventionalName && //different types of the same element type will have a different ranking.
                        int.TryParse (choppedUp[1], out parseResult))
                    {
                        if (parseResult > lastRank)
                        {
                            outputObject = element;
                            lastRank = parseResult;
                        }
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
                    Application.Current.Shutdown();
                }
            }
            return outputObject;
        }

        public string GetLatestRankedName()
        {
            int lastRank;
            Button lastButton = GetReferenceLastRankedItem <Button> (out lastRank);
            lastRank++;
            string name = StringPartOfConventionalName + "_" + lastRank.ToString();
            return name;
        }    
    }
}
