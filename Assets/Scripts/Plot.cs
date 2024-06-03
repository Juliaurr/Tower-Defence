using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    private GameObject tower;
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
            return;
        }

        Tower towerToBuild = BuildManager.main.GetSelectedTower();

        if (towerToBuild.cost > LevelManager.main.currency)
        {
            return;
        }

        LevelManager.main.SpendCurrency(towerToBuild.cost);

        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
    }
}
