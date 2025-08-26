using UnityEngine;
using UnityEngine.EventSystems;

namespace Supertactic.UIEffects
{
    /// <summary>
    /// This script makes the attached button play a smooth and appealing hover effect.
    /// </summary>
    public class UIButtonHoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private Vector2 buttonAnchoredPosition = Vector2.zero;

        private RectTransform rectTransform = null;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            buttonAnchoredPosition = rectTransform.anchoredPosition;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            ButtonHoverManager.Instance.isPointerOverButton = true;
            ButtonHoverManager.Instance.newAnchoredPosition = buttonAnchoredPosition;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ButtonHoverManager.Instance.isPointerOverButton = false;
        }
    }
}