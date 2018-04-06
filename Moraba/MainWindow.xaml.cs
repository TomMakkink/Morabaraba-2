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
        private bool checkTrue(List<string> millOptions, Player player)
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
        private int checkMills(int index, Player player)
        {
            List<List<string>> millOptions = getMillOptions(index); // this will return all the mills that can be made from this node.
            int numMills = 0; // number of actual mills formed this is the value that is returned.
            for (int i = 0; i < millOptions.Count; i++) // this just goes through all the options given and either adds to the numMills and millList or does nothing.
            {
                bool answer = checkTrue(millOptions[i],player); // this will check whether this mill can be formed or not.
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
                isStartNode = false;
                but.Background = Brushes.WhiteSmoke;
            }
            else
            {
                MessageBox.Show("Please choose a valid node i.e.  an occupied node that is not your enemies.");
            }
        }

        private void finsihingCow (Player player, int index, Button but)
        {
            if (mainNode[index].position != tempCow.Position && (mainNode[index].occupied == false))
            {
                if (checkIsFlying(player))
                {
                    moveCow2NewPos(player, index, but);
                }
                else
                {
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
                finsihingCow(player, index, but);
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
