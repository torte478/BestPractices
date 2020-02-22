private readonly Dictionary<Vector, Cell> level;

//...

void Update()
{
	//...
	var next = new Vector(x, y);
	if (!(level.ContainsKey(next)))
	{
		var cell = CreateCell();
		level.Add(next, cell);
	}
}