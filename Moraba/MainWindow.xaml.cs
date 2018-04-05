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
        
        int turns = 1;
        Player player1 = new Player();
        Player player2 = new Player();
        List<Node> mainNode = new List<Node> { };
        List<List<string>> millList = new List<List<string>> { };
        bool isStartNode = true;
        Cow tempCow = new Cow();

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

            battleGround.Visibility = System.Windows.Visibility.Visible;

            // Initialize mainNode list 
            initNodeList();

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

        private void initNodeList()
        {
            mainNode.Add(new Node());
        }

        private bool isNameTrue(string buttonName, string[] pos)
        {
            string NodeName = string.Format("{0}{1}", pos[0], pos[1]);

            if ((buttonName.ToLower()).CompareTo(NodeName.ToLower()) == 0)
            {
                return true;
            }
            return false;


        }

        /// <summary>
        /// This method can only return the possible mills that can be made from the avalibale node.
        /// </summary>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        private List<List<string>> getMillOptions(Node currentNode)
        {
            string name = currentNode.position;
            return new List<List<string>> { };
        }


        /// <summary>
        /// This method checks to see if the given mill can be fromed or not.
        /// </summary>
        /// <param name="millOptions"></param>
        /// <returns></returns>
        private bool checkTrue(List<string> millOptions)
        {
            return false;
        }

        /// <summary>
        /// This method will return the number of mills formed if any.
        /// </summary>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        private int checkMills(Node currentNode)
        {
            List<List<string>> millOptions = getMillOptions(currentNode); // this will return all the mills that can be made from this node.
            int numMills = 0; // number of actual mills formed this is the value that is returned.
            for (int i = 0; i < millOptions.Count; i++) // this just goes through all the options given and either adds to the numMills and millList or does nothing.
            {
                bool answer = checkTrue(millOptions[i]); // this will check whether this mill can be formed or not.
                if (answer)
                {
                    numMills++; // adds a +1 to the number of mills that are formed from this one node.
                    millList.Add(millOptions[i]); // just adds the new mill to the millList.
                }
            }
            return numMills;
        }




        private void placeCow(Player player, int index, Button but)
        {
            //Cow(string name, string row, string col, int team);
            if (mainNode[index].occupied == false)
            {
                mainNode[index].cow = new Cow(mainNode[index].position, player.Team);
                mainNode[index].occupied = true;
                changeButtonColour(player,but);
                turns++;
            }

        }

        private void changeButtonColour(Player player, Button but)
        {
            if (player.Team == 1) but.Background = Brushes.BurlyWood;
            else but.Background = Brushes.DarkSalmon;
        }


        private bool checkIsFlying (Player player)
        {
            int totalCowz = 0;
            foreach (Node x in mainNode)
            {
                if (x.cow.Team == player.Team)
                    totalCowz++;
            }
            if (totalCowz > 3)
                return false;
            else
                return true;
        }

        private void moveCow(Player player, int index, Button but)
        {
            if (isStartNode==true)
            {
                if (mainNode[index].occupied && (mainNode[index].cow.Team == player.Team))
                {
                    tempCow = mainNode[index].cow;
                    mainNode[index].occupied = false;
                    isStartNode = false;
                    but.Background = Brushes.WhiteSmoke;
                }
                else
                {
                    MessageBox.Show("Please choose a valid node i.e.  an occupied node that is not your enemies.");
                }
            }
            else
            {
                if (mainNode[index].position != tempCow.Position && (mainNode[index].occupied == false))
                {
                    if (checkIsFlying(player))
                    {
                        mainNode[index].cow = tempCow;
                        mainNode[index].cow.Position = mainNode[index].position;
                        mainNode[index].occupied = true;
                        turns++;
                        isStartNode = true;
                        changeButtonColour(player, but);
                    }
                    else
                    {
                        if (mainNode[index].neighbours.Contains(tempCow.Position))
                        {
                            mainNode[index].cow = tempCow;
                            mainNode[index].cow.Position = mainNode[index].position;
                            mainNode[index].occupied = true;
                            turns++;
                            isStartNode = true;
                            changeButtonColour(player, but);
                        }
                        else
                        {
                            MessageBox.Show("Please choose an unoccupied node");
                        }
                    }
                }

            }
        }



        private void movePlayer(int index, Button but)
        {
            if (turns % 2 == 0)
            {
                if (turns < 25)
                {
                    placeCow(player2, index, but);
                }
                else
                {
                    moveCow(player2, index, but);
                }
            }
            else
            {
                if (turns < 25)
                {
                    placeCow(player1, index, but);
                }
                else
                {
                    moveCow(player2, index, but);
                }
            }
        }


        private void a0_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(0, this.a0);
        }

        private void a3_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(1, this.a3);
        }

        private void a6_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(2, this.a6);
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(3, this.b1);
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(4, this.b3);
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(5, this.b5);
        }

        private void c2_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(6, this.c2);
        }

        private void c3_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(7, this.c3);
        }

        private void c4_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(8, this.c4);
        }

        private void d0_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(9, this.d0);
        }

        private void d1_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(10, this.d1);
        }

        private void d2_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(11, this.d2);
        }

        private void d4_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(12, this.d4);
        }

        private void d5_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(13, this.d5);
        }

        private void d6_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(14, this.d6);
        }

        private void e2_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(15, this.e2);
        }

        private void e3_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(16, this.e3);
        }

        private void e4_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(17, this.e4);
        }

        private void f1_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(18, this.f1);
        }

        private void f3_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(19, this.f3);
        }

        private void f5_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(20, this.f5);
        }

        private void g0_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(21, this.g0);
        }

        private void g3_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(22, this.g3);
        }

        private void g6_Click(object sender, RoutedEventArgs e)
        {
            movePlayer(23, this.g6);
        }
    }
}
