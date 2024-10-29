using UnityEngine;
using UnityEngine.AI;

namespace MySample
{
    // 마우스로 그라운드르르 클릭하면 클릭한 지점으로 agent를 이동시키기
    public class AgentScripts : MonoBehaviour
    {
        #region Variables

        private NavMeshAgent agent;

        [SerializeField]private Vector3 worldPosition;  // 이동 목표지점 
        #endregion

        private void Start()
        {
            // 참조
            agent = GetComponent<NavMeshAgent>();
         //   agent.SetDestination(worldPosition);
        }
        
       private void Update()
        {
            if(Input.GetMouseButtonDown(1))
            {
                SetDestinationToMousePosition();
            }
        }
       private Vector3 SetDestinationToMousePosition()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit))
            {
                agent.SetDestination(hit.point);
            }
            return hit.point;
        }

    }
}