using Initium.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Element : MonoBehaviour, IHover
{
    public string Name { get => name; }
    public RectTransform Rect { get; private set; }
    public LTDescr Ltd { get; protected set; }

    protected virtual void Awake()
    {
        Rect = GetComponent<RectTransform>();
    }

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
