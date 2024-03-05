using System;
using System.Collections.Generic;
using System.Globalization;
using NuclearSystem.View;
using TMPro;

namespace NuclearSystem.Time
{
    public class ResourceTimerService
    {
        public Action OnDissolutionTimerEnd;
        
        private static ResourceTimerService instance;
        private Dictionary<ResourceButton, ResourceTimerData> _resourceTimerDatas = new Dictionary<ResourceButton, ResourceTimerData>();
        private bool _isPause = false;
        
        public static ResourceTimerService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResourceTimerService();
                }

                return instance;
            }
        }
        
        public void UpdateTimer(ResourceButton button)
        {
            if (_isPause) return;
            
            ResourceTimerData timer = _resourceTimerDatas[button];
            timer.TimeRemained -= UnityEngine.Time.deltaTime;
            
            timer.TimeText.text = timer.TimeRemained.ToString("F2",CultureInfo.InvariantCulture);
            
            if (timer.TimeRemained > 0) return;
            
            if (timer.IsDissolution)
            {
                OnDissolutionTimerEnd.Invoke();
            }
            else
            {
                timer.TimeRemained = timer.ResourceDissolutionTime;
                timer.IsDissolution = true;
                button.StartDissolution();
            }
        }
        public void StopDissolution(ResourceButton button)
        {
            ResourceTimerData timer = _resourceTimerDatas[button];
            timer.TimeRemained = timer.ResourceEnrichmentTime;
            timer.IsDissolution = false;
            button.StopDissolution();
        }
        
        public void AddTimer(ResourceButton button, float resourceEnrichmentTime, float resourceDissolutionTime, TMP_Text timeText)
        {
            _resourceTimerDatas.Add(button,new ResourceTimerData(resourceEnrichmentTime,resourceDissolutionTime,timeText));
        }

        public void PauseAllTimers()
        {
            _isPause = true;
        }
        
        public void QuitPause()
        {
            _isPause = false;
        }
    }

    public class ResourceTimerData
    {
        public float TimeRemained;
        public bool IsDissolution;
        public float ResourceEnrichmentTime { get; private set; }
        public float ResourceDissolutionTime { get; private set; }
        public TMP_Text TimeText { get; private set; }

        public ResourceTimerData(float resourceEnrichmentTime, float resourceDissolutionTime, TMP_Text timeText)
        {
            ResourceEnrichmentTime = resourceEnrichmentTime;
            TimeRemained = ResourceEnrichmentTime;
            ResourceDissolutionTime = resourceDissolutionTime;
            TimeText = timeText;
            IsDissolution = false;
        }
    }
}
