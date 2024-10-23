using MyFps;
using UnityEngine;

namespace MyFps
{

    public class PickupAmmo : PickupItem
    {

        [SerializeField] private int giveAmount = 7;

        protected override bool OnPickup()
        {
            // 탄환 7발 지급
            PlayerStats.Instance.AddAmmo(giveAmount);
            
            return true;
        }

    }
}