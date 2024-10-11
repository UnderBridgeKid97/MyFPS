using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    

    public class CEnemyTrigger : MonoBehaviour
    {
        public GameObject theDoor;
        public GameObject door;
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {
            theDoor.GetComponent<Animator>().SetBool("IsOpen", true);
            theDoor.GetComponent<BoxCollider>().enabled=false;
            door.GetComponent<BoxCollider>().enabled = false;
            yield return null;

            
        }
    }
}