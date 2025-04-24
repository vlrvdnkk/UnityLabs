using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source
{
    public class CurrencyUIPanel : MonoBehaviour
    {
        private enum PanelType { Buy, Sell }

        [SerializeField] private Image currencyIcon;
        [SerializeField] private TextMeshProUGUI currencyNameText;
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private Button buyButton;
        [SerializeField] private Button sellButton;
        [SerializeField] private PanelType panelType;

        private CurrencyAggregator _aggregator;
        private GameManager _gameManager;

        public void Initialize(CurrencyAggregator currencyAggregator, GameManager manager)
        {
            if (currencyAggregator == null || manager == null || currencyAggregator.Currency == null)
                return;

            _aggregator = currencyAggregator;
            _gameManager = manager;

            CurrencySO currency = _aggregator.Currency;
            currencyNameText.text = currency.CurrencyName;
            currencyIcon.sprite = currency.Icon;

            if (panelType == PanelType.Buy)
            {
                UpdatePrice(currencyAggregator.CurrentPrice);
            }
            else
            {
                UpdateCurrencyAmount();
            }

            _aggregator.OnPriceUpdated += OnPriceUpdated;
            if (panelType == PanelType.Sell)
            {
                _gameManager.OnWalletUpdated += UpdateCurrencyAmount;
            }

            if (buyButton != null)
            {
                buyButton.onClick.RemoveAllListeners();
                buyButton.onClick.AddListener(OnBuyClicked);
            }

            if (sellButton != null)
            {
                sellButton.onClick.RemoveAllListeners();
                sellButton.onClick.AddListener(OnSellClicked);
            }
        }

        private void OnDestroy()
        {
            if (_aggregator != null)
            {
                _aggregator.OnPriceUpdated -= OnPriceUpdated;
            }
            if (_gameManager != null && panelType == PanelType.Sell)
            {
                _gameManager.OnWalletUpdated -= UpdateCurrencyAmount;
            }
            if (buyButton != null)
            {
                buyButton.onClick.RemoveListener(OnBuyClicked);
            }
            if (sellButton != null)
            {
                sellButton.onClick.RemoveListener(OnSellClicked);
            }
        }

        private void OnPriceUpdated(float price)
        {
            if (panelType == PanelType.Buy)
            {
                UpdatePrice(price);
            }
        }

        private void UpdatePrice(float price)
        {
            priceText.text = $"{price:F2} $";
        }

        private void UpdateCurrencyAmount()
        {
            if (panelType == PanelType.Sell)
            {
                float amount = _gameManager.GetCurrencyAmount(_aggregator.Currency.CurrencyName);
                priceText.text = $"{amount:F0}";
            }
        }

        private void OnBuyClicked()
        {
            _gameManager.TryBuyCurrency(_aggregator.Currency.CurrencyName, _aggregator.CurrentPrice);
        }

        private void OnSellClicked()
        {
            _gameManager.TrySellCurrency(_aggregator.Currency.CurrencyName, _aggregator.CurrentPrice);
        }
    }
}