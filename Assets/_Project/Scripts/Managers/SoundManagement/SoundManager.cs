using UnityEngine;

namespace valsesv._Project.Scripts.Managers.SoundManagement
{
    public class SoundManager : AudioSourceManager
    {
        [SerializeField] private AudioClip turningOnSound;

        public override void Switch()
        {
            base.Switch();
            if (IsOn)
            {
                PlaySound(turningOnSound);
            }
        }

        public void PlaySound(AudioClip audioClip)
        {
            if (IsOn == false)
            {
                return;
            }

            soundSource.PlayOneShot(audioClip);
        }
    }
}