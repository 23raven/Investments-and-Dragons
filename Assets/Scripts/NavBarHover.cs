using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NavBarHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image image;
    [SerializeField] private string hoverColor = "#FFD966";

    private Color normalColor;
    private Color highlightColor;

    private void Awake()
    {
        normalColor = image.color;

        if (!ColorUtility.TryParseHtmlString(hoverColor, out highlightColor))
        {
            Debug.LogWarning("Invalid hover color: " + hoverColor);
            highlightColor = Color.white;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = highlightColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = normalColor;
    }
}