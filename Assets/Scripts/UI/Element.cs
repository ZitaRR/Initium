using Initium.UI;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Element : MonoBehaviour, IHover
{
    public string Name { get => name; }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log($"Hovering {Name}.");
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log($"Stopped hovering {Name}.");
    }
}
