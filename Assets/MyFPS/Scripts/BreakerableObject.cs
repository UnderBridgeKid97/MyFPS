using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{

    public class BreakerableObject : MonoBehaviour,IDamageable
    {
        #region
       
        public GameObject breakObject; // 깨지는 오브젝트
        public GameObject fakeObject;  // 온전한 오브젝트
        public GameObject effectObject;// 깨짐 이펙트

        public GameObject hiddenItem;  // 숨겨진 오브젝트

        private bool isBreak = false; // 중복 깨짐 방지
       [SerializeField]private bool unBreakable = false;   // true = 깨지지않음
        #endregion

        // 총을 맞으면 

        public void TakeDamage(float damage)
        {
            // 깨짐여부 체크
            if(unBreakable)
            {
                return;
            }

            // health ㄴㄴ 원샷 원킬
            if(!isBreak)
            {
                StartCoroutine(BreakObject());
            }
        }
        // 페이크-> 브레이크 오브젝트로 체인지
        IEnumerator BreakObject()
        {
           isBreak = true;

            this.GetComponent<BoxCollider>().enabled = false;

            fakeObject.SetActive(false);

            yield return new WaitForSeconds(0.05f);

            AudioManager.Instance.Play("PotterySmash");
            breakObject.SetActive(true);

            if(effectObject != null)
            {
                effectObject.SetActive(true);

                yield return new WaitForSeconds(0.1f);
                effectObject.SetActive(false);
            }

            // 숨겨진 아이템이 있으면 보여주기
          if(hiddenItem != null)
            {
                hiddenItem.SetActive(true);
            }
        }
    }

   





}