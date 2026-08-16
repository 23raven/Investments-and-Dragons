using System.Collections.Generic;
using UnityEngine;

public class Portfolio : MonoBehaviour
{
    [SerializeField] private int balance;
    [SerializeField] private List<PortfolioItem> stocks = new();

    public int Balance => balance;

    public void BuyStock(Stock stock, int quantity, int price)
    {
        balance -= quantity * price;

        PortfolioItem existingItem = stocks.Find(item => item.Stock == stock);

        if (existingItem != null)
        {
            int oldTotal = existingItem.Quantity * existingItem.AveragePurchasePrice;
            int newTotal = quantity * price;

            existingItem.Quantity += quantity;
            existingItem.AveragePurchasePrice =
                (oldTotal + newTotal) / existingItem.Quantity;
        }
        else
        {
            stocks.Add(new PortfolioItem(stock, quantity, price));
        }
    }
}   