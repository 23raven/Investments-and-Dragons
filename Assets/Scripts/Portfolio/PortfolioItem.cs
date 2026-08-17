[System.Serializable]
public class PortfolioItem
{
    public Stock Stock;
    public int Quantity;
    public int AveragePurchasePrice;

    public PortfolioItem(Stock stock, int quantity, int price)
    {
        Stock = stock;
        Quantity = quantity;
        AveragePurchasePrice = price;
    }

    public float ROI
    {
        get
        {
            if (AveragePurchasePrice <= 0)
                return 0;

            return ((float)(Stock.CurrentPrice - AveragePurchasePrice)
                    / AveragePurchasePrice) * 100f;
        }
    }


}