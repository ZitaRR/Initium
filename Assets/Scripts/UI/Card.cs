using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Initium.UI
{
    public class Card : Element
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

        protected override void Awake()
        {
            base.Awake();

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
        }

        

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);

            LeanTween.move(rect, target, duration).setEase(easing);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);

            LeanTween.cancel(rect);
            LeanTween.move(rect, origin, duration);
        }
    }
}
