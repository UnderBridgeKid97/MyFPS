using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    // 메인 2번씬 클리어
    public class ExitTrigger : MonoBehaviour
    {
        #region Variables

        public SceneFader Fader;
        [SerializeField]private string loadToScene = "MainMenuScene";

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            PlaySequence();
        }
        void PlaySequence()
        {
            // 씬 클리어 처리
            // 배경음 종료
            AudioManager.Instance.StopBgm();

            // 씬 클리어 보상 , 데이터 처리, ....

            // 메인 메뉴로 이동 
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Fader.FadeTo(loadToScene);
        }


    }
}