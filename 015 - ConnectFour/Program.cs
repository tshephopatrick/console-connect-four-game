using Connectfour;

class Program
{
    public static void Main(string[] args)
    {
        Gameboard gameboard = new Gameboard();

        Game game = new Game(gameboard);

        game.initialiseGame();

        game.play();
    }
}