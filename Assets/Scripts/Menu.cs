using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI currencyUI;
    
    private void OnGUI() 
    {
        currencyUI.text = LevelManager.main.currency.ToString();
    }
}
