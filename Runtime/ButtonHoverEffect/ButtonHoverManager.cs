using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Supertactic.UIEffects
{
    public class ButtonHoverManager : MonoBehaviour
    {
        public static ButtonHoverManager Instance { get; private set; }

        #region HideInInspector
        [HideInInspector]
        public Vector2 newAnchoredPosition = Vector2.zero;

        [HideInInspector]
        public bool isPointerOverButton = false;
        #endregion

        [Header("Button Hover Effect")]
        public RectTransform buttonHoverRectTransform = null;
        [Space]
        public float lerpSmoothingFactor = 12.0f;
        [Space]
        public List<Image> borderImages = null;

        [Header("Button Hover Effect Sizes")]
        public Vector2 buttonHoverSizeBig = new Vector2(290.0f, 82.0f);
        public Vector2 buttonHoverSizeSmall = new Vector2(258.0f, 50.0f);

        private Color _colorTransparent = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        private Color _colorWhite = Color.white;

        //private float colorLerpDelay = 0.0f;
        public const float delay = 1.0f;

        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            buttonHoverRectTransform.sizeDelta = buttonHoverSizeBig;

            for (int i = 0; i < borderImages.Count; i++)
            {
                borderImages[i].color = _colorTransparent;
            }
        }

        void Update()
        {
            if (isPointerOverButton)
            {
                SetButtonHoverEffect(lerpSmoothingFactor, buttonHoverSizeSmall, _colorWhite);
            }
            else
            {
                SetButtonHoverEffect(lerpSmoothingFactor, buttonHoverSizeBig, _colorTransparent);
            }
        }

        public void SetButtonHoverEffect(float lerpSmoothingFactor, Vector2 buttonHoverSize, Color newColor)
        {
            float delta = Time.unscaledDeltaTime * this.lerpSmoothingFactor;

            buttonHoverRectTransform.anchoredPosition = Vector2.Lerp(buttonHoverRectTransform.anchoredPosition, newAnchoredPosition, delta);
            buttonHoverRectTransform.sizeDelta = Vector2.Lerp(buttonHoverRectTransform.sizeDelta, buttonHoverSize, delta);
            SetButtonHoverEffectBorderColor(newColor, lerpSmoothingFactor);
        }

        void SetButtonHoverEffectBorderColor(Color newColor, float lerpSmoothingFactor)
        {
            for (int i = 0; i < borderImages.Count; i++)
            {
                borderImages[i].color = Color.Lerp(borderImages[i].color, newColor, Time.unscaledDeltaTime * lerpSmoothingFactor);
            }
        }
    }
}