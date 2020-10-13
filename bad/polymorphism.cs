class A
{
    protected Property { get; }

    public A(Item item)
    {
        if (item is FirstImpl || item is SecondImpl || item is ThirdImpl ||
            (item.Prop is PropImpl) || (item is FourthImpl) || item is FifthImpl)
            return;

        Property = ...
    }
}

class B : A
{
    public B(Item item) : base(item)
    {
        if (Property == null) return;

        Property = ...
    }
}