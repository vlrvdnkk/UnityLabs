using UnityEngine;

public class HotdogDebugComponent : MonoBehaviour
{
    void Start()
    {
        Hotdog classicHotdog = new ClassicHotDog();
        Hotdog pickleHotdog = new PickleHotdog(new ClassicHotDog());
        Hotdog onionHotdog = new OnionHotdog(new ClassicHotDog());

        DebugHotdogInfo(classicHotdog);
        DebugHotdogInfo(pickleHotdog);
        DebugHotdogInfo(onionHotdog);
    }

    void DebugHotdogInfo(Hotdog hotdog)
    {
        string hotdogInfo = $"{hotdog.Name} Ч {hotdog.GetCost()}р.";

        if (hotdog is HotdogDecorator)
        {
            HotdogDecorator decorator = hotdog as HotdogDecorator;
            hotdogInfo += $"\nƒополнительна€ информаци€:\n{decorator.Name} Ч {decorator.GetCost()}р.";
        }

        Debug.Log(hotdogInfo);
    }
}
