struct Player
{
	public ConsoleColor Color;
	public Coord Current;
	public Coord Last;
	public MovementKeys Keys;
	public char Symbol;

	public Player(char symbol, ConsoleColor color, MovementKeys keys)
	{
		Symbol = symbol;
		Color = color;
		Keys = keys;
		Current = new Coord(0, 0);
		Last = new Coord(0, 0);
	}
}
