using TMPro;
using UnityEngine;

public class PortfolioInfoPanel : MonoBehaviour
{
    [SerializeField] private PortfolioManager portfolioManager;
    [SerializeField] private TMP_Text balanceText;
    [SerializeField] private TMP_Text portfolioPriceText;
    [SerializeField] private TMP_Text bestStockText;

    public void Initialize()
    {

        balanceText.text = "Balance: " + portfolioManager.getBalance();
        portfolioPriceText.text = "Portfolio price: " + portfolioManager.GetPortfolioPrice();

        PortfolioItem bestStock = portfolioManager.GetBestStock();

        if (bestStock != null)
        {
            bestStockText.text = "Best Stock: " + bestStock.Stock.StockName + "ROI: " + bestStock.ROI.ToString();
        }
        else
        {
            bestStockText.text = "Best Stock: None";
        }
    }
}
