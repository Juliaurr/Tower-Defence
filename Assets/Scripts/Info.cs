using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

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
        GetComponent<RectTransform>().position = new Vector3(position.x, position.y + 50, 0);
    }

    // Function to hide the info box
    public void HideInfo()
    {
        gameObject.SetActive(false);
    }
}