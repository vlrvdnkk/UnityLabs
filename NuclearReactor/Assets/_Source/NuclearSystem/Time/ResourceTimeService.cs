using NuclearSystem.Data;
using UnityEngine;

namespace NuclearSystem.Time
{
    public class ResourceTimeService
    {
        private static ResourceTimeService instance;
        private static ResourceTimeDataSO _resourceTimeData = Resources.Load("ResourceTimeDataSO") as ResourceTimeDataSO;
    
        public static ResourceTimeService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResourceTimeService();
                }
    
                return instance;
            }
    
        }
    
        public bool GetEnrichmentResourceTime(NuclearResourceType type,out float time)
        {
            if (_resourceTimeData)
            {
                foreach (var timeData in _resourceTimeData.ResourceTimeDatas)
                {
                    if (timeData.ResourceType == type)
                    {
                        time = timeData.ResourceEnrichmentTime;
                        return true;
                    }
                }
            }
            
            time = 0;
            return false;
        }
            
        public bool GetDissolutionResourceTime(NuclearResourceType type,out float time)
        {
            if (_resourceTimeData)
            {
                foreach (var timeData in _resourceTimeData.ResourceTimeDatas)
                {
                    if (timeData.ResourceType == type)
                    {
                        time = timeData.ResourceDissolutionTime;
                        return true;
                    }
                }
            }

            time = 0;
            return false;
        }
    }
}