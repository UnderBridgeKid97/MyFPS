using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{

    public class PlayerMove : MonoBehaviour
    {
        #region Variable

        // 캐릭터 컨트롤러
        private CharacterController controller;

        // 이동속도
        [SerializeField]private float moveSpeed = 10f;

        // 중력가속도
        [SerializeField]private float gravity = -9.81f;
        // 플레이어의 속도 - 중력만 적용 
        [SerializeField]private Vector3 velocity;
        // 그라운드 체크

        // 점프
        [SerializeField] private float jumpHeight = 1f;

        // 그라운드 체크
        [SerializeField] private bool isGround = false;
        public Transform groundCheck;
        [SerializeField] private float checkRange = 0.2f;
        [SerializeField]private LayerMask groundMask;

        #endregion

        private void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            // 그라운드 체크
            isGround = controller.isGrounded;
            if (isGround && velocity.y < 0f)
            {
                velocity.y = -1f;
            }

            // 이동
            Move();

            // 점프
            if(Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                Jump();
            }


            // 중력 가속도
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

        }

        private void Move()
        {
            // 이동
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            Vector3 move = transform.right * moveX + transform.forward * moveY;

            controller.Move(move * Time.deltaTime * moveSpeed);

        }
        private void Jump()
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
        private bool IsGroundCheck()
        {
            return Physics.CheckSphere(groundCheck.position,checkRange,groundMask);
        }

    }
}
/*
    캐릭터 컨트롤: 이동 + 충돌 

  빌트인 character controller : character controller + collider
 - 이동
 - 그라운드 체크
 - 충돌체크
 - 계단
 - 경사면 

 - Rigidbody - Dynamic 
 - Rigidbody - Kinematic










*/