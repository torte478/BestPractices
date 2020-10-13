var fields = GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.Public);
foreach (var field in fields)
{
    var value = field.GetValue(this);
    var def = Activator.CreateInstance(value.GetType()); //It gets stuck
    if (value == def) //It's not working (boxing)
        throw new Exception($"Field {field.Name} is not defined!");
}

//=======================================
var def = Activator.CreateInstance(field.FieldType); //Better, but not works for strings
if (value.Equal(def)) //It's ok
    throw new Exception($"Field {field.Name} is not defined!");