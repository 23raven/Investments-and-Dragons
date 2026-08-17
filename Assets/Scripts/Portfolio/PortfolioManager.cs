using UnityEngine;

public class PortfolioManager : MonoBehaviour
{
    [SerializeField] private Portfolio portfolio;
    public Portfolio Portfolio => portfolio;

    public int getBalance()
    {
        return portfolio.Balance;
    }

    public int GetPortfolioPrice()
    {
        if (portfolio == null)
            return 0;

        int portfolioPrice = 0;

        foreach (var stock in portfolio.Stocks)
        {
            portfolioPrice += stock.Stock.CurrentPrice * stock.Quantity;
        }

        return portfolioPrice;
    }

    public PortfolioItem GetBestStock()
    {
        if (portfolio == null || portfolio.Stocks.Count == 0)
            return null;

        PortfolioItem bestStock = portfolio.Stocks[0];

        foreach (PortfolioItem item in portfolio.Stocks)
        {
            if (item.ROI > bestStock.ROI)
            {
                bestStock = item;
            }
        }

        return bestStock;
    }

}
