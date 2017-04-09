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
    /// Must be passed reference of the UserInputGrid because im lazy and my dynamic binding attempt didnt work T_T
    /// </summary>
    public class StandardButtonProperties : RankedNameModel <Button>
    {
        public readonly int ROW = 0;
        public readonly int COLUMN = 1;
        public readonly double WIDTH = double.NaN; //represents the auto setting
        public readonly double HEIGHT = 20;
        public readonly double MARGIN_INCREMENT = 20;

        public readonly VerticalAlignment verticalAlignment = VerticalAlignment.Top;
        public readonly HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;

        public override string NamesStringPart { get; protected set; }
        public override string Content { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputGrid">The grid to source the first ranked button as a template.</param>
        public StandardButtonProperties (Grid inputGrid, string conventialName, string displayedContent) : base (inputGrid)
        {
            this.NamesStringPart = conventialName;
            this.Content = displayedContent;
        }

        protected Thickness GetCopyLastButtonsMargin()
        {
            Button lastButton = GetReferenceLastRankedItem();

            return new Thickness (lastButton.Margin.Left,
                                  lastButton.Margin.Top,
                                  lastButton.Margin.Right,
                                  lastButton.Margin.Bottom
                                 );
        }    

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClickFindAddress">The handler which will trigger upon the buttons supression.</param>
        public Button CreateNewFindButton (RoutedEventHandler newButtonsEvent, object buttonsContent)
        {
            Button newAddressButton = new Button();
            newAddressButton.VerticalAlignment = verticalAlignment;
            newAddressButton.HorizontalAlignment = horizontalAlignment;
            newAddressButton.Width = WIDTH;
            newAddressButton.Height = HEIGHT;
            newAddressButton.SetValue (Grid.RowProperty, ROW);
            newAddressButton.SetValue (Grid.ColumnProperty, COLUMN);

            Thickness marginConstruction = GetCopyLastButtonsMargin();
            marginConstruction.Top += MARGIN_INCREMENT;
            newAddressButton.Margin = marginConstruction;

            newAddressButton.Name = GetLatestRankedName();
            newAddressButton.Content = buttonsContent;
            newAddressButton.Click += newButtonsEvent;                   
            return newAddressButton;
        }
    }
}
