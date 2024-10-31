using UnityEngine;

namespace MyFps
{
    public class Credit : MonoBehaviour
    {
        #region Variables

        public GameObject mainMenuUI;

        #endregion

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                HideCredits();
            }
        }

        private void  HideCredits()
        {
            mainMenuUI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}