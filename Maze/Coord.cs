struct Coord
{
	private int _x;
	private int _y;

    public Coord()
    {
        _x = 0;
		_y = 0;
    }

    public Coord(int x, int y)
	{
		_x = x;
		_y = y;
	}

	public void MoveUp()
	{
		_y--;
	}

	public void MoveDown()
	{
		_y++;
	}

	public void MoveLeft()
	{
		_x--;
	}

	public void MoveRight()
	{
		_x++;
	}

	public int GetX()
	{
		return _x;
	}

	public int GetY()
	{
		return _y;
	}
}
