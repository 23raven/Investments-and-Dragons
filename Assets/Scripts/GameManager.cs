using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EventsManager eventsManager;

    private const int MaxSteps = 6;

    private int currentStep = 1;

    public int CurrentStep => currentStep;

    private void Start()
    {
        StartStep();
    }

    private void StartStep()
    {
        Debug.Log("Step " + currentStep);

        // На последнем шаге будущего события уже нет
        if (currentStep < MaxSteps)
        {
            eventsManager.PrepareEvent();

            Debug.Log(
                "Next event: " +
                eventsManager.CurrentEvent.EventName
            );
        }
    }

    public void NextStep()
    {
        ResolveCurrentEvent();

        if (currentStep >= MaxSteps)
        {
            FinishGame();
            return;
        }

        currentStep++;

        StartStep();
    }

    private void ResolveCurrentEvent()
    {
        // На первом шаге ещё нет произошедшего события
        if (currentStep == 1)
            return;

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

    private void FinishGame()
    {
        Debug.Log("Game Finished!");

        // Здесь позже откроем финальный экран
        // и покажем "Успех инвестиционной стратегии"
    }
}