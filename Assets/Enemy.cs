using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _reducingPlayerValue = 0.1f;

    [SerializeField] private int _enemyHealth = 1;

    public void TakeDamage(int damage)
    {
        _enemyHealth -= damage;

        if (_enemyHealth <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerHealthController>(out PlayerHealthController playerHealthControllerComponent))
        {
            playerHealthControllerComponent.ReducePlayer(_reducingPlayerValue);
        }
    }
}
