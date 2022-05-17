using UnityEngine;
using System;

[Serializable]
public struct EnemyDetails
{
    //This is for the Inspector, for easier Enemy Spawns and level build
    public int amount;
    public Transform enemyPrefab;
    public float spawnRate;
}
public class Enemy : MonoBehaviour
{
    private bool isDead = false;

    [Header("Enemy Stats")]
    [SerializeField] private float maxHealth = 100;
    //[SerializeField] private int shield;
    public float speed = 5f;
    public float modifiedSpeed;
    public float currentHealth;

    [Header("Enemy Money")]
    [SerializeField] private int moneyDrop;
    
    private void Start()
    {
        currentHealth = maxHealth;
        modifiedSpeed = speed;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        Stats.Money += moneyDrop;

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

    public void Slow(float percent)
    {
        modifiedSpeed = speed * (1f - percent);
    }
}
