public void Run()
{
    var result = config
                 ._(_ => storage.Read(_.Name, _.From, _.To))
                 ._<Changes>(filter).Parse()
                 .Take(config.MaxOutputLength)
                 ._<OutputFile>(config.OutputFile, Log)
                 .Write()
                 ._(_ => "Success!");
    Log.Write(result);
}