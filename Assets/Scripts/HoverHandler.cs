using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Info infoBox;  // Reference to the InfoBox script
    [TextArea(3, 10)]public string itemInfo;  // Information to display when hovering

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(WaitTime(true));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
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
