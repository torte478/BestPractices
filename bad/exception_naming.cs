class Bar
{
    void Foo()
    {
        try
        {
            var x = new Repeat()
                .Run(() => /*can throw exception*/);

            //...
        }
        catch (Repeat.Exception ex)
        {
            //...
        }
    }
}

class Repeat
{
    public T Run<T>(Func<T> f)
    {
        var errors = new List<Exception>();
        for (var i = 0; i < 42; ++i)
        {
            try
            {
                return f();
            }
            catch (Exception ex)
            {
                errors.Add(ex); //never happens
            }
        }

        throw new Exception(errors); //never happens
    }

    public class Exception : System.Exception
    {
        //...
    }
}
