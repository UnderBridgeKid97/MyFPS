using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

namespace MyFps
{
    public class CinemachineShake : Singleton<CinemachineShake>
    {
        #region Variables

        private CinemachineVirtualCamera cvCamera;
        private CinemachineBasicMultiChannelPerlin channelPerlin;

        private bool isShake = false;                   // 데미지 받는 중인지 상태 체크 

     // [SerializeField]private float amplitued = 1f;   // 흔들림의 크기
        [SerializeField]private float frequency = 1f;   // 흔들림의 속도

        #endregion

        protected override void Awake()
        {
            base.Awake();

            cvCamera = this.GetComponent<CinemachineVirtualCamera>();
            channelPerlin = cvCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(); // 시네머신 기능 이용시 겟시네머신컴퍼넌트 사용
        }

      /*  private void Update()
        {
            ★ // cheating tset

            if(Input.GetKeyDown(KeyCode.G))
            {
                ShakeCamera(1f, 1f);
            }
        }*/


        // 카메라 흔들기
        // amplitued : 흔들림 세기, 크기 (진폭),
        // shakeTime : 흔들리는 시간
        public void ShakeCamera(float amplitued, float shakeTime)
        {
            // 현재 흔들리고있으면 리턴
            if (isShake)
            {
                return;
            } 
            StartCoroutine(StartShake(amplitued, shakeTime));
        }

        IEnumerator StartShake(float amplitued, float shakeTime)
        {
            isShake = true;
            channelPerlin.m_AmplitudeGain = amplitued;
            channelPerlin.m_FrequencyGain = frequency;

            yield return new WaitForSeconds(shakeTime);

            channelPerlin.m_FrequencyGain = 0f;
            channelPerlin.m_FrequencyGain = 0f;

            isShake = false ;

        }



    }
}