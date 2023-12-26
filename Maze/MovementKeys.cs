struct MovementKeys
{
	public ConsoleKey Up;
	public ConsoleKey Down;
	public ConsoleKey Left;
	public ConsoleKey Right;

    public MovementKeys()
    {
        Up = ConsoleKey.UpArrow;
		Down = ConsoleKey.DownArrow;
		Left = ConsoleKey.LeftArrow;
		Right = ConsoleKey.RightArrow;
    }

	public MovementKeys(ConsoleKey up, ConsoleKey down, ConsoleKey left, ConsoleKey right)
	{
		Up = up;
		Down = down;
		Left = left;
		Right = right;
	}
}