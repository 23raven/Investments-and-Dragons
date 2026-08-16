using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "Investments and Dragons/Event")]
public class Event : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private string eventName;
    [SerializeField] private Sprite banner;
    [SerializeField] private Sprite icon;
    [SerializeField] private string description;
    [SerializeField] private float chance;

    [SerializeField] private List<EventEffect> effects = new();

    public int Id => id;
    public string EventName => eventName;
    public Sprite Banner => banner;
    public Sprite Icon => icon;
    public string Description => description;
    public float Chance => chance;
    public List<EventEffect> Effects => effects;
}