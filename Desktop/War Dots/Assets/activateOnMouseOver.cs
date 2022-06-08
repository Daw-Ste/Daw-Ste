using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class activateOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject objectToActivate;
    private bool mouse_over = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        objectToActivate.SetActive(true);
        mouse_over = true;
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        objectToActivate.SetActive(false);
        mouse_over = false;
        Debug.Log("Mouse exit");
    }
}
