using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;
    public Tower[] towers;
    private int selectedTower = 0;

    public int towerCount = 0;

    private void Awake() 
    {
        main = this;
    }

    public Tower GetSelectedTower()
    {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower)
    {
        selectedTower = _selectedTower;
    }

    public void AddTower(Plot plot)
    {
        if (plot.GetTowerGameObject() == null)
        {
            Tower towerToBuild = GetSelectedTower();

            if (towerToBuild.cost > LevelManager.main.currency)
            {
                Debug.Log("Not enough currency to build tower.");
                return;
            }

            LevelManager.main.SpendCurrency(towerToBuild.cost);
            GameObject newTower = Instantiate(towerToBuild.prefab, plot.transform.position, Quaternion.identity);
            plot.SetTower(newTower);
            Debug.Log($"Added {towerToBuild.towerName} at plot.");
        }
        else
        {
            Debug.Log("Plot is already occupied.");
        }

    }

    public void SwitchTower(Plot plot)
    {
        if (plot.GetTowerGameObject() != null)
        {
            Tower towerToBuild = GetSelectedTower();

            if (towerToBuild.cost > LevelManager.main.currency)
            {
                Debug.Log("Not enough currency to switch tower.");
                return;
            }

            LevelManager.main.SpendCurrency(towerToBuild.cost);
            GameObject newTower = Instantiate(towerToBuild.prefab, plot.transform.position, Quaternion.identity);
            plot.SetTower(newTower);
            Debug.Log($"Switched to {towerToBuild.towerName} at plot.");
        }
        else
        {
            Debug.Log("No tower at plot to switch.");
        }
    }

    public void SellTower(Plot plot)
    {
        if (plot.GetTowerGameObject() != null)
        {
            Tower tower = plot.GetTowerClass();
            int refundAmount = Mathf.RoundToInt(tower.cost * 0.5f);
            LevelManager.main.IncreaseCurrency(refundAmount);
            Destroy(plot.GetTowerGameObject());
            //plot.SetTower(null);
            Debug.Log($"Sold tower at plot for {refundAmount} currency.");
            towerCount--;
        }
        else
        {
            Debug.Log("No tower at plot to sell.");
        }

    }
}
