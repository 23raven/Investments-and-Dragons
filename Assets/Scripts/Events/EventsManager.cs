using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    [SerializeField] private List<Event> events;

    private Event currentEvent;

    public Event CurrentEvent => currentEvent;

    public void PrepareEvent()
    {
        if (events.Count == 0)
            return;

        int randomIndex = Random.Range(0, events.Count);

        currentEvent = events[randomIndex];

        Debug.Log(currentEvent.EventName);
    }

    public bool ResolveEvent()
    {
        if (currentEvent == null)
            return false;

        float roll = Random.Range(0f, 100f);

        return roll <= currentEvent.Chance;
    }

    public void ApplyEventEffects()
    {
        foreach (EventEffect effect in CurrentEvent.Effects)
        {
            Stock stock = effect.Stock;

            int oldPrice = stock.CurrentPrice;

            float modifier = effect.PriceModifier / 100f;
            int newPrice = Mathf.Max( 1, Mathf.RoundToInt(oldPrice * (1f + modifier)));

            stock.UpdatePrice(newPrice);

            Debug.Log(
                stock.StockName + ": " +
                oldPrice + " → " +
                newPrice
            );
        }
    }


}