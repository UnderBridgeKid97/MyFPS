using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditorInternal.VR;

namespace MyFps
{
    public class Intro : MonoBehaviour
    {
        #region

        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene01";

        // 0.08
        public CinemachineDollyCart cart;
        private bool[] isAaarive;
        [SerializeField] private int wayPointIndex = 0; // 이동 목표지점 웨이포인트

        // 인트로 연출 애니메이션
        public Animator cameraAnim;
        public GameObject introUI;
        public GameObject theShedLight;
        #endregion

        private void Start()
        {
            // 초기화
            cart.m_Speed = 0f;
            wayPointIndex = 0;
            isAaarive = new bool[5];

            // 인트로 시작
            StartCoroutine(StartIntro());
        }

        private void Update()
        {
            // 도착판정
            if (cart.m_Position >= wayPointIndex && isAaarive[wayPointIndex]==false)
            {

                // 연출 
                if(wayPointIndex == isAaarive.Length - 1)
                {
                    // 마지막 지점 연출
                    StartCoroutine(EndIntro());

                }
                else
                {
                    StartCoroutine(StayIntro());
                }

            }
            // 인트로 스킵
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                GoToMainScene();
            }

        }


        IEnumerator StartIntro()
        {
            isAaarive[wayPointIndex] = true;
            wayPointIndex++;

            fader.FromFade();
            AudioManager.Instance.PlayBgm("IntroBgm");


            yield return new WaitForSeconds(1f);

            // 카메라 애니메이션
            cameraAnim.SetTrigger("AroundTrigger");

            yield return new WaitForSeconds(3f);
            // 출발
            cart.m_Speed = 0.08f;


        }
        IEnumerator StayIntro()
        {
            isAaarive[wayPointIndex] = true;
            wayPointIndex++;

            cart.m_Speed = 0f;

           // Debug.Log($"{wayPointIndex}지점 도착");
            yield return new WaitForSeconds(1f);
            // 카메라 애니메이션
            cameraAnim.SetTrigger("AroundTrigger");
            int nowIndex = wayPointIndex - 1; // 현재 위치하고 있는 웨이포인트 인덱스

            switch(nowIndex)
            {
                case 1:
                    introUI.SetActive(true);
                    break;
                 case 2:
                    introUI.SetActive(false);
                    break;
                    case 3:
                    theShedLight.SetActive(true);
                    break;
            }

            yield return new WaitForSeconds(3f);

            if(nowIndex == 3)
            {
                introUI.SetActive(true);
                yield return new WaitForSeconds(3f);
            }

            // 출발
            cart.m_Speed = 0.08f;
        }

        //
        IEnumerator EndIntro()
        {
            isAaarive[wayPointIndex] = true;
            cart.m_Speed = 0f;
            yield return new WaitForSeconds(2f);

            theShedLight.SetActive(false);
            yield return new WaitForSeconds(2f);

            AudioManager.Instance.StopBgm();
            fader.FadeTo(loadToScene);
        }


        private void GoToMainScene()
        {
            AudioManager.Instance.StopBgm();
            fader.FadeTo(loadToScene);
        }
           
    }
}