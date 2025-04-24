using UnityEngine;

namespace _Source
{
    [System.Serializable]
    public class Wallet
    {
        [SerializeField] private float schirshiBalance;
        [SerializeField] private float krokens;
        [SerializeField] private float dobbners;
        [SerializeField] private float ukhts;

        public float SchirshiBalance => schirshiBalance;
        public float Krokens => krokens;
        public float Dobbners => dobbners;
        public float Ukhts => ukhts;

        public Wallet(float initialSchirshi)
        {
            schirshiBalance = initialSchirshi;
            krokens = 0f;
            dobbners = 0f;
            ukhts = 0f;
        }

        public bool CanBuy(float price)
        {
            return schirshiBalance >= price;
        }

        public bool CanSell(string currencyName)
        {
            return currencyName switch
            {
                "Крокенсы" => krokens >= 1f,
                "Доббнеры" => dobbners >= 1f,
                "Укхты" => ukhts >= 1f,
                _ => false
            };
        }

        public void BuyCurrency(string currencyName, float price)
        {
            if (!CanBuy(price)) return;

            schirshiBalance -= price;
            switch (currencyName)
            {
                case "Крокенсы":
                    krokens += 1f;
                    break;
                case "Доббнеры":
                    dobbners += 1f;
                    break;
                case "Укхты":
                    ukhts += 1f;
                    break;
            }
        }

        public void SellCurrency(string currencyName, float price)
        {
            if (!CanSell(currencyName)) return;

            schirshiBalance += price;
            switch (currencyName)
            {
                case "Крокенсы":
                    krokens -= 1f;
                    break;
                case "Доббнеры":
                    dobbners -= 1f;
                    break;
                case "Укхты":
                    ukhts -= 1f;
                    break;
            }
        }

        private float GetAmount(string currencyName)
        {
            return currencyName switch
            {
                "Крокенсы" => krokens,
                "Доббнеры" => dobbners,
                "Укхты" => ukhts,
                _ => 0f
            };
        }
    }
}