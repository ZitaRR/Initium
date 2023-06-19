using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Initium.Core
{
    public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private LeanTweenType easing;
        [SerializeField]
        private float offset;
        [SerializeField]
        private float duration;

        private HorizontalLayoutGroup group;
        private RectTransform rect;
        private Vector2 origin;
        private Vector2 target;

        private void Awake()
        {
            group = GetComponentInParent<HorizontalLayoutGroup>();
            rect = GetComponent<RectTransform>();
        }

        private void Start()
        {
            group.CalculateLayoutInputHorizontal();
            group.CalculateLayoutInputVertical();
            group.SetLayoutHorizontal();
            group.SetLayoutVertical();

            origin = rect.anchoredPosition;
            target = new(origin.x, origin.y - offset);
            Debug.Log(origin);
        }

        

        public void OnPointerEnter(PointerEventData eventData)
        {
            LeanTween.move(rect, target, duration).setEase(easing);
            Debug.Log("Hovering card");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            LeanTween.cancel(rect);
            LeanTween.move(rect, origin, duration);
            Debug.Log("Stopped hovering card");
        }
    }
}
