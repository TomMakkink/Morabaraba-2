using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Moraba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            beginGame();
        }

        private void beginGame()
        {
            beginGameButton.Visibility = System.Windows.Visibility.Visible;
            rulesButton.Visibility = System.Windows.Visibility.Visible;
            quitGameButton.Visibility = System.Windows.Visibility.Visible;
        }

        private void beginGameButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void quitGameButton_Click(object sender, RoutedEventArgs e)
        {
            // Quite button clickek 
            Application.Current.Shutdown();
        }

        private void rulesButton_Click(object sender, RoutedEventArgs e)
        {
            // Print the rules 
        }
    }
}
