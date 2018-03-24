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
        static int turns = 0;
        static List<Cow> millList = new List<Cow> { };
        public MainWindow()
        {
            InitializeComponent();

            

        }

       

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please enter player1 and player2 names in the provided boxs. Press finished once done.");
            Player1Box.IsEnabled = true;
            player2box.IsEnabled = true;
         

        }

        private void finish_Click(object sender, RoutedEventArgs e)
        {
            Player player1 = new Player(Player1Box.Text, 1);
            Player player2 = new Player(player2box.Text, 2);
            MessageBox.Show(string.Format("Welcome to the war {0} and {1}", Player1Box.Text, player2box.Text));
        }
    }
}
