using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFps
{
    // 플레이 씬이 시작하면 자동으로 게임데이터 저장
    public class AutoSave : MonoBehaviour
    {
        private void Start()
        {
            // 씬 번호 저장 
            AutoSaveData();
        }

        private void AutoSaveData()
        {
            // 현재 씬 저장
            int sceneNumber = PlayerStats.Instance.SceneNumber;
         //   Debug.Log($"로드  SceneNumber:{sceneNumber}");
            int playScene = SceneManager.GetActiveScene().buildIndex;
          

            // 새로 플레이하는 씬인가?
            if(PlayerStats.Instance.NowSceneNumber > sceneNumber )
            {
             //   Debug.Log($"로드  SceneNumber:{playScene}");
             //   Debug.Log("새로 플레이하는 씬 저장");
                PlayerStats.Instance.SceneNumber = PlayerStats.Instance.NowSceneNumber;
                SaveLoad.SaveData();
            }
        }
    }
}