string maze = """
##########
#        #
#  ## ## #
#  ## ## #
#        #
#  ## ## #
#  ## ## #
#        #
#  ## ## #
##########
""";

string biggerMaze = """
#################################################
#               #       #       #       #       #
# ##### # ##### # ##### # ##### # ##### # ##### #
#       #       #       #       #               #
# ##### # ##### # ##### # ##### # ##### # ##### #
#       #       #       #       #       #       #
# ##### # ##### # ##### # ##### # ##### # ##### #
#               #       #       #       #       #
# ##### # ##### # ##### # ##### # ##### # ##### #
#       #       #               #       #       #
# ##### # ##### # ##### # ##### # ##### # ##### #
#       #               #       #       #       #
# ##### # ##### # ##### # ##### # ##### # ##### #
#       #       #       #       #       #       #
# ##### # ##### # ##### # ##### # ##### # ##### #
#       #       #       #               #       #
# ##### # ##### # ##### # ##### # ##### # ##### #
#       #       #       #       #               #
#################################################
""";

Console.WriteLine("Select maze width (odd number): ");
int width = int.Parse(Console.ReadLine());
Console.WriteLine("Select maze height (odd number): ");
int height = int.Parse(Console.ReadLine());
Console.WriteLine("Select maze seed (0 for random): ");
int seed = int.Parse(Console.ReadLine());

MazeGenerator mazeGenerator = new(width, height, seed);
mazeGenerator.Generate(0, 0);
string mazeString = mazeGenerator.ToString();

Player[] players =
{
	new ('A', ConsoleColor.Red, new()),
	new ('B', ConsoleColor.Blue, new(ConsoleKey.W, ConsoleKey.S, ConsoleKey.A, ConsoleKey.D))
};

GameLogic game = new(players, ConsoleColor.Green, mazeString);
game.GameLoop();
