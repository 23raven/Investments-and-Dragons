using UnityEngine;
using UnityEngine.EventSystems;

public class UIHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float hoverScale = 1.1f;
    [SerializeField] private float speed = 10f;

    private Vector3 defaultScale;
    private Vector3 targetScale;

    private void Awake()
    {
        defaultScale = transform.localScale;
        targetScale = defaultScale;
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            targetScale,
            speed * Time.deltaTime
        );
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetScale = defaultScale * hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetScale = defaultScale;
    }
}