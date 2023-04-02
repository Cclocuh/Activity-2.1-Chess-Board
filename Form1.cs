using ChessBoardModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessBoardGUIApp
{
    public partial class Form1 : Form
    {
        static public Board myBoard = new Board(8);
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];
        public Form1()
        {
            InitializeComponent();
            populateGrid();
        }

        public void populateGrid() 
        {
            // this function will fill the panel1 control with buttons.
            int buttonSize = panel1.Width / myBoard.Size; // calculate the width of each button on the Grid 
            panel1.Height = panel1.Width; // set the grid to be square.

            // nested loop. Create buttons and place them  in the Panel
            for (int r = 0;  r < myBoard.Size; r++)
            {
                for (int c = 0; c < myBoard.Size; c++)
                {
                    btnGrid[r, c] = new Button();

                    // make each button square 
                    btnGrid[r, c].Width = buttonSize;
                    btnGrid[r, c].Height = buttonSize;

                    btnGrid[r, c].Click += Grid_Button_Click; // Add the same click event to each button.
                    panel1.Controls.Add(btnGrid[r, c]); // place the button on the Panel 
                    btnGrid[r, c].Location = new Point(buttonSize * r, buttonSize * c); // position it in x,y

                    // for testing purposes. Remove later. 
                    btnGrid[r, c].Text = r.ToString() + "|" + c.ToString();

                    // the Tag attribute will hold the row and column number in a string
                    btnGrid[r, c].Tag = r.ToString() + "|" + c.ToString();
                }
            }

        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {
            // get the row and column number of the button just clicked.
            string[] strArr = (sender as Button).Tag.ToString().Split('|');
            int r = int.Parse(strArr[0]);
            int c = int.Parse(strArr[1]);

            // run a helper function to label all legal moves for this piece.
            Cell currentCell = myBoard.theGrid[r, c];
            myBoard.MarkNextLegalMoves(currentCell, "Knight");
            UpdateButtonLabels();

            // reset the background color of all buttons to the default (original) color.
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].BackColor = default(Color);
                }
            }

            // set the background color of the clicked button to something different. 
            (sender as Button).BackColor = Color.Cornsilk;
        }

        public void UpdateButtonLabels()
        {
            
             
            for (int r = 0; r < myBoard.Size; r++)
            {
                for (int c = 0; c < myBoard.Size; c++)
                {
                    btnGrid[r, c].Text = "";
                    if (myBoard.theGrid[r, c].LegalNextMove) btnGrid[r, c].Text = "Legal";
                    if (myBoard.theGrid[r, c].CurrentlyOccupied) btnGrid[r, c].Text = "Rook";
                }
            }
        }
    }
}
