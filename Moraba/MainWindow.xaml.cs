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
        // Global Variables 
        int turns = 0;
        Player player1 = new Player();
        Player player2 = new Player();

        public MainWindow()
        {
            InitializeComponent();
            beginGame();
        }

        private void beginGame()
        {
            battleGround.Visibility = System.Windows.Visibility.Hidden;
            beginGameButton.Visibility = System.Windows.Visibility.Visible;
            rulesButton.Visibility = System.Windows.Visibility.Visible;
            quitGameButton.Visibility = System.Windows.Visibility.Visible;
        }

        private void beginGameButton_Click(object sender, RoutedEventArgs e)
        {
            // Hide game buttons 
            beginGameButton.Visibility = System.Windows.Visibility.Hidden;
            rulesButton.Visibility = System.Windows.Visibility.Hidden;
            quitGameButton.Visibility = System.Windows.Visibility.Hidden;

            // Each username from each player 
            

            //player1.Name = 

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
