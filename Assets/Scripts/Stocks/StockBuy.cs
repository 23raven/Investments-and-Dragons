using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class StockBuy : MonoBehaviour
{

    [Header("UI Elements")]
    [SerializeField] private StockPage stockPage;
    [SerializeField] private TMP_Text stockName;
    [SerializeField] private Image stockImage;
    [SerializeField] private TMP_Text balance;
    [SerializeField] private TMP_Text currentPrice;
    [SerializeField] private TMP_InputField amount;
    [SerializeField] private TMP_Text total;
    [SerializeField] private Button buyActiveButton;
    [SerializeField] private Button buyInactiveButton;

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
    }

    public void UpdateTotal(string value)
    {
        if (!int.TryParse(value, out int amountINT) || amountINT <= 0)
        {
            total.text = "Total: 0";
            buyActiveButton.gameObject.SetActive(false);
            buyInactiveButton.gameObject.SetActive(true);
            return;
        }

        int currentPriceINT = stockPage.Stock.CurrentPrice;

        int totalPrice = amountINT * currentPriceINT;
        setTotalPrice(totalPrice);
        checkIfCanBuy(totalPrice, portfolio.Balance);

        total.text = "Total: " + totalPrice;
    }

    private void setTotalPrice(int total)
    {
        totalPrice = total;
    }

    private void checkIfCanBuy(int totalPrice, int balance)
    {
        if(totalPrice <= balance)
        {
            buyActiveButton.gameObject.SetActive(true);
            buyInactiveButton.gameObject.SetActive(false);
        }
        else
        {
            buyActiveButton.gameObject.SetActive(false);
            buyInactiveButton.gameObject.SetActive(true);
        }
    }

    public void BuyStock()
    {
        Stock stock = stockPage.Stock;

        int quantity = int.Parse(amount.text);

        if (totalPrice > portfolio.Balance)
            return;

        portfolio.BuyStock(
            stock,
            quantity,
            stock.CurrentPrice
        );

        UpdateBalance();
        checkIfCanBuy(totalPrice, portfolio.Balance);
    }

    public void UpdateBalance()
    {
        balance.text = "Balance: " + portfolio.Balance.ToString();
    }
}