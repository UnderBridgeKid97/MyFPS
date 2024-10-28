using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class PickRighteye : PickupPuzzleItem
    {
        #region Variables
        public GameObject fakewall;
        public GameObject exitwall;

        #endregion

        protected override void DoAction()
        {
            StartCoroutine(GainPuzzleItem());

            ShowExitwall();
        }

        private void ShowExitwall()
        {
            // eye 두개 다 있을 때 
            if(PlayerStats.Instance.HasPuzzleItem(PuzzleKey.LEFTEYE_KEY)
            && PlayerStats.Instance.HasPuzzleItem(PuzzleKey.RIGHTEYE_KEY))
            // 출구 보이기 
            fakewall.SetActive(false);
            exitwall.SetActive(true);

        }





    }
}