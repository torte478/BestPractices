class Bar
{
	private int current	

	public void Foo()
	{
		//Before
		current = Foo1();

		//After
		var (exists, current) = Foo1(); //current isn't field!
	}
}
