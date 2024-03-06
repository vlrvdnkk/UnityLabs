using TMPro;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI hpText;
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void UpdateHpText(int hp)
        {
            hpText.text = hp.ToString();
        }
        public void ChangeColor(Color color)
        {
            spriteRenderer.color = color;
        }
    }
}
