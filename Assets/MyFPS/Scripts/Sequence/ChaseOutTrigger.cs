using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyFps
{
    public class ChaseOutTrigger : MonoBehaviour
    {
        
        public GameObject Intrigger; 
        public GameObject gunMan;

        private void OnTriggerEnter(Collider other)
        {
            // 건맨 GoBack
            if (other.tag == "Player")
            {
                if(gunMan != null)
                {
                    gunMan.GetComponent<Enemy>().GoStartPosition();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            // 건맨 GoBack
            if (other.tag == "Player")
            {
                this.gameObject.SetActive(false);
                Intrigger.SetActive(true);
            }
           
        }
    }
    
}