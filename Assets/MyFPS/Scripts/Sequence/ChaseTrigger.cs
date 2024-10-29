using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class ChaseTrigger : MonoBehaviour
    {
        #region

        public Transform gunMan;

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            // 건맨 추격 시작 
            if(other.tag == "Player")
            {
                gunMan.GetComponent<Enemy>().SetState(EnemyState.E_Chase);
                // 
            }
        }
    }
}