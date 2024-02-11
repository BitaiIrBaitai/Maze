struct GameLogic
{
	private Player[] _players;
	private ConsoleColor _wallColor;
	private char[,] _maze;

	public GameLogic(Player[] players, ConsoleColor wallColor, string maze)
	{
		_players = players;
		_wallColor = wallColor;
		string[] lines = maze.Split('\n');

		_maze = new char[lines.Length, lines[0].Length];
		for (int y = 0; y < lines.Length; y++)
			for (int x = 0; x < lines[y].Length; x++)
				_maze[y, x] = lines[y][x];

		for (int i = 0; i < _players.Length; i++)
			_players[i].Current = GetRandomPosition();

		Console.CursorVisible = false;
		DrawInit();
	}

	private void DrawInit()
	{
		Console.Clear();
		for (int y = 0; y < _maze.GetLength(0); y++)
		{
			for (int x = 0; x < _maze.GetLength(1); x++)
			{
				if (_maze[y, x] == '#')
					Console.ForegroundColor = _wallColor;
				else
					Console.ResetColor();

				bool playerHere = false;
				for (int i = 0; i < _players.Length; i++)
				{
					if (_players[i].Current.GetX() == x && _players[i].Current.GetY() == y)
					{
						Console.ForegroundColor = _players[i].Color;
						Console.Write(_players[i].Symbol);
						playerHere = true;
						break;
					}
				}

				if (!playerHere)
					Console.Write(_maze[y, x]);
			}
			Console.WriteLine();
		}
		Console.ResetColor();
	}

	private Coord GetRandomPosition()
	{
		Random rand = new();
		Coord pos;
		do
		{
			pos = new Coord(rand.Next(0, _maze.GetLength(1)), rand.Next(0, _maze.GetLength(0)));
		} while (_maze[pos.GetY(), pos.GetX()] != ' ');

		return pos;
	}

	public void GameLoop()
	{
		while (true)
		{
			ConsoleKeyInfo key = Console.ReadKey(true);

			if (key.Key == ConsoleKey.Escape)
				break;

			for (int i = 0; i < _players.Length; i++)
			{
				_players[i].Last = _players[i].Current;
				Coord pos = _players[i].Current;
				if (_players[i].Keys.Up == key.Key)
				{
					pos.MoveUp();
					if (IsValidPosition(pos))
					{
						_players[i].Current = pos;
						RedrawPlayer(_players[i]);
						continue;
					}
				}
				else if (_players[i].Keys.Down == key.Key)
				{
					pos.MoveDown();
					if (IsValidPosition(pos))
					{
						_players[i].Current = pos;
						RedrawPlayer(_players[i]);
						continue;
					}
				}
				else if (_players[i].Keys.Left == key.Key)
				{
					pos.MoveLeft();
					if (IsValidPosition(pos))
					{
						_players[i].Current = pos;
						RedrawPlayer(_players[i]);
						continue;
					}
				}
				else if (_players[i].Keys.Right == key.Key)
				{
					pos.MoveRight();
					if (IsValidPosition(pos))
					{
						_players[i].Current = pos;
						RedrawPlayer(_players[i]);
						continue;
					}
				}
			}
		}
	}

	private bool IsValidPosition(Coord pos)
	{
		if (pos.GetX() < 0 || pos.GetX() >= _maze.GetLength(1) || pos.GetY() < 0 || pos.GetY() >= _maze.GetLength(0))
			return false;

		return _maze[pos.GetY(), pos.GetX()] == ' ';
	}

	private void RedrawPlayer(Player player)
	{
		Console.SetCursorPosition(player.Last.GetX(), player.Last.GetY());
		Console.Write(' ');
		Console.SetCursorPosition(player.Current.GetX(), player.Current.GetY());
		Console.ForegroundColor = player.Color;
		Console.Write(player.Symbol);
		Console.ResetColor();
	}
}
