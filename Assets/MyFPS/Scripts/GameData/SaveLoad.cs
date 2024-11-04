using UnityEngine;
using System.IO; // 이진화 저장시 필요한 네임스페이스
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary; // 이진화 저장시 필요한 네임스페이스

namespace MyFps
{
    // 게임데이터 파일 저장/가져오기 구현 - 이진화 저장  ★ 공식 ★
    public static class SaveLoad
    {
     private static string fileName ="/PlayData.arr";

        public static void SaveData()
        {
            // 파일이름, 경로, 지정 
            string path = Application.persistentDataPath +"/PlayData.arr"; //  "/PlayData.arr" ->"/PlayData.dat" 보통 dat로 씀

            // 저장할 데이터를 이진화 준비 
            BinaryFormatter formatter = new BinaryFormatter();

            // 파일접근 - 존재하면 파일가져오기, 없으면 파일 새로 생성
            FileStream fs = new FileStream(path,FileMode.Create);

            // 저장할 데이터 셋팅 
            PlayData playData = new PlayData();
            Debug.Log($"Save SceneNumber : {playData.sceneNumber}");


            // 준비한 데이터를 이진화 저장
            formatter.Serialize(fs, playData);

            // 항상 읽거나 쓰면 끝날때 파일클로즈를 해야함
            fs.Close();
        }

        public static PlayData LoadData()
        {
            PlayData playData;

            // 파일이름, 경로, 지정 
            string path = Application.persistentDataPath + "/PlayData.arr"; // 세이브 로드 주소는 항상 동일하게
            
            // 지정된 경로에 저장된 파일이 있는지 없는지 체크
            if(File.Exists(path) == true)
            {
                // 파일이 있을때, 가져올 데이터를 이진화 준비
                BinaryFormatter formatter = new BinaryFormatter();

                // 파일접근 - 존재하면 파일가져오기, 없으면 파일 새로 생성
                FileStream fs = new FileStream(path, FileMode.Open);
                
                // 파일에 이진화로 저장된 데이터를 역이진화해서 가져온다
                playData = formatter.Deserialize(fs) as PlayData;   // 
              //  Debug.Log($"Load SceneNumber : {playData.sceneNumber}");

                // 항상 읽거나 쓰면 끝날때 파일클로즈를 해야함
                fs.Close();
            }

            else
            {
                // 파일이 없을때
                Debug.Log("Not Found Load File");
                playData = null;
            }

            return playData;
        }
        public static void DeleteFile()
        {
            string path = Application.persistentDataPath + fileName;

            File.Delete(path);
        }
    }
}