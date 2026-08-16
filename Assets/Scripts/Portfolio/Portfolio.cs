using System.Collections.Generic;
using UnityEngine;

public class Portfolio : MonoBehaviour
{
    [SerializeField] private int balance = 1000;
    [SerializeField] private List<PortfolioItem> stocks = new();

    public int Balance => balance;

}