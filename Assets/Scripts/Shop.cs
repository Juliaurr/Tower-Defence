using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI currencyUI;
    public Animator animator;
    private bool isShopOpen = true;

    public void ToggleShop() 
    {
        isShopOpen = !isShopOpen;
        animator.SetBool("ShopOpen", isShopOpen);
    }
    
    private void OnGUI() 
    {
        currencyUI.text = LevelManager.main.currency.ToString();
    }
}
