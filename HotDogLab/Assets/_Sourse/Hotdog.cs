using UnityEngine;

abstract class Hotdog
{
    public Hotdog(string n)
    {
        Name = n;
    }

    public string Name { get; protected set; }

    public abstract int GetCost();
}

class ClassicHotDog : Hotdog
{
    public ClassicHotDog() : base("Хот-Дог Классический")
    { }

    public override int GetCost()
    {
        return 210;
    }
}

class CaesarHotDog : Hotdog
{
    public CaesarHotDog() : base("Хот-Дог Цезарь")
    { }

    public override int GetCost()
    {
        return 290;
    }
}

class MeatHotDog : Hotdog
{
    public MeatHotDog() : base("Хот-Дог Мясной")
    { }

    public override int GetCost()
    {
        return 330;
    }
}

abstract class HotdogDecorator : Hotdog
{
    protected Hotdog hotdog;

    public HotdogDecorator(string n, Hotdog hotdog) : base(n)
    {
        this.hotdog = hotdog;
    }
}

class PickleHotdog : HotdogDecorator
{
    public PickleHotdog(Hotdog hotdog)
        : base(hotdog.Name + ", с маринованными огурцами", hotdog)
    { }

    public override int GetCost()
    {
        return hotdog.GetCost() + 50;
    }
}

class OnionHotdog : HotdogDecorator
{
    public OnionHotdog(Hotdog hotdog)
        : base(hotdog.Name + ", со сладким луком", hotdog)
    { }

    public override int GetCost()
    {
        return hotdog.GetCost() + 30;
    }
}
