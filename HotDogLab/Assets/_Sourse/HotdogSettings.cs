using UnityEngine;

[CreateAssetMenu(fileName = "HotdogSettings", menuName = "Hotdog Settings", order = 1)]
public class HotdogSettings : ScriptableObject
{
    [field: SerializeField] public string HotdogName { get; private set; }
    [field: SerializeField] public int BaseCost { get; private set; }
    [field: SerializeField] public int CucumberWeight { get; private set; }
    [field: SerializeField] public int OnionWeight { get; private set; }
}