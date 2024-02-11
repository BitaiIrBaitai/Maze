using System.Text;

struct MazeGenerator
{
	public int Width { get; private set; }
	public int Height { get; private set; }

	private Wall[,] _maze;
	private Random _random;

	public MazeGenerator(int width, int height)
	{
		Width = width;
		Height = height;
		_maze = new Wall[height, width];

		for (int y = 0; y < height; y++)
			for (int x = 0; x < width; x++)
				_maze[y, x] = Wall.All;

        _random = new();
	}

	public MazeGenerator(int width, int height, int seed) : this(width, height)
	{
		_random = new(seed);
	}

	public void Generate(int x, int y)
	{
		if (!IsInBounds(x, y))
			return;

		Dirrection[] dirs = GetAvailableDirrections(x, y);
		Random r = _random;
		dirs = dirs.OrderBy(dir => r.Next(0, 2)).ToArray();

		foreach (Dirrection dir in dirs)
		{
			int newX = x;
			int newY = y;

			switch (dir)
			{
				case Dirrection.Up:
					newY--;
					break;
				case Dirrection.Down:
					newY++;
					break;
				case Dirrection.Left:
					newX--;
					break;
				case Dirrection.Right:
					newX++;
					break;
			}

			if (IsInBounds(newX, newY) && _maze[newY, newX] == Wall.All)
			{
				RemoveWall(x, y, newX, newY, dir);
				Generate(newX, newY);
			}
		}
	}

	private void RemoveWall(int fromX, int fromY, int toX, int toY, Dirrection dir)
	{
		switch (dir)
		{
			case Dirrection.Up:
				_maze[fromY, fromX] &= ~Wall.Top;
				_maze[toY, toX] &= ~Wall.Bottom;
				break;
			case Dirrection.Down:
				_maze[fromY, fromX] &= ~Wall.Bottom;
				_maze[toY, toX] &= ~Wall.Top;
				break;
			case Dirrection.Left:
				_maze[fromY, fromX] &= ~Wall.Left;
				_maze[toY, toX] &= ~Wall.Right;
				break;
			case Dirrection.Right:
				_maze[fromY, fromX] &= ~Wall.Right;
				_maze[toY, toX] &= ~Wall.Left;
				break;
		}
	}

	private bool IsInBounds(int x, int y)
	{
		return x >= 0 && x < Width && y >= 0 && y < Height;
	}

	private Dirrection[] GetAvailableDirrections(int x, int y)
	{
		List<Dirrection> dirs = new();

		if (IsInBounds(x, y - 1) && _maze[y - 1, x] == Wall.All)
			dirs.Add(Dirrection.Up);

		if (IsInBounds(x, y + 1) && _maze[y + 1, x] == Wall.All)
			dirs.Add(Dirrection.Down);

		if (IsInBounds(x - 1, y) && _maze[y, x - 1] == Wall.All)
			dirs.Add(Dirrection.Left);

		if (IsInBounds(x + 1, y) && _maze[y, x + 1] == Wall.All)
			dirs.Add(Dirrection.Right);

		return dirs.ToArray();
	}

	public override string ToString()
	{
		return ToString('#');
	}

	public string ToString(char ch)
	{
		string line = new(ch, 3);
		StringBuilder sb = new();

		for (int y = 0; y < Height; y++)
		{
			for (int k = 0; k < 3; k++)
			{
				for (int x = 0; x < Width; x++)
				{
					Wall wall = _maze[y, x];

					if (k == 0)
					{
						sb.Append(wall.HasFlag(Wall.Top)? line : $"{ch} {ch}");
					}
					else if (k == 1)
					{
						if (wall.HasFlag(Wall.All))
							sb.Append(line);
						else
						{
							sb.Append(wall.HasFlag(Wall.Left) ? ch : ' ');
							sb.Append(' ');
							sb.Append(wall.HasFlag(Wall.Right) ? ch : ' ');
						}
					}
					else if (k == 2)
					{
						sb.Append(wall.HasFlag(Wall.Bottom)? line : $"{ch} {ch}");
					}
				}

				sb.AppendLine();
			}
		}

		return sb.ToString();
	}
}
