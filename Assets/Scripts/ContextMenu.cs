using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextMenu : MonoBehaviour, IPointerExitHandler
{
    public static ContextMenu Instance;
    public GameObject menuPanel;
    private Plot currentPlot;

    private void Awake()
    {
        Instance = this;
        menuPanel.SetActive(false);
    }

    public void ShowMenu(Plot plot, Vector3 position)
    {
        if (menuPanel.activeSelf) return;

        currentPlot = plot;
        menuPanel.SetActive(true);
        menuPanel.transform.position = position;
    }

    public void HideMenu()
    {
        menuPanel.SetActive(false);
    }

    public void OnSellButton()
    {
        HideMenu();
        BuildManager.main.SellTower(currentPlot);
    }

    public void OnSwitchButton()
    {
        HideMenu();
        BuildManager.main.SwitchTower(currentPlot);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (menuPanel.activeSelf)
        {
            HideMenu();
        }
    }
}
