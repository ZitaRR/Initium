using System;
using System.Collections.Generic;
using UnityEngine;

namespace Initium.UI
{
    public static class UI
    {
        private static readonly HashSet<Element> tweeningElements = new();

        public static LTDescr Move(Element element, Vector2 position, float duration, Action action = null)
        {
            LTDescr ltd = LeanTween.move(element.Rect, position, duration);
            ltd.setOnStart(() => TryAddTweeningElement(element))
                .setOnComplete(() =>
                {
                    action?.Invoke();
                    TryRemoveTweeningElement(element);
                });

            return ltd;
        }

        private static bool TryAddTweeningElement(Element element)
        {
            return tweeningElements.Add(element);
        }

        public static bool TryRemoveTweeningElement(Element element)
        {
            bool removed = tweeningElements.Remove(element);
            if (removed)
            {
                LeanTween.cancel(element.Rect);
            }

            return removed;
        }

        public static bool IsTweening(Element element)
        {
            return tweeningElements.Contains(element);
        }
    }
}