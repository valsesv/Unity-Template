using System;
using _Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace valsesv._Project.Scripts.UI
{
    public class UiPanel : MonoBehaviour
    {
        [SerializeField] private Button[] closeButtons;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private bool hideOnAwake = true;

        public event Action OnOpen;
        public event Action OnClosed;

        protected virtual void Awake()
        {
            if (hideOnAwake)
            {
                HidePanelInstantly();
            }
        }

        protected virtual void Start()
        {
            foreach (var button in closeButtons)
            {
                button.onClick.AddListener(CloseWindow);
            }
        }

        public virtual void OpenPanel()
        {
            CanvasSwapper.CanvasGroupSwap(canvasGroup, true);
            OnOpen?.Invoke();
        }

        public virtual void CloseWindow()
        {
            CanvasSwapper.CanvasGroupSwap(canvasGroup, false);
            OnClosed?.Invoke();
        }

        private void HidePanelInstantly()
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}