using System;
using System.Collections;
using UnityEngine;

namespace _Source
{
    public class CurrencyAggregator : MonoBehaviour
    {
        public event Action<float> OnPriceUpdated;

        private CurrencySO _currency;
        private float _currentPrice;
        private float _priceChangeFactor;

        public float CurrentPrice => _currentPrice;
        public CurrencySO Currency => _currency;

        public void Initialize(CurrencySO currencySO)
        {
            _currency = currencySO;
            _currentPrice = (_currency.MinPrice + _currency.MaxPrice) / 2f;
            _priceChangeFactor = _currency.PriceChangeFactor;
            OnPriceUpdated?.Invoke(_currentPrice);
            StartCoroutine(UpdatePriceRoutine());
        }

        private IEnumerator UpdatePriceRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_currency.PriceUpdateInterval);
                UpdatePrice();
            }
        }

        private void UpdatePrice()
        {
            _priceChangeFactor = UnityEngine.Random.Range(0f, 1f);
            float targetPrice = UnityEngine.Random.Range(_currency.MinPrice, _currency.MaxPrice);
            float priceDifference = targetPrice - _currentPrice;
            float adjustedChange = priceDifference * _priceChangeFactor;
            _currentPrice += adjustedChange;
            _currentPrice = Mathf.Clamp(_currentPrice, _currency.MinPrice, _currency.MaxPrice);
            OnPriceUpdated?.Invoke(_currentPrice);
        }
    }
}