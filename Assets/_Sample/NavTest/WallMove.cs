using UnityEngine;

namespace MySample
{
    public class WallMove : MonoBehaviour
    {
        #region Variables
        [SerializeField]private float moveSpeed = 1f;

        [SerializeField]private float moveTimer = 1f;
        private float countdown = 0f;

        // 이동방향 좌/우
        [SerializeField]private float dir = 1f; // 1->오른족 -1 -> 왼쪽
        #endregion

        private void Start()
        {
            // 초기화
            countdown = 1f;
        }

        private void Update()
        {
            // 좌/우 이동 타이머
            if(countdown <=0f)
            {
                // 타이머 액션 - 방향전환
                dir *= -1;


                // 초기화
                countdown = moveTimer;
            }
            countdown -= Time.deltaTime;

            transform.Translate(Vector3.right * dir*moveSpeed*Time.deltaTime,Space.World);
        }
    }
}