struct Coord
{
	public int X;
	public int Y;

    public Coord()
    {
        X = 0;
		Y = 0;
    }

    public Coord(int x, int y)
	{
		X = x;
		Y = y;
	}

	public void MoveUp()
	{
		Y--;
	}

	public void MoveDown()
	{
		Y++;
	}

	public void MoveLeft()
	{
		X--;
	}

	public void MoveRight()
	{
		X++;
	}
}
