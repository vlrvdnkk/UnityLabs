using NuclearSystem.Data;
using UnityEngine;

namespace NuclearSystem.View
{
    public class ResourceViewService
    {
        private static ResourceViewService instance;
        private static ResourceViewDataSO _resourceViewData = Resources.Load("ResourceViewDataSO") as ResourceViewDataSO;

        public static ResourceViewService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResourceViewService();
                }

                return instance;
            }

        }

        public bool GetActivatedIcon(NuclearResourceType type,out Sprite icon)
        {
            if (_resourceViewData)
            {
                foreach (var viewData in _resourceViewData.ResourceViewDatas)
                {
                    if (viewData.ResourceType == type)
                    {
                        icon = viewData.ResourceActivatedIcon;
                        return true;
                    }
                        
                }
            }

            icon = null;
            return false;
        }
        
        public bool GetDeactivatedIcon(NuclearResourceType type,out Sprite icon)
        {
            if (_resourceViewData)
            {
                foreach (var viewData in _resourceViewData.ResourceViewDatas)
                {
                    if (viewData.ResourceType == type)
                    {
                        icon = viewData.ResourceDeactivatedIcon;
                        return true;
                    }
                        
                }
            }

            icon = null;
            return false;
        }
    }
}
