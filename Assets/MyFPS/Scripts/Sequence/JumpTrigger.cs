using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

namespace MyFps
{
    public class JumpTrigger : MonoBehaviour
    {
        #region Variables

        public GameObject Sphere;
        public GameObject thePlayer;

        #endregion

        // Start is called before the first frame update
        void Start()
        {
          
        }

       
        

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {
            // 플레이어 무브 비활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = false;

            Sphere.SetActive(true);

            yield return new WaitForSeconds(2f);

            // 플레이어 무브 활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = true;

            Destroy(gameObject);
           
            

        }






    }
}