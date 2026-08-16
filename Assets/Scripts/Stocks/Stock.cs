using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stock", menuName = "Investments and Dragons/Stock")]
public class Stock : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private int defaultPrice;
    [SerializeField] private int currentPrice;
    [SerializeField] private string stockName;
    [SerializeField] private Sprite stockIcon;
    [SerializeField] private string stockDescription;

    [SerializeField] private List<int> priceHistory = new();

    public int Id => id;
    public int DefaultPrice => defaultPrice;
    public int CurrentPrice => currentPrice;
    public string StockName => stockName;
    public Sprite StockIcon => stockIcon;
    public string StockDescription => stockDescription;
    public List<int> PriceHistory => priceHistory;

    public event Action OnPriceChanged;

    public void UpdatePrice(int newPrice)
    {
        currentPrice = newPrice;
        priceHistory.Add(newPrice);

        OnPriceChanged?.Invoke();
    }

    public void Reset()
    {
        currentPrice = defaultPrice;
        priceHistory.Clear();
        priceHistory.Add(defaultPrice);

        OnPriceChanged?.Invoke();
    }
}