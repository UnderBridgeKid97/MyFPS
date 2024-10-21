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

        #endregion

        private void Start()
        {
            // 씬페이드 효과
            fader.FromFade();
        }

        public void newGame()
        {
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