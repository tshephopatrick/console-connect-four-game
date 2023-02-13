namespace Connectfour
{
    public class Game
    {
        private int numberOfPlayers;
        private char[] expectedChars = { '#', '@', '*', '&' };
        private char[] playersChars { get; set; }
        public List<Player> players = new List<Player>();
        public Gameboard gameboard;

        public Game(Gameboard newboard)
        {
            this.gameboard = newboard;
        }

        public void initialiseGame()
        {
            this.numberOfPlayers = Util.getNumericInput("Enter number of Players:", Settings.MIN_NUMBER_OF_PLAYERS, Settings.MAX_NUMBER_OF_PLAYERS);
            playersChars = new char[numberOfPlayers];
            for (int i = 0; i < this.numberOfPlayers; i++)
            {
                this.printPrompt(i);
                Player player = createNewPlayer();
                this.playersChars[i] = player.getIcon();
                this.removeChosenIcon(player);
                this.addPlayer(player);
            }
        }

        public void play()
        {
            do
            {
                for (int i = 0; i < this.numberOfPlayers; i++)
                {
                    Player player = this.players[i];
                    int columnChosen = getColumn();

                    this.gameboard.addToBoard(columnChosen, player.getIcon());
                    Console.Clear();
                    this.gameboard.printBoard();
                    this.getWinner();
                }
            } while (true);
        }


        public int getColumn()
        {
            do
            {
                int column = Util.getNumericInput("Enter col number", 0, Settings.NUMBER_OF_COLS);
                if (this.gameboard.isEmptyCol(column))
                {
                    return column;
                }
            } while (true);
        }

        public void getWinner()
        {
            char matchFound = this.gameboard.getMatch(this.playersChars);
            if (matchFound != '\0')
            {
                Player? player = this.getPlayerFromIcon(matchFound);
                if (player != null)
                {
                    Console.WriteLine("Winner is {0} ", player._name);
                }
            }
        }

        private Player createNewPlayer()
        {
            Player player = new Player();
            player.initiasePlayer(this.expectedChars);
            return player;
        }

        private void removeChosenIcon(Player player)
        {
            this.expectedChars = this.expectedChars.Where(x => x != player.getIcon()).ToArray();
        }

        private void addPlayer(Player player)
        {
            this.players.Add(player);
        }

        private void printPrompt(int i)
        {
            Console.WriteLine("Enter details for player {0}", i + 1);
        }

        private Player? getPlayerFromIcon(char icon)
        {
            foreach (Player player in this.players)
            {
                if (player.getIcon() == icon)
                {
                    return player;
                }
            }
            return null;
        }
    }
}