using UnityEngine;

public abstract class Hotdog
{
    public HotdogSettings settings;

    public Hotdog(HotdogSettings settings)
    {
        this.settings = settings;
    }

    public string Name { get { return settings.HotdogName; } }

    public abstract int GetCost();
    public abstract int GetWeight();
}

public class ClassicHotDog : Hotdog
{
    public ClassicHotDog(HotdogSettings settings) : base(settings)
    { }

    public override int GetCost()
    {
        return settings.BaseCost;
    }

    public override int GetWeight()
    {
        return 150;
    }
}

public class CaesarHotDog : Hotdog
{
    public CaesarHotDog(HotdogSettings settings) : base(settings)
    { }

    public override int GetCost()
    {
        return settings.BaseCost;
    }

    public override int GetWeight()
    {
        return 165;
    }
}

public class MeatHotDog : Hotdog
{
    public MeatHotDog(HotdogSettings settings) : base(settings)
    { }

    public override int GetCost()
    {
        return settings.BaseCost;
    }

    public override int GetWeight()
    {
        return 188;
    }
}

public abstract class HotdogDecorator : Hotdog
{
    protected Hotdog hotdog;

    public HotdogDecorator(Hotdog hotdog, HotdogSettings settings) : base(settings)
    {
        this.hotdog = hotdog;
    }
    public string GetClassName()
    {
        return hotdog.Name;
    }
}

public class PickleHotdog : HotdogDecorator
{
    public PickleHotdog(Hotdog hotdog, HotdogSettings settings)
        : base(hotdog, settings)
    {}

    public override int GetCost()
    {
        return hotdog.GetCost() + settings.BaseCost;
    }

    public override int GetWeight()
    {
        return hotdog.GetWeight() + settings.CucumberWeight;
    }
}

public class OnionHotdog : HotdogDecorator
{
    public OnionHotdog(Hotdog hotdog, HotdogSettings settings)
        : base(hotdog, settings)
    {}

    public override int GetCost()
    {
        return hotdog.GetCost() + settings.BaseCost;
    }

    public override int GetWeight()
    {
        return hotdog.GetWeight() + settings.OnionWeight;
    }
}
