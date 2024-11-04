using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

namespace MyFps
{
    public class KeyOpen : Interactive
    {
        #region Variables
        public GameObject Door;
        public TextMeshProUGUI textBox;
        [SerializeField] private string Sequence = "You need the Key!";
        #endregion

        protected override void DoAction()
        {
            if(PlayerStats.Instance.HasPuzzleItem(PuzzleKey.ROOM01_KEY))
            {
               OpenDoor();
            }
            else
            {
              StartCoroutine(LockedDoor());
            }
          
        }

        void OpenDoor()
        {
            // 문열기
            this.GetComponent<BoxCollider>().enabled = false;
            Door.GetComponent<Animator>().SetBool("IsOpen", true);
            AudioManager.Instance.Play("DoorOpen");
        }
        IEnumerator LockedDoor()
        {
            unInteractive = true; // 인터렉티브 기능 정지
            AudioManager.Instance.Play("DoorLocked");
          
            yield return new WaitForSeconds(1f);

            textBox.gameObject.SetActive(true);
            textBox.text = Sequence;

            yield return new WaitForSeconds(2f);

            textBox.gameObject.SetActive(false);
            textBox.text = "";

            unInteractive = false; // 다시 가동

        }
    }
}