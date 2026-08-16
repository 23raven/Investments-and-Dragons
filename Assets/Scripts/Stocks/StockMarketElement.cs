using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StockMarketElement : MonoBehaviour
{
    [SerializeField] private Stock stock;
    [SerializeField] private Image stockIcon;
    [SerializeField] private TMP_Text stockName;
    [SerializeField] private TMP_Text currentPrice;

    private void Start()
    {
        Initialize(stock);
    }

    private void Initialize(Stock stock)
    {
        stockIcon.sprite = stock.StockIcon;
        stockName.text = stock.StockName;
        currentPrice.text = stock.CurrentPrice.ToString();
    }

}