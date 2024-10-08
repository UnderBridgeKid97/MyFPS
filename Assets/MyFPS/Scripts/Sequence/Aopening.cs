using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace MyFps
{
    public class Aopening : MonoBehaviour
    {
        #region Variables

        // 
        public GameObject thePlayer;
        public SceneFader Fader;

        // 시퀀스 텍스트
        public TextMeshProUGUI textBox; 
        [SerializeField] private string sequence = "I Need Get Out Of Here";

        #endregion
        void Start()
        {
            StartCoroutine(PlaySequence());
        }

        // 오프닝 시퀀스
        IEnumerator PlaySequence()
        {
            // 0. 플레이 캐릭터 비 활성화
            thePlayer.SetActive(false);

            // 1. 페이드 인 연출( @초 대기 후 페이드 인 효과 )
              Fader.FromFade(1f);  // 코루틴에 코루틴으로 2초동안 페이드 효과 여기서 대기1 초 씬페이더에서 페이드 1초


            // 2. 화면 하단에 시나리오 텍스트 화면 출력(3초)
            textBox.gameObject.SetActive(true);
            textBox.text = sequence;

            // 3. 3초후에 시나리오 텍스트 없어진다 2가지 방법
            yield return new WaitForSeconds(3f);
             textBox.gameObject.SetActive(false);
            // textBox.text = "";


            // 4. 플레이 캐릭터 활성화
            thePlayer.SetActive(true);



          
        }

    }
}