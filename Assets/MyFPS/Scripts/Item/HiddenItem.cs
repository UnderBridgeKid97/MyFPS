using UnityEngine;

namespace MyFps
{
    public class HiddenItem : Interactive
    {
        #region Variables



        #endregion

        



        protected override void DoAction()
        {
            // key item 저장
            PlayerStats.Instance.AcquierPuzzleItem(PuzzleKey.ROOM01_KEY);


            // 킬
          Destroy(gameObject);

        }
    }
}
