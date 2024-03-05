using System;
using System.Collections.Generic;
using UnityEngine;

namespace NuclearSystem.Data
{
    [CreateAssetMenu(menuName = "SO/New Resource Time Data", fileName = "ResourceTimeDataSO")]
    public class ResourceTimeDataSO : ScriptableObject
    {
        [field: SerializeField] public List<ResourceTimeData> ResourceTimeDatas{ get; private set; }
    }
    
    [Serializable]
    public class ResourceTimeData
    {
        [field: SerializeField] public NuclearResourceType ResourceType { get; private set; }
        [field: SerializeField] public float ResourceEnrichmentTime { get; private set; }
        [field: SerializeField] public float ResourceDissolutionTime { get; private set; }
    }
}
