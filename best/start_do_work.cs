classs App
{
	private readonly ITimer delayed;

	public void Run()
	{
		Start(DoWork);
	}

	private  void Start(Action work)
	{
		//...
		var task = new Task(work).Start();
		//...
	}

	private void DoWork()
	{
		//... main work
	}

	private void NextIteration()
	{
		delayed.Start(DoWork);
	}
}