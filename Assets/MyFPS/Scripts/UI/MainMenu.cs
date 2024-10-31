using UnityEngine.UI;
using MyFps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

namespace MyFps
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables

        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene01";

        private AudioManager audioManager;

        public GameObject mainMenuUI;
        public GameObject optionsUI;
        public GameObject creditUI;

        // audio
        public AudioMixer audioMixer;
        public Slider bgmSlider;
        public Slider sfxSlider;

        #endregion

        private void Start()
        {
            // 게임 저장데이터, 저장된 옵션값 불러오기
            LoadOptions();


            // 씬페이드 효과
            fader.FromFade();


            // 참조
            audioManager = AudioManager.Instance;
            // bgm 플레이
            audioManager.PlayBgm("MenuBGM");
           
        }

        public void newGame()
        {
            audioManager.Stop(audioManager.BgmSound);
            audioManager.Play("MenuButton");

            fader.FadeTo(loadToScene);

            Debug.Log("new game");
        }

        public void loadGame()
        {
            //   fader.FadeTo(loadToScene);

            Debug.Log("go to loadGame");
        }
        public void options()
        {
            audioManager.Play("MeinButton");
            Showoptions();
        }

        private void Showoptions()
        {
         audioManager.Play("MeinButton");
         mainMenuUI.SetActive(false);
         optionsUI.SetActive(true);
          

        }
        public void Hideoptions()
        {
            // 옵션창을 나갈때 옵션값 저장
            SaveOptions();

            optionsUI.SetActive(false);
            mainMenuUI.SetActive(true);
        }

        public void credits()
        {
            ShowCredit();
        }

        public void quitgame()
        {
            // cheating
         //   PlayerPrefs.DeleteAll();


            Debug.Log("QUIT GAME");
            Application.Quit();
        }

        // AudioMixer Bgm -40 ~ 0
        public void SetBgmVolume(float value)
        {
            audioMixer.SetFloat("BgmVolume", value);
        }
        // AudioMixer Sfx -40 ~ 0
        public void SetSfxVolume(float value)
        {
            audioMixer.SetFloat("SfxVolume", value);
        }

        // 옵션값 저장하기
        private void SaveOptions()
        {
            PlayerPrefs.SetFloat("BgmVolume", bgmSlider.value);
            PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);
        }

            // 옵션 값 로드하기
        private void LoadOptions()
        {
            // 배경음 볼륨
            float bgmVolume = PlayerPrefs.GetFloat("BgmVolume",0);
            Debug.Log($"bgmVloume:{bgmVolume}");
            SetBgmVolume (bgmVolume);   // 사운드 볼륨 조절
            bgmSlider.value = bgmVolume; // 옵션UI의 bgm 슬라이더 값 조절

            // 효과음 볼륨 
            float sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 0);
            SetSfxVolume(sfxVolume);   // 사운드 볼륨 조절
            sfxSlider.value = sfxVolume; // 옵션UI의 sfx 슬라이더 값 조절

            // 기타......
        }
        private void ShowCredit()
        {
            mainMenuUI.SetActive (false);
            creditUI.SetActive(true);
        }

    }
}