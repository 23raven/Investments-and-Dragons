using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PortfolioElement : MonoBehaviour
{
    [SerializeField] private Portfolio portfolio;

    [Header("UI")]
    [SerializeField] private Image stockIcon;
    [SerializeField] private TMP_Text stockName;
    [SerializeField] private TMP_Text currentPrice;
    [SerializeField] private TMP_Text quantity;
    [SerializeField] private TMP_Text averageBuy;
    [SerializeField] private TMP_Text totalInvested;
    [SerializeField] private TMP_Text roi;

    public void Initialize(int index)
    {
        PortfolioItem item = portfolio.GetItem(index);
        Stock stock = item.Stock;

        stockIcon.sprite = stock.StockIcon;
        stockName.text = stock.StockName;
        currentPrice.text = stock.CurrentPrice.ToString();
        quantity.text = item.Quantity.ToString();
        averageBuy.text = item.AveragePurchasePrice.ToString();

        int invested = item.Quantity * item.AveragePurchasePrice;
        int currentValue = item.Quantity * stock.CurrentPrice;

        totalInvested.text = invested.ToString();

        float roiValue = ((float)(currentValue - invested) / invested) * 100f;
        roi.text = roiValue.ToString("F1") + "%";
    }
}