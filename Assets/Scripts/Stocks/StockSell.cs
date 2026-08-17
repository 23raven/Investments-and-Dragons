using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StockSell : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private StockPage stockPage;
    [SerializeField] private TMP_Text stockName;
    [SerializeField] private Image stockImage;
    [SerializeField] private TMP_Text balance;
    [SerializeField] private TMP_Text currentPrice;
    [SerializeField] private TMP_InputField amount;
    [SerializeField] private TMP_Text total;
    [SerializeField] private Button sellActiveButton;
    [SerializeField] private Button sellInactiveButton;

    [Header("Portfolio")]
    [SerializeField] private Portfolio portfolio;

    private int totalPrice;
    public int TotalPrice => totalPrice;

    public void Initialize()
    {
        Stock stock = stockPage.Stock;

        stockImage.sprite = stock.StockIcon;
        stockName.text = stock.StockName;
        currentPrice.text = "Price: " + stock.CurrentPrice.ToString();
        balance.text = "Balance: " + portfolio.Balance.ToString();

        ResetInfo();
    }

    public void UpdateTotal(string value)
    {
        if (!int.TryParse(value, out int amountINT) || amountINT <= 0)
        {
            total.text = "Total: 0";
            sellActiveButton.gameObject.SetActive(false);
            sellInactiveButton.gameObject.SetActive(true);
            return;
        }

        PortfolioItem item = portfolio.GetItem(stockPage.Stock);

        if (item == null || amountINT > item.Quantity)
        {
            total.text = "Total: 0";
            sellActiveButton.gameObject.SetActive(false);
            sellInactiveButton.gameObject.SetActive(true);
            return;
        }

        int currentPriceINT = stockPage.Stock.CurrentPrice;

        int totalPrice = amountINT * currentPriceINT;

        SetTotalPrice(totalPrice);
        CheckIfCanSell(amountINT);

        total.text = "Total: " + totalPrice;
    }

    private void SetTotalPrice(int total)
    {
        totalPrice = total;
    }

    private void CheckIfCanSell(int quantity)
    {
        PortfolioItem item = portfolio.GetItem(stockPage.Stock);

        if (item != null && quantity <= item.Quantity)
        {
            sellActiveButton.gameObject.SetActive(true);
            sellInactiveButton.gameObject.SetActive(false);
        }
        else
        {
            sellActiveButton.gameObject.SetActive(false);
            sellInactiveButton.gameObject.SetActive(true);
        }
    }

    public void SellStock()
    {
        Stock stock = stockPage.Stock;

        if (!int.TryParse(amount.text, out int quantity) || quantity <= 0)
            return;

        PortfolioItem item = portfolio.GetItem(stock);

        if (item == null || quantity > item.Quantity)
            return;

        portfolio.SellStock(
            stock,
            quantity,
            stock.CurrentPrice
        );

        UpdateBalance();
        CheckIfCanSell(quantity);
    }

    public void UpdateBalance()
    {
        balance.text = "Balance: " + portfolio.Balance.ToString();
    }

    public void ResetInfo()
    {
        totalPrice = 0;
        total.text = "Total: 0";
        amount.text = "";

        sellActiveButton.gameObject.SetActive(false);
        sellInactiveButton.gameObject.SetActive(true);
    }
}