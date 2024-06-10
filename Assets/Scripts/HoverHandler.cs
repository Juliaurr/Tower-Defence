using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Info infoBox;  // Reference to the InfoBox script
    public string itemInfo;  // Information to display when hovering

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Calculate the position on top of the button
       // Vector2 position = transform.position + new Vector3(0, GetComponent<RectTransform>().rect.height, 0);
        
        // Show the info box with the item info at the calculated position
        //infoBox.ShowInfo(itemInfo, position);
        StopAllCoroutines();
        StartCoroutine(WaitTime(true));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Hide the info box
        //infoBox.HideInfo();
        StopAllCoroutines();
        StartCoroutine(WaitTime(false));
    }

    IEnumerator WaitTime(bool show)
    {
       
        yield return new WaitForSeconds(0.5f);
        Vector2 position = transform.position + new Vector3(0, GetComponent<RectTransform>().rect.height, 0);
        if (show)
        {
            infoBox.ShowInfo(itemInfo, position);
        }
        else
        {
            infoBox.HideInfo();
        }
    }
}
