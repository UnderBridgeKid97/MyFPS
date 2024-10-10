using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyFps
{
    public class FirstTrigger : MonoBehaviour
    {
        #region Variables

        public GameObject thePlayer;
        public GameObject arrow;

        // 시퀀스 텍스트
        public TextMeshProUGUI textBox;
        [SerializeField]
        private string sequence = "Looks like a weapon on that table.";

        #endregion

        void Start()
        {
        }

       
        private void OnTriggerEnter(Collider other)
        {
            
            StartCoroutine(PlaySequence());
        }

        // 
        IEnumerator PlaySequence()
        {
            // 캐릭터 비활성화
            thePlayer.SetActive(false);

            // 대사출력  "Looks like a weapon on that table."
            textBox.gameObject.SetActive(true);
            textBox.text = sequence;

            // 1초 딜레이
            yield return new WaitForSeconds(2f);

            // 화살표 출력
            arrow.SetActive(true);

            // 1초 딜레이
            yield return new WaitForSeconds(1f);

            // 초기화
            textBox.text = "";
            textBox.gameObject.SetActive(false);
            

            // 캐릭터 활성화
            thePlayer.SetActive(true);
            transform.GetComponent<BoxCollider>().enabled = false;

        }
    }
}