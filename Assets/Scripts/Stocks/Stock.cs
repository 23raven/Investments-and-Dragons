using System.Collections.Generic;
using UnityEngine;

public class Stock : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private int currentPrice;
    [SerializeField] private string stockName;
    [SerializeField] private Sprite stockIcon;
    [SerializeField] private string stockDescription;

    public List<int> priceHistory = new();

    public int Id => id;
    public int CurrentPrice => currentPrice;
    public string StockName => stockName;
    public Sprite StockIcon => stockIcon;
    public string StockDescription => stockDescription;

    public void UpdatePrice(int newPrice)
    {
        currentPrice = newPrice;
        priceHistory.Add(newPrice);
    }
}