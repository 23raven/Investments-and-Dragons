using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StockMarketElement : MonoBehaviour
{
    [SerializeField] private Image stockIcon;
    [SerializeField] private TMP_Text stockName;
    [SerializeField] private TMP_Text currentPrice;

    private Stock stock;
    private TabManager tabManager;

    public Stock Stock => stock;

    public void Initialize(Stock stock, TabManager tabManager)
    {
        this.stock = stock;
        this.tabManager = tabManager;

        stockIcon.sprite = stock.StockIcon;
        stockName.text = stock.StockName;

        UpdatePrice();

        stock.OnPriceChanged += UpdatePrice;
    }

    private void UpdatePrice()
    {
        currentPrice.text = stock.CurrentPrice.ToString();
    }

    public void OpenStockPage()
    {
        tabManager.OpenStockPage(stock);
    }

    private void OnDestroy()
    {
        if (stock != null)
        {
            stock.OnPriceChanged -= UpdatePrice;
        }
    }
}