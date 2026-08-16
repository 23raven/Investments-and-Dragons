using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> tabs;

    public void OpenTab(GameObject tab)
    {
        foreach (GameObject currentTab in tabs)
        {
            currentTab.SetActive(currentTab == tab);
        }
    }

    public void CloseTab(GameObject tab)
    {
        tab.SetActive(false);
    }
}