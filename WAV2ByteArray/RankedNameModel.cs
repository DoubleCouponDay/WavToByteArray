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
        public readonly char NAME_RANKS_SEPARATOR = '_';
        public readonly int RANKS_SPLIT_INDEX = 1;

        public abstract string NamesStringPart { get; protected set; }
        public abstract string Content { get; protected set; }

        private int lastRankedItem;        

        protected Grid gridReference;   

        private IEnumerable <FrameworkElement> allFrameworkElements;

        public RankedNameModel (Grid inputGrid)
        {
            gridReference = inputGrid;

            allFrameworkElements = (from element1 in gridReference.Children.OfType <ListBox>()
                                    from boxItem in element1.Items.OfType <FrameworkElement>()
                                    select boxItem)
                                            
                                   .Concat (from element2 in gridReference.Children.OfType <FrameworkElement>()
                                            select element2);   
        }

        /// <summary>
        /// Attempts to find the a domain object model element which is a ranked convential name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>The object reference of type specified.</returns>
        public T GetReferenceLastRankedItem()
        {
            T outputObject = default (T);
            lastRankedItem = -1;                                          
                        
            foreach (var match in allFrameworkElements.OfType <T>()) 
            {            
                string[] choppedUp = match.Name.ToString().Split ('_');
                int parseResult;
                    
                if (choppedUp.Length == 2 && //not all type T elements will have a conventional name.
                    choppedUp[0] == NamesStringPart && //dont run this inside the constructor. StringPartOfCOnventialName is not set till derived type constructs.
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
        protected T CheckItemIsLastRanked (object inputItem)
        {
            T outputObject = default (T);            
            T castToInputType = inputItem as T;

            if (castToInputType != null)
            {
                
            }
            return outputObject;
        }

        protected string GetLatestRankedName()
        {            
            FrameworkElement lastItem = GetReferenceLastRankedItem();
            int latestRank = lastRankedItem + 1;
            string name = NamesStringPart + "_" + latestRank.ToString();
            return name;
        }   

        /// <summary>
        /// Finds all framework elements in the grid which have the same rank as your input.
        /// May be empty.
        /// </summary>
        /// <param name="rankedObjectToMatch">Uses your object's ranked name as queries basis.</param>
        /// <returns>Returned list is new no matter the outcome. Also it Will never contain your own object.</returns>
        public List <FrameworkElement> GetAllWithMatchingRanks (T rankedObjectToMatch)
        {
            List <FrameworkElement> matches = new List <FrameworkElement>();

            if (rankedObjectToMatch != null)
            {                   
                int inputsRank;
                int currentComparablesRank = default (int); //assuming rank can never be 0; the first ranked element of each type is manually named though..

                bool inputParseSucceeded = int.TryParse (rankedObjectToMatch.Name.Split (NAME_RANKS_SEPARATOR)[RANKS_SPLIT_INDEX], out inputsRank);

                IEnumerable <FrameworkElement> matchingRankedElements = from element in allFrameworkElements
                                                                        let comparablesSplitName = element.Name.Split (NAME_RANKS_SEPARATOR)
                                                                        where comparablesSplitName.Length > RANKS_SPLIT_INDEX //this limit should be fine; It's job isnt to remind the user the name is not conventional
                                                                        && inputParseSucceeded
                                                                        && int.TryParse (comparablesSplitName[RANKS_SPLIT_INDEX], out currentComparablesRank) == true
                                                                        && inputsRank == currentComparablesRank
                                                                        && (rankedObjectToMatch as FrameworkElement) != element //used != operator instead of .Equals() since i only need to know that they are referring to the same instance.
                                                                        select element;
                 
                matches = matchingRankedElements.ToList();
            }
            return matches;
        }

    }
}
