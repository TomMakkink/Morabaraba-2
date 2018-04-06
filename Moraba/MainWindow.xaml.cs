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
        Player player1 = new Player("Player 1", 1);
        Player player2 = new Player("Player 2", 2);
        List<Node> mainNode = new List<Node> { };
        List<List<string>> millList = new List<List<string>> { };
        bool isStartNode = true; // this is used within the move method.
        Cow tempCow = new Cow(); //  this is also used within in the move method to keep the cow that is being moved.
        bool isShooting = false;

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
            string rules = @"The aim of Morabaraba is to get your opponent down to only 2 cows. 
    There are three main phases to the game: 
        1) Placing the cows.
        2) Moving the cows.
        3) Flying the cows.
    
PLACING THE COWS:
    Each player starts off with 12 cows that they can place anywhere on the board.
    Each turn one cows is placed, until all 12 cows have been placed on the board, then
    the game moves on to the next phase: moving the cows.
    Three cows in a row on the board(diagonal, horizontal or vertical) represents a mill.
    When a mill is formed, mob syndrome immediately kicks in and the player who formed the mill
    can 'shoot' or remove one of the cows from the other players team.Even if two mills are
    formed, only one cow may be shot each round. 
    Cows in a mill can not be shot. 
    A cow once outside of a mill must wait a turn, before it is placed back into that same mill. 
    
MOVING THE COWS
    Once all the cows have been placed on the board, cows can be moved to any empty adjacent intersection.
    
FLYING THE COWS
    When a player only has three cows left, the cows gain super powers, and can 'fly' or be placed anywhere
    on the board.
    Only the player will three cows will be allowed to fly.
    A win occurs if one opponent has no possible moves.
    A win occurs if a player has just two cows.
    If either player has only three cows and neither player shoots a cow within ten moves, the game is drawn.

                                                                                Source: Wikipedia Morabaraba
                                                                    https://en.wikipedia.org/wiki/Morabaraba";
            MessageBox.Show(rules);
        }

        private void initNodeList()
        {
            // node (position, neighbours)

            mainNode.Add(new Node("a0", new List<string> { "a3", "d0", "b1" }));
            mainNode.Add(new Node("a3", new List<string> {"a0", "b3", "a6"}));
            mainNode.Add(new Node("a6", new List<string> { "a3", "d6", "b5"}));
            mainNode.Add(new Node("b1", new List<string> { "a0", "c2", "d1", "b3"}));
            mainNode.Add(new Node("b3", new List<string> { "a3", "c3", "b1", "b5"}));
            mainNode.Add(new Node("b5", new List<string> { "a6", "c4", "b3", "d5"}));
            mainNode.Add(new Node("c2", new List<string> { "b1", "c3", "d2"}));
            mainNode.Add(new Node("c3", new List<string> { "c2", "c4", "b3"}));
            mainNode.Add(new Node("c4", new List<string> { "c3", "b5", "d4"}));
            mainNode.Add(new Node("d0", new List<string> { "d1", "a0", "g0"}));
            mainNode.Add(new Node("d1", new List<string> { "d0", "b1", "d2", "f1"}));
            mainNode.Add(new Node("d2", new List<string> { "d1", "c2", "e2"}));
            mainNode.Add(new Node("d4", new List<string> { "d5", "c4", "e4"}));
            mainNode.Add(new Node("d5", new List<string> { "d4", "d6", "b5", "f5"}));
            mainNode.Add(new Node("d6", new List<string> { "d5", "a6", "g6"}));
            mainNode.Add(new Node("e2", new List<string> { "f1", "e3", "d2"}));
            mainNode.Add(new Node("e3", new List<string> { "e2", "e4", "f3"}));
            mainNode.Add(new Node("e4", new List<string> { "e3", "f5", "d4"}));
            mainNode.Add(new Node("f1", new List<string> { "d1", "f3", "e2", "g0"}));
            mainNode.Add(new Node("f3", new List<string> { "f1", "e3", "g3", "f5"}));
            mainNode.Add(new Node("f5", new List<string> { "g6", "d5", "e4"}));
            mainNode.Add(new Node("g0", new List<string> { "g3", "f1", "d0"}));
            mainNode.Add(new Node("g3", new List<string> { "g0", "g6", "f3"}));
            mainNode.Add(new Node("g6", new List<string> { "g3", "f5", "d6"}));

        }


        /// <summary>
        /// This method can only return the possible mills that can be made from the avalibale node.
        /// </summary>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        private List<List<string>> getMillOptions(int index)
        {
            string caseSwitch = mainNode[index].position;
            switch (caseSwitch)
            {
                case "a0":
                    return new List<List<string>> { new List<string> { "a0", "a3", "a6"},new List<string> { "a0", "d0", "g0"}, new List<string> {"a0","b1","c2"}};
                case "a3":
                    return new List<List<string>> { new List<string> { "a0", "a3", "a6" }, new List<string> { "a3", "b3", "c3" }};
                case "a6":
                    return new List<List<string>> { new List<string> { "a0", "a3", "a6"}, new List<string> { "a6", "g6", "d6" }, new List<string> { "a6","b5","c4"}};
                case "b1":
                    return new List<List<string>> { new List<string> { "b1", "b3", "b5"}, new List<string> { "a0", "b1", "c2" }, new List<string> {"b1","d1","f1"} };
                case "b3":
                    return new List<List<string>> { new List<string> {"b1","b3","b5"}, new List<string> {"a3","b3","c3"}};
                case "b5":
                    return new List<List<string>> { new List<string> {"b1","b3","b5"}, new List<string> {"b5","a6","c4"}, new List<string> {"b5","f5","d5"} };
                case "c2":
                    return new List<List<string>> { new List<string> {"c2","c3","c4"}, new List<string> {"c2","d2","e2"}, new List<string> {"a0","b1","c2"} };
                case "c3":
                    return new List<List<string>> { new List<string> {"c2","c3","c4"}, new List<string> {"a3","b3","c3"} };
                case "c4":
                    return new List<List<string>> { new List<string> {"c2","c3","c4"}, new List<string> {"c4","d4","e4"}, new List<string> {"c4","b5","a6"} };
                case "d0":
                    return new List<List<string>> { new List<string> {"d0","d1","d2"}, new List<string> {"a0","d0","g0"} };
                case "d1":
                    return new List<List<string>> { new List<string> {"d0","d1","d2"}, new List<string> {"b1","d1","f1"} };
                case "d2":
                    return new List<List<string>> { new List<string> {"d0","d1","d2"}, new List<string> {"d2","e2","c2"} };
                case "d4":
                   return new List<List<string>> { new List<string> {"d4","d5","d6"}, new List<string> {"d4","c4","e4"} };
                case "d5":
                    return new List<List<string>> { new List<string> {"d4","d5","d6"}, new List<string> {"d5","b5","f5"} };
                case "d6":
                    return new List<List<string>> { new List<string> {"d4","d5","d6"}, new List<string> {"a6","d6","g6"} };
                case "e2":
                    return new List<List<string>> { new List<string> {"e2","e3","e4"}, new List<string> {"e2","f1","g0"}, new List<string> {"e2","d2","c2"} };
                case "e3":
                    return new List<List<string>> { new List<string> {"e2","e3","e4"}, new List<string> {"e3","f3","g3"} };
                case "e4":
                    return new List<List<string>> { new List<string> {"e2","e3","e4"}, new List<string> {"e4","f5","g6"}, new List<string> {"e4","d4","c4"} };
                case "f1":
                    return new List<List<string>> { new List<string> {"f1","f3","f5"}, new List<string> {"f1","e2","g0"}, new List<string> {"f1","d1","b1"} };
                case "f3":
                    return new List<List<string>> { new List<string> {"f1","f3","f5"}, new List<string> {"g3","e3","f3"} };
                case "f5":
                    return new List<List<string>> { new List<string> {"f1","f3","f5"}, new List<string> {"f5","e4","g6"}, new List<string> {"f5","d5","b5"} };
                case "g0":
                    return new List<List<string>> { new List<string> {"g0","g3","g6"}, new List<string> {"g0","f1","e2"}, new List<string> {"g0","a0","d0"} };
                case "g3":
                    return new List<List<string>> { new List<string> {"g0","g3","g6"}, new List<string> {"g3","f3","e3"}};
                case "g6":
                    return new List<List<string>> { new List<string> {"g0","g3","g6"}, new List<string> {"g6","d6","a6"}, new List<string> {"g6","f5","e4"} };
                

            }
            return new List<List<string>> { };
        }


        /// <summary>
        /// This method checks to see if the given mill can be fromed or not.
        /// </summary>
        /// <param name="millOptions"></param>
        /// <returns></returns>
        private bool checkMillCanForm(List<string> millOptions, Player player)
        {
            Node temp1 = mainNode.Find(node => node.position == millOptions[0]);
            Node temp2 = mainNode.Find(node => node.position == millOptions[1]);
            Node temp3 = mainNode.Find(node => node.position == millOptions[2]);
            if (temp1.occupied && temp2.occupied && temp3.occupied)
            {
                if (temp1.cow.Team == temp2.cow.Team && temp2.cow.Team == player.Team && temp2.cow.Team == temp3.cow.Team)
                {
                    return true;
                }
                else
                    return false;

            }
            return false;
        }

        /// <summary>
        /// This method will return the number of mills formed if any.
        /// </summary>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        private bool checkMills(int index, Player player)
        {
            List<List<string>> millOptions = getMillOptions(index); // this will return all the mills that can be made from this node.
            int numMills = 0; // number of actual mills formed this is the value that is returned.
            for (int i = 0; i < millOptions.Count; i++) // this just goes through all the options given and either adds to the numMills and millList or does nothing.
            {
                bool answer = checkMillCanForm(millOptions[i],player); // this will check whether this mill can be formed or not.
                if (answer)
                {
                    numMills++; // adds a +1 to the number of mills that are formed from this one node.
                    millList.Add(millOptions[i]); // just adds the new mill to the millList.
                }
            }
            if (numMills > 0) return true;
            else return false;
        }

        /// <summary>
        /// This will shoot the cow by emptying the mainNode list of the cow as well as changeing the node colour aswell
        /// </summary>
        /// <param name="index"></param>
        /// <param name="player"></param>
        /// <param name="but"></param>
        private void shootCow(int index,Player player,Button but )
        {
            if (mainNode[index].occupied == true && mainNode[index].cow.Team != player.Team && isShooting ==true)
            {
                mainNode[index].occupied = false;
                mainNode[index].cow = new Cow();
                but.Background = Brushes.WhiteSmoke;
                isShooting = false;
            }
            else
                MessageBox.Show("Please may you choose a node that is not your own and that is not empty.");
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
            else but.Background = Brushes.DarkCyan;
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

        private void moveCow2NewPos (Player player,int index, Button but)
        {
            mainNode[index].cow = tempCow;
            mainNode[index].cow.Position = mainNode[index].position;
            mainNode[index].occupied = true;
            turns++;
            isStartNode = true;
            changeButtonColour(player, but);
        }

        private void startingCow (Player player, int index, Button but)
        {
            if (mainNode[index].occupied && (mainNode[index].cow.Team == player.Team))
            {
                tempCow = mainNode[index].cow;
                mainNode[index].occupied = false;
                mainNode[index].cow = new Cow();
                isStartNode = false;
                but.Background = Brushes.WhiteSmoke;
            }
            else
            {
                MessageBox.Show("Please choose a valid node i.e.  an occupied node that is not your enemies.");
            }
        }

        private void finishingCow (Player player, int index, Button but)
        {
            if (mainNode[index].position != tempCow.Position && (mainNode[index].occupied == false))
            {
                if (checkIsFlying(player))
                {
                    if (player.Team == 1) player1State.Content = "State: Flying";
                    else player2State.Content = "State: Flying";
                    moveCow2NewPos(player, index, but);
                }
                else
                {
                    if (player.Team == 1) player1State.Content = "State: Moving";
                    else player2State.Content = "State: Moving";
                    if (mainNode[index].neighbours.Contains(tempCow.Position))
                    {
                        moveCow2NewPos(player, index, but);
                    }
                    else
                    {
                        MessageBox.Show("Please choose an unoccupied node");
                    }
                }
            }
        }

        private void moveCow(Player player, int index, Button but)
        {
            if (isStartNode==true)
            {
                startingCow(player, index, but);
            }
            else
            {
                finishingCow(player, index, but);
            }
        }


        private void movePlayer(int index, Button but)
        {
            if (isShooting) turns--;
            if (turns % 2 == 0)
            {
                player2Arrow.Visibility = Visibility.Hidden;
                player1Arrow.Visibility = Visibility.Visible;
                if (isShooting)
                {
                    
                    shootCow(index, player2, but);
                    turns++;
                }
                else
                {
                    if (turns < 25)
                    {
                        placeCow(player2, index, but);
                        player2State.Content = "State: Placing";
                    }
                    else
                    {
                        moveCow(player2, index, but);
                    }
                    if (checkMills(index, player2) && isStartNode==true)
                    {
                        MessageBox.Show("A mill was formed. Choose an enemy cow to shoot.");
                        player2State.Content = "Player 2: Shooting";
                        isShooting = true;
                    }
                }
            }
            else
            {
                if (isShooting)
                {
                    shootCow(index, player1, but);
                    turns++;
                }
                else
                {
                    player1Arrow.Visibility = Visibility.Hidden;
                    player2Arrow.Visibility = Visibility.Visible;
                    if (turns < 25)
                    {
                        placeCow(player1, index, but);
                        player1State.Content = "State: Placing";
                    }
                    else
                    {
                        moveCow(player1, index, but);
                    }
                    if (checkMills(index, player1) && isStartNode == true)
                    {
                        MessageBox.Show("A mill was formed. Choose an enemy cow to shoot.");
                        player1State.Content = "Player 1: Shooting";
                        isShooting = true;
                    }
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
