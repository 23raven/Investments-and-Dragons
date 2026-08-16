using System.Collections.Generic;
using UnityEngine;

public class Portfolio : MonoBehaviour
{
    private int balance;
    [SerializeField] private List<PortfolioItem> stocks = new();

    public int Balance => balance;

}