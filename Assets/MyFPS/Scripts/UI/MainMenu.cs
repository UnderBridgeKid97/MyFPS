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
        public GameObject loadGameButton;

        // audio
        public AudioMixer audioMixer;
        public Slider bgmSlider;
        public Slider sfxSlider;

        // 저장되어 있는 씬번호
       // private int sceneNumber;

        #endregion

        private void Start()
        {
            // 게임데이터 초기화
            InitGameData();

         //   int SceneNumber = PlayerPrefs.GetInt("PlayScene",0); // 0은 저장값이 없을때 
          //  Debug.Log($"로드  SceneNumber:{SceneNumber}");
            if(PlayerStats.Instance.SceneNumber >0) // 저장된 값(씬)이 있으면
            {
                loadGameButton.SetActive(true);
            }

            // 씬페이드 효과
            fader.FromFade();


            // 참조
            audioManager = AudioManager.Instance;
            // bgm 플레이
            audioManager.PlayBgm("MenuBGM");
           
        }

        private void InitGameData()
        {
            // 게임설정값: 저장된 옵션값 불러오기
            LoadOptions();

            //  게임 플레이 데이터 로드
            PlayData playData = SaveLoad.LoadData();
            PlayerStats.Instance.playerstatInit(playData);
           
        }


        public void newGame()
        {
            // 게임 데이터 초기화
            PlayerStats.Instance.playerstatInit(null);

            audioManager.Stop(audioManager.BgmSound);
            audioManager.Play("MenuButton");

            fader.FadeTo(loadToScene);

         //   Debug.Log("new game");
        }

        public void loadGame()
        {
            //   fader.FadeTo(loadToScene);
            audioManager.Stop(audioManager.BgmSound);
            audioManager.Play("MenuButton");

            fader.FadeTo(PlayerStats.Instance.SceneNumber);

         //   Debug.Log($"go to loadGame{sceneNumber}번 씬");
        }
        public void options()
        {
            audioManager.Play("MenuButton");
            Showoptions();
        }

        private void Showoptions()
        {
         audioManager.Play("MenuButton");
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
        //    PlayerPrefs.DeleteAll();
         //   SaveLoad.DeleteFile();


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
           // Debug.Log($"bgmVloume:{bgmVolume}");
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