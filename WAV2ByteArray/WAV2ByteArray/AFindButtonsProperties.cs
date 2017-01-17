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
        public const double MARGIN_INCREMENT = 22;
        public const string CONTENT = "...";
        public const string NAME = "FindAddressButton";

        public readonly VerticalAlignment verticalAlignment = VerticalAlignment.Top;
        public readonly HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;
        public readonly ICommand ButtonsAction;

        private Grid gridReference;

        private Button buttonReference;
        public Button ReferenceButton
        {
            get { return buttonReference; }
        }


        /// <summary>
        /// Grid must contain a button which follows the naming convention "string_int".
        /// If not, class with throw ViewElementNotFoundException.
        /// </summary>
        /// <param name="inputGrid"></param>
        /// <param name=""></param>
        public AFindButtonsProperties (Grid inputGrid)
        {
            gridReference = inputGrid;
            buttonReference = GetReferenceLastRankedButton();
            ButtonsAction = buttonReference.Command;
        }

        private Button GetReferenceLastRankedButton()
        {
            Button outputButton = null;
            int lastRank = 0;

            foreach (Button currentButton in gridReference.Children)
            {
                string[] choppedUp = currentButton.Name.ToString().Split ('_');

                if (choppedUp.Length > 1 && //prevents exception for names not following the FindButton convention.
                    choppedUp[0].Contains (NAME))
                {
                    int numberIsolated = Convert.ToInt16 (choppedUp[1]);

                    if (numberIsolated > lastRank)
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
                return outputButton;
            }
        }

        /// <summary>
        /// returns a new Thickness so feel free to change it however you like.
        /// </summary>
        /// <returns></returns>
        public Thickness GetCopyLastButtonsMargin()
        {
                buttonReference = GetReferenceLastRankedButton();
                return new Thickness (buttonReference.Margin.Left,
                                      buttonReference.Margin.Top,
                                      buttonReference.Margin.Right,
                                      buttonReference.Margin.Bottom
                                     );
        }
    }
}
