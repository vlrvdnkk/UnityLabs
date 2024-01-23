using UnityEngine;

public class HotdogDebugComponent : MonoBehaviour
{
    void Start()
    {
        HotdogSettings classicHotdogSettings = Resources.Load<HotdogSettings>("SO/ClassicHotdogSO");
        Hotdog classicHotdog = new ClassicHotDog(classicHotdogSettings);

        HotdogSettings pickleHotdogSettings = Resources.Load<HotdogSettings>("SO/PickleHotdogSO");
        Hotdog pickleHotdog = new PickleHotdog(new ClassicHotDog(classicHotdogSettings), pickleHotdogSettings);

        HotdogSettings onionHotdogSettings = Resources.Load<HotdogSettings>("SO/OnionHotdogSO");
        Hotdog onionHotdog = new OnionHotdog(new ClassicHotDog(classicHotdogSettings), onionHotdogSettings);

        DebugHotdogInfo(classicHotdog);
        Debug.Log("��������������� ����������:");
        DebugHotdogInfo(pickleHotdog);
        DebugHotdogInfo(onionHotdog);
    }

    void DebugHotdogInfo(Hotdog hotdog)
    {
        string hotdogInfo;

        if (hotdog is HotdogDecorator)
        {
            HotdogDecorator decorator = hotdog as HotdogDecorator;
            hotdogInfo = $"{decorator.GetClassName()} {hotdog.Name} ({decorator.GetWeight()}�) � {decorator.GetCost()}�.";
        }
        else
            hotdogInfo = $"{hotdog.Name} ({hotdog.GetWeight()}�) � {hotdog.GetCost()}�.";

        Debug.Log(hotdogInfo);
    }
}