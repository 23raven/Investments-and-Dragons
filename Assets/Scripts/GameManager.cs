using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EventsManager eventsManager;

    private int currentStep = 1;

    public int CurrentStep => currentStep;

    private void Start()
    {
        StartStep();
    }

    private void StartStep()
    {
        Debug.Log("Step " + currentStep);

        eventsManager.PrepareEvent();

        Debug.Log("Next event: " + eventsManager.CurrentEvent.EventName);
    }

    public void NextStep()
    {
        ResolveCurrentEvent();

        currentStep++;

        StartStep();
    }

    private void ResolveCurrentEvent()
    {
        bool eventHappened = eventsManager.ResolveEvent();

        if (eventHappened)
        {
            Debug.Log(
                "Event happened: " +
                eventsManager.CurrentEvent.EventName
            );

            eventsManager.ApplyEventEffects();
        }
        else
        {
            Debug.Log(
                "Event did not happen: " +
                eventsManager.CurrentEvent.EventName
            );
        }
    }
}