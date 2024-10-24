using UnityEngine;

namespace MyFps
{
    // // 퍼즐 아이템 획득여부
    public enum PuzzleKey
    {
        ROOM01_KEY,
        MAX_KEY         // 퍼즐 아이템 개수
    }

    // 플레이어의 속성, 데이터값을 관리하는 (싱글톤, DontDestroy)클래스...AmmoCount
    public class PlayerStats : PersistentSington<PlayerStats>
    {
        #region Singleton
        // 탄환갯수
        [SerializeField]private int ammoCount;

        public int AmmoCount
        {  
            get { return ammoCount; } 
            private set {ammoCount = value; }
        }

        // 게임 퍼즐 아이템 키
        private bool[] puzzlekeys;

        #endregion

        private void Start()
        {
            // 속성값 data 초기화
            AmmoCount = 0;
            puzzlekeys = new bool[(int)PuzzleKey.MAX_KEY];
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
    }
}