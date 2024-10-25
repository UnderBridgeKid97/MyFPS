using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MyFps
{
    public class PickupPuzzleItem : Interactive
    {
        #region Variables

        [SerializeField] public PuzzleKey puzzlekey;

        public GameObject puzzleUI;
        public Image itemImage;
        public TextMeshProUGUI puzzleText;

        public GameObject puzzleItemGP;

        public Sprite itemSprite;                                   // 획득 아이템 아이콘 
        [SerializeField] private string puzzleStr = "Puzzle Text";   // 아이템 획득 안내 텍스트 

        #endregion

        protected override void DoAction()
        {
            StartCoroutine(GainPuzzleItem());
        }

        IEnumerator GainPuzzleItem()
        {
            // LEFTEYE 퍼즐 아이템 획득 
            PlayerStats.Instance.AcquierPuzzleItem(puzzlekey);


            yield return null;
        }
    }
}
