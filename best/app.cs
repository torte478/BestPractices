//... Program.cs

class Program
{
	static void Main()
	{
		var app = App.Init();
		app.Run();
	}
}

//... App.cs

public partial class App : IDisposable
{
	private readonly IFirst first;
	private readonly ISecond second;

	private App(IFirst first, ISecond second)
	{
		this.first = first;
		this.second = second;
	}

	public override void Dispose()
	{
		first.Dispose();
		second.Dispose();
	}
}

//... App.Init.cs

public partial class App
{
	public static App Init()
	{
		//init
		return new App(first, second);
	}
}

//... App.Run.cs

public partial class App
{
	public void Run()
	{
		//do work
	}
}