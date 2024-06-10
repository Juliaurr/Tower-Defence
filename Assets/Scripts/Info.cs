using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Info : MonoBehaviour
{
    public TextMeshProUGUI infoText;

    void Start()
    {
        // Initially hide the info box
        gameObject.SetActive(false);
    }

    // Function to show the info box
    public void ShowInfo(string info, Vector3 position)
    {
        infoText.text = info;
        gameObject.SetActive(true);

        // Set the position directly
        GetComponent<RectTransform>().position = position;
    }

    // Function to hide the info box
    public void HideInfo()
    {
        gameObject.SetActive(false);
    }
}