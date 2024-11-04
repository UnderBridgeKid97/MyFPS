using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyFps
{

    public class FullExitEye : Interactive
    {
        public GameObject emrtypicture;
        public GameObject fullpicture;
        public GameObject exitTrigger;

        public Animator animator;

        public TextMeshProUGUI textBox;
        [SerializeField]private string puzzleStr = "You need moer eye picktures";

      
        protected override void DoAction()
        {
            // 퍼즐 조각을 모두 모았는지 체크
           if(PlayerStats.Instance.HasPuzzleItem(PuzzleKey.LEFTEYE_KEY)
            && PlayerStats.Instance.HasPuzzleItem(PuzzleKey.RIGHTEYE_KEY))
            {
                // 출구 열기
                StartCoroutine(OpenExItWall());
                    
            }
            else
            {
                // 메세지 출력 
                StartCoroutine(LockedExitWall());

            }
        }
        IEnumerator OpenExItWall()
        {
            // 완성본 그림 보이기
            emrtypicture.SetActive(false);
            fullpicture.SetActive(true);

            // 출구 열리기
            animator.SetBool("IsOpen",true);
            yield return new WaitForSeconds(0.5f);
            
            // exit trigger 활성화
            exitTrigger.SetActive(true);

        }

        IEnumerator LockedExitWall()
        {
            unInteractive = true; // 인터렉티브 기능 정지

            textBox.gameObject.SetActive(true);
            textBox.text = puzzleStr;


            yield return new WaitForSeconds(2f);

            textBox.text = "";
            textBox.gameObject.SetActive(false);

            unInteractive = false; // 다시 가동
        }

    }
}