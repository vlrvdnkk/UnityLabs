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
    public ClassicHotDog() : base("���-��� ������������")
    { }

    public override int GetCost()
    {
        return 210;
    }
}

class CaesarHotDog : Hotdog
{
    public CaesarHotDog() : base("���-��� ������")
    { }

    public override int GetCost()
    {
        return 290;
    }
}

class MeatHotDog : Hotdog
{
    public MeatHotDog() : base("���-��� ������")
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
        : base(hotdog.Name + ", � ������������� ��������", hotdog)
    { }

    public override int GetCost()
    {
        return hotdog.GetCost() + 50;
    }
}

class OnionHotdog : HotdogDecorator
{
    public OnionHotdog(Hotdog hotdog)
        : base(hotdog.Name + ", �� ������� �����", hotdog)
    { }

    public override int GetCost()
    {
        return hotdog.GetCost() + 30;
    }
}
