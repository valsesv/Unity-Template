using UnityEngine;
using valsesv._Project.Scripts.Interfaces;

namespace valsesv._Project.Scripts.Managers.SoundManagement
{
    public class AudioSourceManager : MonoBehaviour, ISwitchable
    {
        [SerializeField] protected AudioSource soundSource;

        public bool IsOn { get; private set; }

        public virtual void Switch()
        {
            var targetVolume = IsOn ? 1f : 0f;
            SetVolume(targetVolume);
        }

        public void SetVolume(float targetValue)
        {
            soundSource.volume = targetValue;
        }
    }
}