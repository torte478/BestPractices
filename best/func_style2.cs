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

//===============================

public void Run2()
{
    var records = storage.Read(config.Name, config.From, config.To);
    var changes = new Changes(records, filter)
                  .Parse()
                  .Take(config.MaxOutputLength);
                  
    var output = new OutputFile(changes, config.OutputFile, Log);
    var result = output.Write();

    if (result.Success)
        Save(result);

    Log.Write("Complete!");
}