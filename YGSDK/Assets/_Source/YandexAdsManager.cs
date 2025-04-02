using UnityEngine;
using YG;

namespace _Source
{
    public class YandexAdsManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        private void Start()
        {
            YG2.StickyAdActivity(true);
        }

        public void ShowRewardedAd()
        {
            string id = "addScore";
            YG2.RewardedAdvShow(id, () =>
            {
                gameManager.ChangeBackgroundColor();
            });
        }
    }
}