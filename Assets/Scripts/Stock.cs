using System.Collections.Generic;
using UnityEngine;

public class Stock : MonoBehaviour
{
    public int id;
    public int currentPrice;
    public string stockName;

    public List<int> priceHistory = new();

    public void UpdatePrice(int newPrice)
    {
        currentPrice = newPrice;
        priceHistory.Add(newPrice);
    }
}
