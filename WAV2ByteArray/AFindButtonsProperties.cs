using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace WAV2ByteArray
{
    /// <summary>
    /// A Grouping of properties for a FindAddress button.
    /// Must be passed reference of the UserInputGrid because im lazy and dont want to learn dynamic elements yet ;)
    /// </summary>
    class AFindButtonsProperties
    {
        public const int ROW = 0;
        public const int COLUMN = 1;
        public const double WIDTH = 30;
        public const double HEIGHT = 20;
        public const double MARGIN_INCREMENT = 20;
        public const string CONTENT = "...";
        public const string NAME = "FindAddressButton";

        public readonly VerticalAlignment verticalAlignment = VerticalAlignment.Top;
        public readonly HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;

        protected Grid gridReference;
        private Button buttonReference;

        public AFindButtonsProperties (Grid inputGrid)
        {

        }

        /// <summary>
        /// Must contain a valid named view element. 
        /// If its not, method will throw ViewElementNotFoundException.
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="lastRank"></param>
        /// <returns></returns>
        public Button GetReferenceLastRankedItem (out int lastRank)
        {
            Button outputButton = null;
            int lastRankConstruction = 0;

            List <T> elementQuery = (from element in gridReference.Children.OfType <T>() select element).ToList();

            foreach (var item in elementQuery)

            if (currentButton != null) //skips elements that arent buttons
            {
                string[] choppedUp = currentButton.Name.ToString().Split ('_');
                    
                if (choppedUp.Length > 1 && //prevents exception for names not following the FindButton convention.
                    choppedUp[0] == Name)
                {
                    int numberIsolated = Convert.ToInt16 (choppedUp[1]);

                    if (numberIsolated > lastRankConstruction)
                    {
                        outputButton = currentButton;
                        lastRank = numberIsolated;
                    }
                }
            }

            if (outputButton == null)
            {
                throw new ViewElementNotFoundException ("Cant find any buttons in the grid reference which follow the naming convention.");
            }

            else
            {
                lastRank = lastRankConstruction;
                return outputButton;
            }
        }

        /// <summary>
        /// returns a new Thickness so feel free to change it however you like.
        /// </summary>
        /// <returns></returns>
        public Thickness GetCopyLastButtonsMargin()
        {
            int notNeeded;
            Button lastButton = GetReferenceLastRankedButton (out notNeeded);
            return new Thickness (lastButton.Margin.Left,
                                  lastButton.Margin.Top,
                                  lastButton.Margin.Right,
                                  lastButton.Margin.Bottom
                                 );
        }

        public string GetLatestRankedName()
        {
            int lastRank;
            Button lastButton = GetReferenceLastRankedButton (out lastRank);
            lastRank++;
            string name = Name + "_" + lastRank.ToString();
            return name;
        }
    }
}
