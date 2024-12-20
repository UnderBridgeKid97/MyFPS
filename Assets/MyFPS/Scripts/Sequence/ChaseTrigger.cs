using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class ChaseTrigger : MonoBehaviour
    {
        #region

        public Transform gunMan;

        public GameObject ChaseTriggerOut; // out 트리거 
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            // 건맨 추격 시작 
            if(other.tag == "Player")
            {
                if(gunMan != null)
                {
                    gunMan.GetComponent<Enemy>().SetState(EnemyState.E_Chase);

                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            // 건맨 추격 시작 
            if (other.tag == "Player")
            {
                this.gameObject.SetActive(false);

                ChaseTriggerOut.SetActive(true);
                
            }
        }


    }
}