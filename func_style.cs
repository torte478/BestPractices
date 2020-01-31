//Пример декларативного кода, который использовался в корпоративном приложении

//Расширение для поддержки функциональого стиля: применение функции к объекту и возврат результата
//используется для декларативного описания программы
public static TOut Apply<TIn, TOut>(this TIn origin, Func<TIn, TOut> f)
{
    return f(origin);
}

//Расширение для поддержки функционального стиля: выполнение действия над объектом без его изменения (например, логирование)
//Используется для того, чтобы не разрывать декларативные цепочки
public static T SideEffect<T>(this T origin, Action<T> effect)
{
    effect(origin);
    return origin;
}


private static ICommands CreateCommands()
{
    //Простой пример: взять json, получить из него имя, найти по нему данные и обернуть в json же
    var getProtocolNames = new FuncCommand(
                                json => json
                                        .Apply(name => storages.FindProtocols(name))
                                        .ReadProtocolNames()
                                        .ToJson());

    //Пример посложнее: то же самое, но по json'у найти данные суть сложнее
    var readProtocol = new FuncCommand(
                            json => json
                                     .DeserializeWithTimeTo<ProtocolRequest>("dd.MM.yyyy")
                                     .Apply(request => storages
                                        .FindProtocols(request.StorageName)
                                        .ReadProtocol(request))
                                     .Apply(ProtocolJson.Create)
                                     .ToJson());

    //Еще один пример: в нем Нужно вызвать метод, который возвращает void
    var stopMonitoring = new FuncCommand(
                        json => json
                                .DeserializeTo<uint>()
                                .MakeSideEffect(subscription => monitoring.Stop(subscription))
                                .Apply(_ => "Success".ToJson()));

    //И снова пример: декларативный стиль сохранить не получилось, но единообразие практически не нарушено
    var getOnce = new FuncCommand(
                    json => json
                            .DeserializeTo<Elements>()
                            .Apply(request => 
                            {
                                var subSystem = storages
                                                 .FindSubSystem(
                                                     request.Destination.StorageName,
                                                     request.Destination.SubSystem);
                                return request.DiagsOnly
                                       ? subSystem.Extract(request.Diags, states.Convert)
                                       : subSystem.Extract(request.Diags);
                            })
                            .ToJson());

    
    //А вот пример плохого архитектурного решения
    //Хотя комманды и добавляются легко, но, чтобы приложение их подхватывало
    //нужно вообще в другом месте заносить их в словарь
    var commands = Commands<Header>.Create(new Dictionary<Header, ICommand>
    {
        { Header.Create(2, 0), getProtocolNames },
        { Header.Create(2, 2), readProtocol },
        { Header.Create(1, 5), stopMonitoring },
        { Header.Create(1, 1), getOnce },
    },
    Void);

    //...
}