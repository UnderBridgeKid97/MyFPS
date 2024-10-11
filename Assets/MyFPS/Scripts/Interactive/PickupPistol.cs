using TMPro;
using UnityEngine;

namespace MyFps
{
    public class PickupPistol : Interactive
    {
        #region Variables
        

        // ActionUI
        public GameObject realPistol;
        public GameObject arrow;
        #endregion

        
       protected override void DoAction()
        {
            // Action
            realPistol.SetActive(true);
            arrow.SetActive(false);
            Destroy(gameObject);
        }
    }
}