using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace MyFps
{
    // // 퍼즐 아이템 획득여부
    public enum PuzzleKey
    {
        ROOM01_KEY,
        LEFTEYE_KEY,
        RIGHTEYE_KEY,
        MAX_KEY         // 퍼즐 아이템 개수


    }

    // 플레이어의 속성, 데이터값을 관리하는 (싱글톤, DontDestroy)클래스...AmmoCount
    public class PlayerStats : PersistentSington<PlayerStats>
    {
        #region Variables
        // 저장된 SceneNumber
        private int sceneNumber;
        public int SceneNumber
        {
            get { return sceneNumber; }
            set { sceneNumber = value; }
         }
        // 지금 플레이하고있는 SceneNumber
        private int nowSceneNumber;
        public int NowSceneNumber
        {
            get { return nowSceneNumber; }
            set { nowSceneNumber = value; }
        }

        // 탄환갯수
        [SerializeField]private int ammoCount;



        public int AmmoCount
        {  
            get { return ammoCount; } 
            private set {ammoCount = value; }
        }

        // 무기 소지 여부
        private bool hasGun;
        public bool HasGun
        {
            get { return hasGun; }
            set { hasGun = value; }
        }

        // 게임 퍼즐 아이템 키
        private bool[] puzzlekeys;

        #endregion

        private void Start()
        {
         // 초기화 
            puzzlekeys = new bool[(int)PuzzleKey.MAX_KEY];
        }

        public void playerstatInit(PlayData playData)
        {
            if(playData != null)
            {
                SceneNumber = playData.sceneNumber;
                ammoCount = playData.ammoCount;
                hasGun = playData.hasGun;
            }
            else //  저장된 데이터가 없을때 
            {
                SceneNumber = 0;
                ammoCount = 0;
                hasGun = false;
            }
        }

        public void AddAmmo(int amount)
        {
            AmmoCount += amount;
        }

        public bool UseAmmo(int amount)
        {
            // 소지갯수
            if (AmmoCount < amount)
            {
                Debug.Log("You need to reload!!!!!!");
                return false;       // 사용량 부족
            }
            
            AmmoCount -= amount;
            
            return true;
        }

        // 퍼즐 아이템 획득
        public void AcquierPuzzleItem(PuzzleKey key)
        {
            puzzlekeys[(int)key] = true;
        }

        // 퍼즐 아이템 소지여부 
        public bool HasPuzzleItem(PuzzleKey key)
        {
            return puzzlekeys[(int)key];
        }

        // 무기 소지
        public void SetHasGun(bool value)
        {
            HasGun = value;
        }

    }
}