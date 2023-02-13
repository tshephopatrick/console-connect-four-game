namespace Connectfour
{
    public class Gameboard
    {
        private static int cols;
        private static int rows;
        private static char initchar;
        public char[,] board { get; private set; }

        static Gameboard()
        {
            Gameboard.cols = Settings.NUMBER_OF_COLS;
            Gameboard.rows = Settings.NUMBER_OF_ROWS;
            Gameboard.initchar = Settings.INITIAL_CHAR;
        }

        public Gameboard()
        {
            board = new char[Gameboard.cols, Gameboard.rows];
            this.initialiseBoard();
        }

        private void initialiseBoard()
        {
            for (int i = 0; i < Gameboard.cols; i++)
            {
                for (int j = 0; j < Gameboard.rows; j++)
                {
                    board[i, j] = Gameboard.initchar;
                }
            }
        }

        public bool isEmptyCol(int columnNumber)
        {
            for (int i = 0; i < Gameboard.cols; i++)
            {
                if (board[i, columnNumber] == '0')
                {
                    return true;
                }
            }
            return false;
        }

        public void addToBoard(int columnNumber, char icon)
        {
            for (int i = Gameboard.cols - 1; i >= 0; i--)
            {
                if (board[i, columnNumber] == '0')
                {
                    board[i, columnNumber] = icon;
                    break;
                }
            }
        }

        public void printBoard()
        {
            for (int i = 0; i < Gameboard.cols; i++)
            {
                for (int j = 0; j < Gameboard.rows; j++)
                {
                    Console.Write("{0}{1}", board[i, j], " ");
                }
                Console.WriteLine("");
            }

            for (int i = 0; i < Gameboard.cols; i++)
            {
                Console.Write("{0}{1}", i, " ");
            }


            Console.WriteLine(Environment.NewLine);
        }

        public char getMatch(char[] playerChars)
        {
            foreach (char c in playerChars)
            {
                string charToSearch = new string(c, Settings.NUMBER_OF_MATCH_REQUIRED);

                string vertical = this.getBoardAsStringVertical();
                string horizontal = this.getBoardAsStringHorizontal(); 

                if (vertical.IndexOf(charToSearch) >= 0)
                {
                    return c;
                }
                else if (horizontal.IndexOf(charToSearch) >= 0)
                {
                    return c;
                }
            }

            return '\0';
        }


        private string getBoardAsStringHorizontal()
        {
            string str = string.Empty;
            for (int i = 0; i < Gameboard.cols; i++)
            {
                for (int j = 0; j < Gameboard.rows; j++)
                {
                    str += board[i, j];
                }
                str += " ";
            }

            return str;
        }

        private string getBoardAsStringVertical()
        {
            string str = string.Empty;
            for (int i = 0; i < Gameboard.cols; i++)
            {
                for (int j = 0; j  < Gameboard.rows; j++)
                {
                    str += board[j, i];
                }
                str += " ";
            }
            return str;
        }
    }
}