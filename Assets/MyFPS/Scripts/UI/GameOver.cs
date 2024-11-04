using UnityEngine;

namespace MyFps
{
    public class GameOver : MonoBehaviour
    {
        #region Variables

        public SceneFader fader;
        [SerializeField]private string loadToScene = "PlayScene";
        #endregion


        private void Start()
        {
            // 커서 상태 설정
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


            // 페이드 인 효과
            fader.FromFade();
        }
        
        public void Retry()
        {
            fader.FadeTo(PlayerStats.Instance.NowSceneNumber);
        }
        public void Menu()
        {
            fader.FadeTo(loadToScene);
            //  Debug.Log("Go to Menu!!!!");
        }

    }
}