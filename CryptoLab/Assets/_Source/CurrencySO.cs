using UnityEngine;

namespace _Source
{
    [CreateAssetMenu(fileName = "NewCurrency", menuName = "CryptoExchange/Currency")]
    public class CurrencySO : ScriptableObject
    {
        [SerializeField] private string currencyName;
        [SerializeField] private Sprite icon;
        [SerializeField] private float minPrice;
        [SerializeField] private float maxPrice;
        [Range(0f, 1f)]
        [SerializeField] private float priceChangeFactor;
        [SerializeField] private float priceUpdateInterval;

        public string CurrencyName => currencyName;
        public Sprite Icon => icon;
        public float MinPrice => minPrice;
        public float MaxPrice => maxPrice;
        public float PriceChangeFactor => priceChangeFactor;
        public float PriceUpdateInterval => priceUpdateInterval;
    }
}