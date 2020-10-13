class Bar
{
	private int current;

	//Before	
	public void Foo()
	{
		current = Foo1();
	}

	//After
	public void Foo()
	{
		var (exists, current) = Foo1(); //current isn't field!
	}
}
