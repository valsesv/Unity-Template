using UnityEngine;

namespace valsesv._Project.Scripts.Managers.SoundManagement
{
    public class MusicManager : AudioSourceManager
    {
        public void PlayMusic(AudioClip audioClip)
        {
            soundSource.clip = audioClip;
            if (soundSource.isPlaying == false && IsOn)
            {
                soundSource.Play();
            }
        }

        public void PauseMusic()
        {
            soundSource.Pause();
        }
    }
}