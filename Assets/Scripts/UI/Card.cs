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
        private Vector2 origin;
        private Vector2 target;

        protected override void Awake()
        {
            base.Awake();

            group = GetComponentInParent<HorizontalLayoutGroup>();
        }

        private void Start()
        {
            group.CalculateLayoutInputHorizontal();
            group.CalculateLayoutInputVertical();
            group.SetLayoutHorizontal();
            group.SetLayoutVertical();

            origin = Rect.anchoredPosition;
            target = new(origin.x, origin.y - offset);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);

            Ltd = UI.Move(this, target, duration).setEase(easing);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);

            float passed = Ltd.passed;

            UI.TryRemoveTweeningElement(this);
            UI.Move(this, origin, Mathf.Approximately(passed, float.Epsilon) ? duration : passed);
        }
    }
}
