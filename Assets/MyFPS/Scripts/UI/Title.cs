using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace MyFps
{
    public class Title : MonoBehaviour
    {
        #region Variables

        public SceneFader fader;
        [SerializeField] private string loadToScene="MainMenu";

        private bool isAnykey = false;
        public GameObject anykeyUI;

        #endregion

        private void Start()
        {
            // 페이드 인 효과
            fader.FromFade();
            isAnykey = false;

            StartCoroutine(TitleProcess());
        }

        


        private void Update()
        {
            if(Input.anyKey&&isAnykey) 
            {
                GoToMenu();
            }
        }

        // 3초뒤에 anyekyshow, 10초뒤에 자동 넘김
        IEnumerator TitleProcess()
        {


            yield return new WaitForSeconds(4f);
            isAnykey=true;

            anykeyUI.SetActive(true);

            yield return new WaitForSeconds(10f);
            GoToMenu();

        }


        private void GoToMenu()
        {
            StopAllCoroutines();


            fader.FadeTo(loadToScene);
        }



    }
}