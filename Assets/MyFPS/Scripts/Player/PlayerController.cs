using System.Collections;
using UnityEngine;

namespace MyFps
{
    public class PlayerController : MonoBehaviour, IDamageable
    {
        #region
        public SceneFader fader;
        [SerializeField]private string loadToScene = "GameOverScene";


        // 체력
        [SerializeField] private float maxhealth = 20;

        private float currenthealth;

        private bool isDeath = false; // 중복사망 방지

        public GameObject damageFlash; // 데미지 플레시
        public AudioSource hurt01;     // 데미지 사운드 1
        public AudioSource hurt02;     // 데미지 사운드 2
        public AudioSource hurt03;     // 데미지 사운드 3

        // 무기
        public GameObject realPistol;
        #endregion

        private void Start()
        {
            // 초기화 
            currenthealth = maxhealth;

            // 무기획득 
            if(PlayerStats.Instance.HasGun)
            {
                realPistol.SetActive(true);
            }
        }

        public void TakeDamage(float damage)
        {
            currenthealth -= damage;
            Debug.Log($"Player Heath:{currenthealth}");

            // 데미지 효과 vfx , sfx 
            StartCoroutine(DamageEffect());

            if (currenthealth <= 0 && !isDeath)
            {
                Die();
            }
        }

        void Die()
        {
            /* isDeath = true;
             Debug.Log("GameOver!!!");*/
            fader.FadeTo(loadToScene);
        }

        IEnumerator DamageEffect()
        {
            damageFlash.SetActive(true);
            CinemachineShake.Instance.ShakeCamera(1f, 1f);

            int randNumber = Random.Range(1, 4);
            if(randNumber == 1)
            {
                hurt01.Play();
            }
            else if(randNumber==2)
            {
                hurt02.Play();
            }
            else
            {
                hurt03.Play();
            }

            yield return new WaitForSeconds(1f);

            damageFlash.SetActive(false);
        }
    }
}