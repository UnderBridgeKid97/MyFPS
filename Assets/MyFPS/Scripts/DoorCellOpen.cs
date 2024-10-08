using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyFps
{
    public class DoorCellOpen : MonoBehaviour
    {
        #region Variables
        public GameObject ActionUI;
        public  TextMeshProUGUI actionText;
        [SerializeField]private string action = "Open The Door";
        public GameObject extraCross;

        private float theDistance;
        // 액션
        private Animator animator;
        private Collider m_collider;
        public AudioSource audioSource;
        #endregion

        private void Start()
        {
            animator = GetComponent<Animator>();
            m_collider = GetComponent<Collider>();
        }
        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }
        // 마우스를 가져가면 액션ui를 보여준다
        private void OnMouseOver()
        {
            // 거리가 2이하일때
            if (theDistance <= 2f)
            {
                ShowActionUI();

                // 문이 열리는 액션
                if (Input.GetButtonDown("Action"))
                {
                    animator.SetBool("IsOpen", true);
                    m_collider.enabled = false;
                    audioSource.Play();
                }
                
            }
            else
            {
                HideActionUI();
            }
           
        }

        // 마우스가 벗어나면 액션ui를 감춘다
        private void OnMouseExit()
        {
            HideActionUI();
        }

        void ShowActionUI()
        {
            ActionUI.SetActive(true);
            actionText.text = action;
            extraCross.SetActive(true);
        }

        void HideActionUI()
        {
            ActionUI.SetActive(false);
            actionText.text = "";
            extraCross.SetActive(false);
        }

    }
}