using UnityEngine;

namespace MySample
{
    public class SoundTest : MonoBehaviour
    {
        #region Variables

        private AudioSource audioSource;

        public AudioClip clip; // 재생할 오디오 클립

        [SerializeField]private float volume = 1.0f;
        [SerializeField]private float pitch = 1.0f;
        [SerializeField]private bool loop = false;
     // [SerializeField]private bool playOnAwake = false;
        #endregion


        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            soundOneShot();
        }

        void soundPlay()
        {
            audioSource.clip = clip; // 스크립트의 오디오 클립을 오디오 소스 컴퍼넌트에 넣어줌
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.loop = loop;


            audioSource.Play();
        }
        void soundOneShot()
        {
            audioSource.PlayOneShot(clip); 
        }
        

    }
}