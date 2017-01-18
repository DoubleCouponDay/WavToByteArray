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
    class AFindButtonsProperties : RankedNameModel <Button>
    {
        public const int ROW = 0;
        public const int COLUMN = 1;
        public const double WIDTH = 30;
        public const double HEIGHT = 20;
        public const double MARGIN_INCREMENT = 20;
        public const string CONTENT = "...";

        public readonly VerticalAlignment verticalAlignment = VerticalAlignment.Top;
        public readonly HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;

        protected override string StringPartOfConventionalName { get { return "FindAddressButton"; } }

        public AFindButtonsProperties (Grid inputGrid) : base (inputGrid) { }

        public Thickness GetCopyLastButtonsMargin()
        {
            int notNeeded;
            Button lastButton = GetReferenceLastRankedItem <Button> (out notNeeded);
            return new Thickness (lastButton.Margin.Left,
                                  lastButton.Margin.Top,
                                  lastButton.Margin.Right,
                                  lastButton.Margin.Bottom
                                 );
        }    
    }
}
