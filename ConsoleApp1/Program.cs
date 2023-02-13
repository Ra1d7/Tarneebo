namespace Tarneebo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int team0bag = 0;
            int team1bag = 0;
            int winningbag = 31;
            int gamecount = 0;
            while(team0bag <=winningbag && team1bag <=winningbag)
            {
                gamecount++;
                Console.WriteLine($"---START--- (Game {gamecount}) ---START---");
                Game g = new Game();
                team0bag += g.team0score;
                team1bag += g.team1score;
                Console.WriteLine($"---END--- (Game {gamecount}) ----END----");
            }
            Console.WriteLine("-----------------------------++++++++++++++++++++++++-----------------------------");
            Console.WriteLine($"Team0 bag is {team0bag}");
            Console.WriteLine($"Team1 bag is {team1bag}");
            Console.WriteLine($"Total games: {gamecount}");
            Console.WriteLine("-----------------------------++++++++++++++++++++++++-----------------------------");
            Console.Read();

        }
    }
}