using NuclearSystem.Data;
using NuclearSystem.Time;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NuclearSystem.View
{
    [RequireComponent(typeof(Image))]
    public class ResourceButton : MonoBehaviour
    {
        [SerializeField] private NuclearResourceType resourceType;
        [SerializeField] private TMP_Text timeText;
        
        private Image _icon;
        private Button _button;
        private Sprite _activatedSprite;
        private Sprite _deactivatedSprite;
        
        private void Start()
        {
            _icon = GetComponent<Image>();
            _button = GetComponent<Button>();
            
            _button.onClick.AddListener(() => ResourceTimerService.Instance.StopDissolution(this));
            
            if (ResourceViewService.Instance.GetActivatedIcon(resourceType, out Sprite activatedIcon))
            {
                _activatedSprite = activatedIcon;
                _icon.sprite = activatedIcon;
            }
            if (ResourceViewService.Instance.GetDeactivatedIcon(resourceType, out Sprite deactivatedIcon))
            {
                _deactivatedSprite = deactivatedIcon;
            }

            float timeDissolution = 0;
            float timeEnrichment = 0;
            if (ResourceTimeService.Instance.GetDissolutionResourceTime(resourceType, out float dissolutionTime))
            {
                timeDissolution = dissolutionTime;
            }
            if (ResourceTimeService.Instance.GetEnrichmentResourceTime(resourceType, out float enrichmentTime))
            {
                timeEnrichment = enrichmentTime;
            }
            
            ResourceTimerService.Instance.AddTimer(this,timeEnrichment, timeDissolution,timeText);
            
            timeText.text = "0";
            _button.image.raycastTarget = false;
        }

        private void Update()
        {
            ResourceTimerService.Instance.UpdateTimer(this);
        }

        public void StartDissolution()
        {
            _icon.sprite = _deactivatedSprite;
            _button.image.raycastTarget = true;
        }
        
        public void StopDissolution()
        {
            _icon.sprite = _activatedSprite;
            _button.image.raycastTarget = false;
        }
    }
}
