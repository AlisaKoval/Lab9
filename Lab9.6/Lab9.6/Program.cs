using System;

namespace Lab9._6
{
    class Program
    {
        static Game NextGame(Game firstGame, Game lastGame)
        {
            string newLeftTeam;
            string newRightTeam;
            Random rnd = new Random();
            if (firstGame.leftTeamScore >= firstGame.rightTeamScore)
                newLeftTeam = firstGame.leftTeam;
            else
                newLeftTeam = firstGame.rightTeam;
            if (lastGame.leftTeamScore >= lastGame.rightTeamScore)
                newRightTeam = lastGame.leftTeam;
            else
                newRightTeam = lastGame.rightTeam;
            Game newGame;
            newGame.leftTeam = newLeftTeam;
            newGame.rightTeam = newRightTeam;
            newGame.leftTeamScore = rnd.Next(10);
            newGame.rightTeamScore = rnd.Next(10);
            while(newGame.leftTeamScore == newGame.rightTeamScore)
            {
                newGame.leftTeamScore = rnd.Next(10);
                newGame.rightTeamScore = rnd.Next(10);
            }
            return newGame;
        }
        static void Main(string[] args)
        {
            BinaryTree tournament = new BinaryTree();
            string[] teams = { "BRA", "ARG", "FRA", "COL", "CHI", "URU", "GER", "ALG", "CRC", "MEX", "NED", "GRE", "BEL", "SWI", "USA", "NIG" };
            Game[] games = new Game[8];
            Game emptyGame;
            emptyGame.leftTeam = "";
            emptyGame.rightTeam = "";
            emptyGame.leftTeamScore = 0;
            emptyGame.rightTeamScore = 0;
            BinaryTreeNode[] nodes = new BinaryTreeNode[15];
            nodes[0] = tournament.AddRoot(emptyGame);
            nodes[1] = tournament.AddLeft(nodes[0], emptyGame);
            nodes[2] = tournament.AddRight(nodes[0], emptyGame);
            for (int i = 1, j = 3; i < 7; i++)
            {
                nodes[j] = tournament.AddLeft(nodes[i], emptyGame);
                j++;
                nodes[j] = tournament.AddRight(nodes[i], emptyGame);
                j++;
            }
            Random rnd = new Random();
            for(int i = 0, j = 0; i < games.Length; i++,j+=2)
            {
                Game game;
                game.leftTeam = teams[j];
                game.rightTeam = teams[j + 1];
                game.leftTeamScore = rnd.Next(10);
                game.rightTeamScore = rnd.Next(10);
                while(game.leftTeamScore == game.rightTeamScore)
                {
                    game.leftTeamScore = rnd.Next(10);
                    game.rightTeamScore = rnd.Next(10);
                }
                games[i] = game;
            }
            for (int i = nodes.Length - 1, j = games.Length - 1; j >= 0; i--, j--)
                nodes[i].data = games[j];
            for (int i = 6; i >= 0; i--)
                nodes[i].data = NextGame(nodes[i].left.data, nodes[i].right.data);
            tournament.InOrderTraversal();
            Console.ReadKey();
        }
    }
}
