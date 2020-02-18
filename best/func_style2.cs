public void Run()
{
    var result = config
                 ._(_ => storage.Read(_.Name, _.From, _.To))
                 ._<Changes>(filter).Parse()
                 .Take(config.MaxOutputLength)
                 ._<OutputFile>(config.OutputFile, Log)
                 .Write()
                 .If(_ => _.Success)
                 	Then(_ => _._(Save))
                 ._(_ => "Complete!");
    Log.Write(result);
}