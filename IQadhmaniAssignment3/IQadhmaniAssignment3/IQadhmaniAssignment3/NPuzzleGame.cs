/*
 * Programmed by: Ibrahim Qadhmani
 * Revision history:
 *      October 26, 2017: Project created
 *      October 26, 2017: Designed form
 *      October 27, 2017: Debugging started
 *      October 28, 2017: Debugging completed
 *      October 29, 2017: Project completed
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IQadhmaniAssignment3
{
    /// <summary>
    /// The main class of the N-Puzzle Game
    /// </summary>
    public partial class NPuzzleGame : Form
    {
        const int LEFT = 20;
        const int WIDTH = 50;
        const int HEIGHT = 50;
        const int TOP = 20;
        const int ROW_LINE = 0;         //The first line index in a file where the writer/reader will hit to save/load the number of rows
        const int COLUMN_LINE = 1;      //The first line index in a file where the writer/reader will hit to save/load the number of columns
        const int MINIMUM_NUMBER = 1;   //The minimun number used to determine the range of the random function
        Button last = new Button();     //The invisible tile that must be, logically, the final tile in order to win the game
        int[] correctSequence;          //An array of the correct pattern of the current puzzle
        int[] playerSequence;           //An array of the current sequence of the current puzzle
        int numberOfRows;
        int numberOfColumns;
        int rowOfLast;                  //The row of the last number of puzzle size starting from the LAST BOTTOM ROW
        string errorMessage = "";
        Icon gameIcon = Properties.Resources.IQ_icon;
        Bitmap smileyFace = Properties.Resources.smileyFace;

        /// <summary>
        /// The constructor of the NPuzzleGame class
        /// </summary>
        public NPuzzleGame()
        {
            InitializeComponent();
        }

        /// <summary>
        /// A button that is responsible to generate the puzzle depending on the input in the 2 text files in the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnGenerate_Click(object sender, EventArgs e)
        {
            bool keepGoing = false;
            bool error = false;
            errorMessage = "";
            try
            {
                numberOfRows = int.Parse(txtRow.Text);
                numberOfColumns = int.Parse(txtColumn.Text);
            }
            catch (Exception ex)
            {

                errorMessage += "Error: Incorrect input. Original error: " + ex.Message + "\r\n";
                error = true;
            }            
            if ((numberOfRows == 1 && numberOfColumns == 1))
            {
                errorMessage += "Error: 1x1 puzzle can't be done." + "\r\n";
                error = true;
            }

            if (numberOfColumns <= 0 || numberOfRows <= 0)
            {
                errorMessage += "Error: Non-positive inputs are not accepted.";
                error = true;
            }
            if (error)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            int puzzleSize = numberOfRows * numberOfColumns;
            int puzzleSizeIndex = puzzleSize + 1;
            Button tile;
            Random randomNumber = new Random();
            List<int> listOfTile = new List<int>();
            correctSequence = new int[puzzleSizeIndex];
            playerSequence = new int[puzzleSizeIndex];
            for (int i = 1; i <= puzzleSize; i++)
            {
                correctSequence[i] = i;
            }
            pnlGamePanel.Height = numberOfRows * (TOP + HEIGHT);
            pnlGamePanel.Width = numberOfColumns * (LEFT + WIDTH);
            do
            {
                keepGoing = true;
                pnlGamePanel.Controls.Clear();
                int k = 1;
                int x = LEFT;
                int y = TOP;
                int tileIndex = 1;
                int numberOfInversions = 0;
                listOfTile = new List<int>();
                for (int i = 1; i <= numberOfRows; i++)
                {
                    x = LEFT;
                    for (int j = 1; j <= numberOfColumns; j++)
                    {
                        tile = new Button();
                        tile.Left = x;
                        tile.Top = y;
                        tile.Width = WIDTH;
                        tile.Height = HEIGHT;
                        do
                        {
                            tileIndex = randomNumber.Next(MINIMUM_NUMBER, puzzleSizeIndex);     //The random generator
                        } while (listOfTile.Contains<int>(tileIndex));                          //Check if the number generated is already in the list
                        listOfTile.Add(tileIndex);                                              //Add the unique number to the list
                        tile.Text = tileIndex.ToString();
                        tile.Click += DynamicButton_Click;      //Adding event handler
                        x += WIDTH;
                        playerSequence[k] = tileIndex;
                        k++;

                        if (tileIndex == puzzleSize)
                        {
                            last = tile;
                            rowOfLast = numberOfRows - i + 1;       //"1" is essential to determine which row number starting from the bottom
                            tile.Visible = false;
                        }
                        pnlGamePanel.Controls.Add(tile);
                    }
                    y += HEIGHT;
                }
                //Checking for solvability starts******************
                for (int i = 1; i < puzzleSize; i++)
                {
                    for (int j = i + 1; j <= puzzleSize; j++)
                    {
                        if (playerSequence[i] == puzzleSize)
                        {
                            continue;
                        }
                        if (playerSequence[i] > playerSequence[j])
                        {
                            numberOfInversions++;
                        }
                    }
                }
                if (((numberOfColumns % 2 == 1) && (numberOfInversions % 2 == 0)) || ( (numberOfColumns % 2 == 0) && ((rowOfLast % 2 == 1) == (numberOfInversions % 2 == 0)) ))
                {
                    keepGoing = false;
                    int numberOfSimilarities = 0;
                    //The following piece of code is to check if the generated puzzle is already
                    //to skip it and find the next possible solvable puzzle
                    //Check if AlreadySolved starts
                    for (int i = 1; i <= puzzleSize; i++)
                    {
                        if (playerSequence[i] == correctSequence[i])
                        {
                            numberOfSimilarities++;
                        }
                    }
                    if (numberOfSimilarities == puzzleSize)
                    {
                        keepGoing = true;
                    }
                    //Check if AlreadySolved ends
                }
                //Checking for solvability ends********************
            } while (keepGoing);  
        }

        /// <summary>
        /// A dynamic click event handler that is shared between all generated or loaded tiles
        /// </summary>
        /// <param name="sender">The Button object which is a tile invoking click</param>
        /// <param name="e"></param>
        private void DynamicButton_Click(object sender, EventArgs e)
        {
            Button tile = (Button)sender;
            if ((last.Bottom == tile.Top && last.Location.X == tile.Location.X) ||
                (last.Left == tile.Right && last.Location.Y == tile.Location.Y) ||
                (last.Top == tile.Bottom && last.Location.X == tile.Location.X) ||
                (last.Right == tile.Left && last.Location.Y == tile.Location.Y))
            {
                Point tempLocation = last.Location;
                last.Location = tile.Location;
                tile.Left = tempLocation.X;
                tile.Top = tempLocation.Y;

                int tempLastValue = int.Parse(last.Text);
                int tempTileValue = int.Parse(tile.Text);
                int tempLastIndex = Array.IndexOf(playerSequence, tempLastValue);
                int tempTileIndex = Array.IndexOf(playerSequence, tempTileValue);

                int placeHolder = playerSequence[tempLastIndex];
                playerSequence[tempLastIndex] = tempTileValue;
                playerSequence[tempTileIndex] = placeHolder;
            }
            
            bool solved = CheckSolved();
            if (solved)
            {
                MessageBox.Show("YOU DID IT!");
                pnlGamePanel.Controls.Clear();
            }

        }

        /// <summary>
        /// A menu strip clickable tool that handles saving game files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsSave_Click(object sender, EventArgs e)
        {
            StreamWriter writer = null;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = "c:\\";
            saveFile.Filter = "txt files (*.txt)|*.txt";
            saveFile.RestoreDirectory = true;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {                
                if (saveFile.FileName != null)
                {
                    if (pnlGamePanel.Controls.Count != 0)
                    {
                        writer = new StreamWriter(saveFile.FileName);
                        int firstPuzzleElement = 2;
                        int[] saveFileInfromation = new int[pnlGamePanel.Controls.Count + firstPuzzleElement];
                        saveFileInfromation[ROW_LINE] = numberOfRows;
                        saveFileInfromation[COLUMN_LINE] = numberOfColumns;
                        int puzzleSize = numberOfRows * numberOfColumns;
                        int playerSequenceIndex = 1;
                        for (int i = firstPuzzleElement; i < puzzleSize + firstPuzzleElement; i++)
                        {
                            saveFileInfromation[i] = playerSequence[playerSequenceIndex];
                            playerSequenceIndex++;
                        }
                        foreach (var item in saveFileInfromation)
                        {
                            writer.WriteLine(item);
                        }
                    }
                    writer.Close();
                }
            }            
        }

        /// <summary>
        /// A menu strip clickable tool that loads a saved game file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsLoad_Click(object sender, EventArgs e)
        {
            StreamReader reader = null;
            OpenFileDialog loadFile = new OpenFileDialog();
            string line = "";
            loadFile.InitialDirectory = "c:\\";
            loadFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            loadFile.RestoreDirectory = true;            
            if (loadFile.ShowDialog() == DialogResult.OK)
            {
                reader = new StreamReader(loadFile.FileName);
                int firstPuzzleElement = 2;
                pnlGamePanel.Controls.Clear();
                int[] loadFileInformation = new int[File.ReadAllLines(loadFile.FileName).Count()];
                int k = 0;

                try
                {
                    for (int i = 0; i < loadFileInformation.Length; i++)
                    {
                        line = reader.ReadLine();
                        loadFileInformation[k] = int.Parse(line);
                        k++;
                    }
                    numberOfRows = loadFileInformation[ROW_LINE];
                    numberOfColumns = loadFileInformation[COLUMN_LINE];
                    int puzzleSize = numberOfRows * numberOfColumns;
                    int puzzleSizeIndex = numberOfColumns * numberOfRows + 1;
                    playerSequence = new int[puzzleSizeIndex];
                    correctSequence = new int[puzzleSizeIndex];
                    int x = LEFT;
                    int y = TOP;
                    int l = 1;

                    for (int i = 1; i <= puzzleSize; i++)
                    {
                        correctSequence[i] = i;
                    }
                    pnlGamePanel.Height = numberOfRows * (TOP + HEIGHT);
                    pnlGamePanel.Width = numberOfColumns * (LEFT + WIDTH);
                    for (int i = 0; i < numberOfRows; i++)
                    {
                        x = LEFT;
                        for (int j = 0; j < numberOfColumns; j++)
                        {
                            Button tile = new Button();
                            tile.Left = x;
                            tile.Top = y;
                            tile.Width = WIDTH;
                            tile.Height = HEIGHT;
                            tile.Text = loadFileInformation[firstPuzzleElement].ToString();
                            tile.Click += DynamicButton_Click;
                            x += WIDTH;
                            playerSequence[l] = loadFileInformation[firstPuzzleElement];
                            if (loadFileInformation[firstPuzzleElement] == puzzleSize)
                            {
                                last = tile;
                                tile.Visible = false;
                            }
                            pnlGamePanel.Controls.Add(tile);
                            l++;
                            firstPuzzleElement++;
                        }
                        y += HEIGHT;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Incorrect save file. Original error: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// A menu strip clickable tool to exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsExit_Click(object sender, EventArgs e)
        {
            ExitMessageBox exitMessageBox = new ExitMessageBox();
            exitMessageBox.ShowDialog();
            Application.Exit();
        }

        /// <summary>
        /// A boolean function which is responsible to check if the player won or not
        /// </summary>
        /// <returns>A boolean value of whether the game is solved or not</returns>
        bool CheckSolved()
        {
            bool solved = true;
            for (int i = 1; i <= pnlGamePanel.Controls.Count; i++)
            {
                if (playerSequence[i] != correctSequence[i])
                {
                    solved = false;
                    break;
                }
            }
            return solved;
        }
    }
}
