using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Plot : MonoBehaviour
{
    private GameObject tower;
    private Tower towerOnPlot;
    public SpriteRenderer sr;
    private Color startColor;
    public Color hoverColor;

    private void Start() 
    {
        startColor = sr.color;
    }

    private void OnMouseEnter() 
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit() 
    {
        sr.color = startColor;
    }

    private void OnMouseDown() 
    {
        if (tower != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            if (BuildManager.main.towerCount >= 2)
            {
                ContextMenu.Instance.ShowMenu(this, mousePosition);
            }
            return;
        }

        Tower towerToBuild = BuildManager.main.GetSelectedTower();

        if (towerToBuild.cost > LevelManager.main.currency)
        {
            return;
        }

        LevelManager.main.SpendCurrency(towerToBuild.cost);

        AudioManager.instance.PlaySound("TowerPlaced");
        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
        towerOnPlot = towerToBuild;
        BuildManager.main.towerCount++;
    }

    public void SetTower(GameObject newTower)
    {
        if (tower != null)
        {
            Destroy(tower);
        }
        tower = newTower;
    }

    public GameObject GetTowerGameObject()
    {
        return tower;
    }

    public Tower GetTowerClass()
    {
        return towerOnPlot;
    }
}
