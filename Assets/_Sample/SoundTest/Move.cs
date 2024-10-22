using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MySample
{
    public class Move : MonoBehaviour
    {
        #region 

        private Rigidbody rb;

        [SerializeField]private float forwardForce = 5f; // 앞으로 미는 힘
        [SerializeField]private float sideForce = 5f;    // 좌우로 가는 힘

        private float dx; // 좌 우 입력값

        #endregion

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            dx = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            // 자동으로 앞으로 이동
            rb.AddForce(0f, 0f, forwardForce, ForceMode.Acceleration); // Acceleration-> 지속적인 힘/ impuse-> 순간적인 힘
            
            if(dx < 0)
            {
                rb.AddForce(-sideForce, 0f,0f, ForceMode.Acceleration); // +1 ,-1로 좌우 판별
            }
            if(dx > 0)
            {
                rb.AddForce(sideForce, 0f, 0f, ForceMode.Acceleration); // ''
            }

        }
    }
}