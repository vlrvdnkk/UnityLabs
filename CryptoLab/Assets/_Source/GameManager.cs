using System;
using TMPro;
using UnityEngine;

namespace _Source
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private CurrencySO[] currencies;
        [SerializeField] private GameObject currencyBuyPanelPrefab;
        [SerializeField] private GameObject currencySellPanelPrefab;
        [SerializeField] private Transform currencyBuyPanelsContainer;
        [SerializeField] private Transform currencySellPanelsContainer;
        [SerializeField] private TextMeshProUGUI walletBalanceText;
        [SerializeField] private TextMeshProUGUI messageText;
        [SerializeField] private float initialSchirshiBalance = 1000f;

        private Wallet _wallet;
        public event Action OnWalletUpdated;

        private void Start()
        {
            _wallet = new Wallet(initialSchirshiBalance);
            UpdateWalletBalanceUI();
            InitializeCurrencies();
        }

        private void InitializeCurrencies()
        {
            if (currencies == null || currencies.Length == 0)
                return;

            for (int i = 0; i < currencies.Length; i++)
            {
                CurrencySO currency = currencies[i];
                if (currency == null)
                    continue;

                try
                {
                    GameObject aggregatorObj = new GameObject(currency.CurrencyName + "_Aggregator");
                    aggregatorObj.transform.SetParent(transform);
                    CurrencyAggregator aggregator = aggregatorObj.AddComponent<CurrencyAggregator>();
                    aggregator.Initialize(currency);

                    if (currencyBuyPanelPrefab != null && currencyBuyPanelsContainer != null)
                    {
                        GameObject buyPanel = Instantiate(currencyBuyPanelPrefab, currencyBuyPanelsContainer);
                        CurrencyUIPanel buyUIPanel = buyPanel.GetComponent<CurrencyUIPanel>();
                        if (buyUIPanel != null)
                            buyUIPanel.Initialize(aggregator, this);
                    }

                    if (currencySellPanelPrefab != null && currencySellPanelsContainer != null)
                    {
                        GameObject sellPanel = Instantiate(currencySellPanelPrefab, currencySellPanelsContainer);
                        CurrencyUIPanel sellUIPanel = sellPanel.GetComponent<CurrencyUIPanel>();
                        if (sellUIPanel != null)
                            sellUIPanel.Initialize(aggregator, this);
                    }
                }
                catch {}
            }
        }

        public float GetCurrencyAmount(string currencyName)
        {
            return currencyName switch
            {
                "Крокенсы" => _wallet.Krokens,
                "Доббнеры" => _wallet.Dobbners,
                "Укхты" => _wallet.Ukhts,
                _ => 0f
            };
        }

        public void TryBuyCurrency(string currencyName, float price)
        {
            if (_wallet.CanBuy(price))
            {
                _wallet.BuyCurrency(currencyName, price);
                UpdateWalletBalanceUI();
                OnWalletUpdated?.Invoke();
                ShowMessage($"Куплена 1 единица {currencyName}");
            }
            else
            {
                ShowMessage("Невозможно совершить покупку, недостаточно средств");
            }
        }

        public void TrySellCurrency(string currencyName, float price)
        {
            if (_wallet.CanSell(currencyName))
            {
                _wallet.SellCurrency(currencyName, price);
                UpdateWalletBalanceUI();
                OnWalletUpdated?.Invoke();
                ShowMessage($"Продана 1 единица {currencyName}");
            }
            else
            {
                ShowMessage("Невозможно совершить продажу, недостаточно средств");
            }
        }

        private void UpdateWalletBalanceUI()
        {
            walletBalanceText.text = $"Баланс: {_wallet.SchirshiBalance:F2} $";
        }

        private void ShowMessage(string message)
        {
            messageText.text = message;
        }

        private void OnValidate()
        {
            if (currencies == null || currencies.Length == 0 ||
                currencyBuyPanelPrefab == null ||
                currencyBuyPanelsContainer == null ||
                currencySellPanelPrefab == null ||
                currencySellPanelsContainer == null ||
                walletBalanceText == null ||
                messageText == null) {}
        }
    }
}