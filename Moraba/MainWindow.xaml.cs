﻿using System;
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
        List<Node> mainNode = new List<Node> { };
        List<List<string>> millList = new List<List<string>> { };

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

        private bool isNameTrue (string buttonName, string[] pos)
        {
            string NodeName = string.Format("{0}{1}", pos[0], pos[1]);

            if ((buttonName.ToLower()).CompareTo(NodeName.ToLower())==0)
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
        public List<List<string>> getMillOptions(Node currentNode)
        {
            return new List<List<string>>{ };
        }


        /// <summary>
        /// This method checks to see if the given mill can be fromed or not.
        /// </summary>
        /// <param name="millOptions"></param>
        /// <returns></returns>
        public bool checkTrue(List<string> millOptions)
        {
            return false;
        }

        /// <summary>
        /// This method will return the number of mills formed if any.
        /// </summary>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        int checkMills (Node currentNode)
        {
            List<List<string>> millOptions = getMillOptions(currentNode); // this will return all the mills that can be made from this node.
            int numMills = 0; // number of actual mills formed this is the value that is returned.
            for (int i = 0; i<millOptions.Count;i++) // this just goes through all the options given and either adds to the numMills and millList or does nothing.
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
    }
}
