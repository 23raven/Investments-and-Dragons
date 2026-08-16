using System;
using UnityEngine;

[Serializable]
public class EventEffect
{
    [SerializeField] private Stock stock;
    [SerializeField] private float priceModifier;

    public Stock Stock => stock;
    public float PriceModifier => priceModifier;
}