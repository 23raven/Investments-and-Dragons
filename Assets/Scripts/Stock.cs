using System.Collections.Generic;
using UnityEngine;

public class Stock : MonoBehaviour
{
    int id;
    int currentPrice;

    public List<int> priceHistory = new();
}
