using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MahApps.Metro.Controls;

namespace WinNetMeter.UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SetSelected(Button selectedButton)
        {
            IEnumerable<Button> listButtons = StackPanelMenu.Children.OfType<Button>();
            foreach (Button button in listButtons)
            {
                if (button.Content == selectedButton.Content)
                {
                    button.BorderThickness = new Thickness(10, 1, 1, 1);
                    button.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF3731B2"));
                }
                else
                {
                    button.BorderThickness = new Thickness(1, 1, 1, 1);
                    button.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFCCCCCC"));
                }
            }
        }

        private void ButtonMenu_OnClick(object sender, RoutedEventArgs e)
        {
            SetSelected(sender as Button);
        }
    }
}