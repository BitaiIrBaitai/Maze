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

Player[] players =
{
	new ('A', ConsoleColor.Red, new()),
	new ('B', ConsoleColor.Blue, new(ConsoleKey.W, ConsoleKey.S, ConsoleKey.A, ConsoleKey.D)),
	new ('C', ConsoleColor.Yellow, new(ConsoleKey.I, ConsoleKey.K, ConsoleKey.J, ConsoleKey.L)),
	new ('D', ConsoleColor.Magenta, new(ConsoleKey.NumPad8, ConsoleKey.NumPad5, ConsoleKey.NumPad4, ConsoleKey.NumPad6)),
	new ('E', ConsoleColor.Cyan, new())
};

GameLogic game = new(players, ConsoleColor.Green, biggerMaze);
game.GameLoop();
