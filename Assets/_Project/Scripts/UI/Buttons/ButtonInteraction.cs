using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using valsesv._Project.Scripts.Managers.SoundManagement;
using Zenject;

namespace valsesv._Project.Scripts.UI.Buttons
{
    public class ButtonInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Button button;
        [SerializeField] private AudioClip buttonSound;
        [SerializeField] private AudioClip hoverSound;
        [SerializeField] private bool hoverEffect;
        [SerializeField, ShowIf(nameof(hoverEffect))]
        private GameObject hoverImage;

        [Inject] private SoundManager _soundManager;

        private void Start()
        {
            button.onClick.AddListener(PlayClickSound);
            EnableHoverImage(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (hoverEffect == false)
            {
                return;
            }

            TryPlayHoverSound();
            EnableHoverImage(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (hoverEffect == false)
            {
                return;
            }
            EnableHoverImage(false);
        }

        private void PlayClickSound()
        {
            _soundManager.PlaySound(buttonSound);
        }

        private void TryPlayHoverSound()
        {
            if (hoverSound)
            {
                _soundManager.PlaySound(hoverSound);
            }
        }

        private void EnableHoverImage(bool isEnabled)
        {
            hoverImage.gameObject.SetActive(isEnabled);
        }
    }
}
