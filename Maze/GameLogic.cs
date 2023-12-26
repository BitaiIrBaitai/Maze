struct GameLogic
{
	public Player[] Players;
	public ConsoleColor WallColor;
	public char[,] Maze;

	public GameLogic(Player[] players, ConsoleColor wallColor, string maze)
	{
		Players = players;
		WallColor = wallColor;
		string[] lines = maze.Split('\n');

		Maze = new char[lines.Length, lines[0].Length];
		for (int y = 0; y < lines.Length; y++)
			for (int x = 0; x < lines[y].Length; x++)
				Maze[y, x] = lines[y][x];

		for (int i = 0; i < Players.Length; i++)
			Players[i].Current = GetRandomPosition();

		DrawInit();
	}

	public void DrawInit()
	{
		Console.Clear();
		for (int y = 0; y < Maze.GetLength(0); y++)
		{
			for (int x = 0; x < Maze.GetLength(1); x++)
			{
				if (Maze[y, x] == '#')
					Console.ForegroundColor = WallColor;
				else
					Console.ResetColor();

				bool playerHere = false;
				for (int i = 0; i < Players.Length; i++)
				{
					if (Players[i].Current.X == x && Players[i].Current.Y == y)
					{
						Console.ForegroundColor = Players[i].Color;
						Console.Write(Players[i].Symbol);
						playerHere = true;
						break;
					}
				}

				if (!playerHere)
					Console.Write(Maze[y, x]);
			}
			Console.WriteLine();
		}
		Console.ResetColor();
	}

	public Coord GetRandomPosition()
	{
		Random rand = new();
		Coord pos;
		do
		{
			pos = new Coord(rand.Next(0, Maze.GetLength(1)), rand.Next(0, Maze.GetLength(0)));
		} while (Maze[pos.Y, pos.X] != ' ');

		return pos;
	}

	public void GameLoop()
	{
		while (true)
		{
			ConsoleKeyInfo key = Console.ReadKey(true);

			if (key.Key == ConsoleKey.Escape)
				break;

			for (int i = 0; i < Players.Length; i++)
			{
				Players[i].Last = Players[i].Current;
				Coord pos = Players[i].Current;
				if (Players[i].Keys.Up == key.Key)
				{
					pos.MoveUp();
					if (IsValidPosition(pos))
					{
						Players[i].Current = pos;
						RedrawPlayer(Players[i]);
						continue;
					}
				}
				else if (Players[i].Keys.Down == key.Key)
				{
					pos.MoveDown();
					if (IsValidPosition(pos))
					{
						Players[i].Current = pos;
						RedrawPlayer(Players[i]);
						continue;
					}
				}
				else if (Players[i].Keys.Left == key.Key)
				{
					pos.MoveLeft();
					if (IsValidPosition(pos))
					{
						Players[i].Current = pos;
						RedrawPlayer(Players[i]);
						continue;
					}
				}
				else if (Players[i].Keys.Right == key.Key)
				{
					pos.MoveRight();
					if (IsValidPosition(pos))
					{
						Players[i].Current = pos;
						RedrawPlayer(Players[i]);
						continue;
					}
				}
			}
		}
	}

	public bool IsValidPosition(Coord pos)
	{
		if (pos.X < 0 || pos.X >= Maze.GetLength(1) || pos.Y < 0 || pos.Y >= Maze.GetLength(0))
			return false;

		return Maze[pos.Y, pos.X] == ' ';
	}

	public void RedrawPlayer(Player player)
	{
		Console.SetCursorPosition(player.Last.X, player.Last.Y);
		Console.Write(' ');
		Console.SetCursorPosition(player.Current.X, player.Current.Y);
		Console.ForegroundColor = player.Color;
		Console.Write(player.Symbol);
		Console.ResetColor();
	}
}
