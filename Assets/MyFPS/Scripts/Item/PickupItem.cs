using UnityEngine;
using UnityEngine.UIElements;

namespace MyFps
{
    public class PickupItem : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float verticalBopfrequency = 1f; // 이동 속도
        [SerializeField] private float popingAmount = 1f;         // 이동 거리 
        [SerializeField] private float rotateSpeed = 360f;        // 회전 속도

        private Vector3 startPosition;                            // 시작 위치

        #endregion

        void Start ()
        {
            // 처음 위치 저장
            startPosition = transform.position;
        }

        private void Update()
        {
            // 위 아래로 흔들림
            float popingAnimationPhase = Mathf.Sin(Time.time * verticalBopfrequency) *popingAmount;
            transform.position = startPosition + Vector3.up * popingAnimationPhase;

            // 회전 
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
        }

        // 아이템 획득
        private void OnTriggerEnter(Collider other)
        {
            // 플레이어 체크
            if(other.tag == "Player")
            {
                // 아이템 획득
                if (OnPickup() == true)
                {
                    // 획득 사운드 등등

                    // 킬
                    Destroy(gameObject);
                }
            }
        }

        // 아이템획득 성공, 실패 반환
        protected virtual bool OnPickup()
        {
            // 7발 지금
            // hp,mp 아이템
            // 기타 등등
            // 아이템 획득

            return true;
        }
    }
}