using System;
using UnityEngine;

namespace Project4_5.Scripts
{
    public class EnemyHealth : MonoBehaviour
    {
        //public event Action OnEnemyDead;
        [SerializeField] private float life = 100f;

        public void TakeDamage(float amount)
        {
            life -= amount;

            if (life <= 0)
            {
                Destroy(gameObject);
                //OnEnemyDead?.Invoke();
            }
        }
    }
}