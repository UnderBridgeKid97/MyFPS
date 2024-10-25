using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MyFps
{
    public class PickLefteye : Interactive
    {
        #region Variables

        public GameObject puzzleUI;
        public Image itemImage;
        public TextMeshProUGUI puzzleText;

        public GameObject puzzleItemGP;

        public Sprite itemSprite;                                   // 획득 아이템 아이콘 
        [SerializeField]private string puzzleStr = "Puzzle Text";   // 아이템 획득 안내 텍스트 

        #endregion
        protected override void DoAction()
        {
            StartCoroutine(GainPuzzle());
        }

        IEnumerator GainPuzzle()
        {

            // LEFTEYE 퍼즐 아이템 획득 
            PlayerStats.Instance.AcquierPuzzleItem(PuzzleKey.LEFTEYE_KEY);

            // UI 연출
            if (puzzleUI != null)
            {
              this.GetComponent<BoxCollider>().enabled = false;
               puzzleItemGP.SetActive(false);

                puzzleUI.SetActive(true);
                itemImage.sprite = itemSprite;
                puzzleText.text = puzzleStr;

                yield return new WaitForSeconds(2f);

                puzzleUI.SetActive(false);
            }
            // 킬
            Destroy(gameObject);

        }

    }
}