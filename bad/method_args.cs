var log = new Log(config.LogToConsole, config.LogToFile);

//....

class Log
{
	public Log(bool toFile, bool toConsole)
    {
        this.toFile = toFile;
        this.toConsole = toConsole;
    }
}



//==================================

private static ILog InitLog(Config config)
{
    var logs = new List<ILog>();

    if (config.LogToConsole)
        logs.Add(new ConsoleLog(format));
    if (config.LogToFile)
        logs.Add(new FileLog("log.txt", format));

    return new MultyLog(logs);
}