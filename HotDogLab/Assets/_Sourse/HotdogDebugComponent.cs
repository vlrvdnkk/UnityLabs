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
        string hotdogInfo = $"{hotdog.Name} � {hotdog.GetCost()}�.";

        if (hotdog is HotdogDecorator)
        {
            HotdogDecorator decorator = hotdog as HotdogDecorator;
            hotdogInfo += $"\n�������������� ����������:\n{decorator.Name} � {decorator.GetCost()}�.";
        }

        Debug.Log(hotdogInfo);
    }
}
