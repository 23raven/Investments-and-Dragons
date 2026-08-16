using System.Collections.Generic;
using UnityEngine;

public class Stock : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private int currentPrice;
    [SerializeField] private string stockName;
    [SerializeField] private string stockDescription;
    [SerializeField] private Sprite stockIcon;
    [SerializeField] private Sprite stockImage;

    private List<int> priceHistory = new();

    public int Id => id;
    public int CurrentPrice => currentPrice;
    public string StockName => stockName;
    public string StockDescription => stockDescription;
    public Sprite StockIcon => stockIcon;
    public Sprite StockImage => stockImage;

    public void UpdatePrice(int newPrice)
    {
        currentPrice = newPrice;
        priceHistory.Add(newPrice);
    }
}