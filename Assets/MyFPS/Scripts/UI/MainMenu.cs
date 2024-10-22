using System.Collections;
using System.Collections.Generic;
using MyFps;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFps
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables

        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene01";

        private AudioManager audioManager;

        #endregion

        private void Start()
        {
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

        public void option()
        {
            audioManager.PlayBgm("PlayBgm");

            //   fader.FadeTo(loadToScene);

            Debug.Log("show option");
        }

        public void credits()
        {
            //   fader.FadeTo(loadToScene);

            Debug.Log("show credits");
        }

        public void quitgame()
        {
            Debug.Log("QUIT GAME");
            Application.Quit();
        }
    }
}