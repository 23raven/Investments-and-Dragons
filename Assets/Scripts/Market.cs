using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
    [SerializeField] private List<Stock> stocks;
    [SerializeField] private StockMarketElement stockMarketElementPrefab;
    [SerializeField] private Transform content;
    [SerializeField] private TabManager tabManager;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        foreach (Stock stock in stocks)
        {
            StockMarketElement element =
                Instantiate(stockMarketElementPrefab, content);

            element.Initialize(stock, tabManager);
        }
    }

    public void ResetStocks()
    {
        foreach (Stock stock in stocks)
        {
            stock.Reset();
        }
    }
}