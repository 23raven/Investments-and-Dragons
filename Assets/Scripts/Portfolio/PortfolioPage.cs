using UnityEngine;

public class PortfolioPage : MonoBehaviour
{
    [SerializeField] private Portfolio portfolio;
    [SerializeField] private PortfolioElement elementPrefab;
    [SerializeField] private Transform content;

    private void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
    {
        Clear();

        foreach (PortfolioItem item in portfolio.Items)
        {
            PortfolioElement element = Instantiate(elementPrefab, content);
            element.Initialize(item);
        }
    }

    private void Clear()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }
}