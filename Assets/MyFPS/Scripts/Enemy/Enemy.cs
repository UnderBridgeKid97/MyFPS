using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static Unity.Burst.Intrinsics.X86;

namespace MyFps
{
    public enum EnemyState
    {
        E_Idle, // 대기
        E_Walk, // 걷기 - 적을 디텍팅하지 못한 경우
        E_Attack, // 스매시 공격
        E_Death,  // 죽기
        E_Chase   // 추격(걷기) - 적을 디텍팅한 경우 
    }

    public class Enemy : MonoBehaviour, IDamageable
    {
        #region
        private Transform thePlayer;
        private Animator animator;
        private NavMeshAgent agent;

        // 적 현재상태
        private EnemyState currentState;
        // 적 이전 상태
        private EnemyState beforstate;

        // 체력
        [SerializeField] private float maxhealth = 20;
        private float currenthealth;

        private bool isDeath = false; // 중복사망 방지

        // 공격
        [SerializeField] private float attackRange = 1.5f; // 공격 가능 범위
        [SerializeField] private float attackDamege = 5f;  // 공격 데미지

        // 패트롤
        public Transform[] wayPoints;
        private int nowWayPonit = 0;

        private Vector3 startPosition; // 시작지점, 타겟이 없어지면 다시 돌아갈 지점 

        // 인식범위

        private bool isAiming = false;
        public bool IsAiming
        {
            get { return isAiming; }
            private set { isAiming = value; }
        }
        [SerializeField] private float detectionRange = 20f;

        #endregion

        private void Start()
        {
            // 참조
            thePlayer = GameObject.Find("Player").transform; // 찾아오기
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();

            // 초기화 
            
            currenthealth = maxhealth;
            startPosition = transform.position;
            nowWayPonit = 0;

            if(wayPoints.Length >0)
            {
                SetState(EnemyState.E_Walk);
                GoNextPoint();
            }
            else
            {
                SetState(EnemyState.E_Idle);
            }
        }

        private void Update()
        {
            if (isDeath)
                return;

            // 타겟지정 
            float distance = Vector3.Distance(thePlayer.transform.position, transform.position);
            if (detectionRange >0)
            {
                 IsAiming = distance <= detectionRange;
            }
            if (distance <= attackRange)
            {
                SetState(EnemyState.E_Attack);
            }
            else if (detectionRange > 0)
            {
                if(IsAiming)
                {
                    SetState(EnemyState.E_Chase);
                }
            }
           

            switch (currentState)
            {
                    case EnemyState.E_Idle:
                        break;
                    
                    case EnemyState.E_Walk:
                    // 도착 판정
                    if (agent.remainingDistance <= 0.2f )
                    {
                        if(wayPoints.Length >0)
                        {
                        GoNextPoint();
                        }
                        else
                        {
                            SetState(EnemyState.E_Idle);
                        }
                    }
                        break;

                    case EnemyState.E_Attack:
                    transform.LookAt(thePlayer.position);
                    if (distance > attackRange)
                    {
                        SetState(EnemyState.E_Chase);
                    }
                    break;

                    case EnemyState.E_Chase:
                    if(detectionRange >0 &&!IsAiming)
                    {
                        GoStartPosition();
                        return;
                    }
                    // 플레이어의 위치를 계속 업데이트
                    agent.SetDestination(thePlayer.position);
                    break;
            }
        }


        // 로봇의 상태 변경 
        public void SetState(EnemyState newState)
        {
           
            // 사망처리 
            if (isDeath)
                return;

            // 현재 상태 체크
            if (currentState == newState)
            {
                return;
            }

            // 이전 상태 저장
            beforstate = currentState;

            currentState = newState;

            // 상태 변경에 따른 구현 내용
            if(currentState == EnemyState.E_Chase)
            {
                animator.SetInteger("EnemyState", 1); // 애니 걷기 동작
                animator.SetLayerWeight(1,1f);
            }
            else
            {
                animator.SetInteger("EnemyState", (int)newState);
                animator.SetLayerWeight(1, 0f);
            }
            // Agent 초기화
            agent.ResetPath();

        }

        private void Attack()
        {

            Debug.Log("플레이어에게 데미지를 준다");
            IDamageable damageable = thePlayer.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(attackDamege);
            }
        }

        public void TakeDamage(float damage)
        {
            currenthealth -= damage;
            Debug.Log($"Enemy Heath:{currenthealth}");
            if (currenthealth <= 0 && !isDeath)
            {
                Die();
            }
        }


        private void Die()
        {
            SetState(EnemyState.E_Death);
            isDeath = true;

            Debug.Log("Enemy Death !");
            SetState(EnemyState.E_Death);

            // 충돌체 제거
            transform.GetComponent<BoxCollider>().enabled = false;
            // 킬
            Destroy(this.gameObject, 3f);
        }

        // 다음 목표지점으로 이동
        private void GoNextPoint()
        {
            nowWayPonit++;
            if(nowWayPonit >=wayPoints.Length)
            {
                nowWayPonit = 0;
            }
            agent.SetDestination(wayPoints[nowWayPonit].position);
        }
        // 제자리로 돌아가기
        public void GoStartPosition()
        {
           
            SetState(EnemyState.E_Walk);

            nowWayPonit = 0; // 웨이포인트를 초기화해서 패트롤 첫 위치로감
            agent.SetDestination(startPosition);
            // agent.SetDestination(wayPoints[nowWayPonit].position); 기존 웨이포인트로 감
            // 또는 가장 가까운 웨이포인트로 감..
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRange);
        }
       


    }
}