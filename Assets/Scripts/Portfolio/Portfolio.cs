using System.Collections.Generic;
using UnityEngine;

public class Portfolio : MonoBehaviour
{
    [SerializeField] private int balance;
    [SerializeField] private List<PortfolioItem> stocks = new();
    public List<PortfolioItem> Stocks => stocks;
    public int ItemCount => stocks.Count;
    public int Balance => balance;
    public List<PortfolioItem> Items => stocks;
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

    public PortfolioItem GetItem(int index)
    {
        return stocks[index];
    }

    public PortfolioItem GetItem(Stock stock)
    {
        return stocks.Find(item => item.Stock == stock);
    }

    public void SellStock(Stock stock, int quantity, int price)
    {
        PortfolioItem item = GetItem(stock);

        if (item == null)
            return;

        if (quantity > item.Quantity)
            return;

        balance += quantity * price;
        item.Quantity -= quantity;

        if (item.Quantity == 0)
        {
            stocks.Remove(item);
        }
    }


}   