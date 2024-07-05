using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenu : MonoBehaviour
{
    public static ContextMenu Instance;
    public GameObject menuPanel;
    private Plot currentPlot;
    private RectTransform menuRectTransform;

    private void Awake()
    {
        Instance = this;
        menuPanel.SetActive(false);
        menuRectTransform = menuPanel.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (menuPanel.activeSelf && !IsMouseOverUI())
        {
            HideMenu();
        }
    }

    public void ShowMenu(Plot plot, Vector3 position)
    {
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
        BuildManager.main.SellTower(currentPlot);
        HideMenu();
    }

    public void OnSwitchButton()
    {
        BuildManager.main.SwitchTower(currentPlot);
        HideMenu();
    }

    private bool IsMouseOverUI()
    {
        Vector2 localMousePosition = menuRectTransform.InverseTransformPoint(Input.mousePosition);
        return menuRectTransform.rect.Contains(localMousePosition);
    }
}
