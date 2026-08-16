using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StockPage : MonoBehaviour
{
    [SerializeField] private Image stockImage;
    [SerializeField] private TMP_Text stockName;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text currentPrice;

    private Stock stock;
    public Stock Stock => stock;
    public void Initialize(Stock stock)
    {
        this.stock = stock;

        stockImage.sprite = stock.StockIcon;
        stockName.text = stock.StockName;
        description.text = stock.StockDescription;
        currentPrice.text = "Price:" + stock.CurrentPrice.ToString();
    }
}