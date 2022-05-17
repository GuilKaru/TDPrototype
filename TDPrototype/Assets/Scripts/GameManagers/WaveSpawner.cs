using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[Serializable]
public struct WaveDetails
{
    //List of Enemies in EveryWave for the Inspector (Easier Level Building)
    public List<EnemyDetails> Enemies;
}

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    
    [Header("Spawning Points")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform EnemiesPlaceholder;

    [Header("WaveUI")]
    public TextMeshProUGUI currentWave;
    public TextMeshProUGUI totalWaves;

    [Header("Wave Options")]
    private int wavesIndex = 0;
    [SerializeField] private float timeBetweenWaves = 5f;
    public float waitTime = 1f;
    private float waveCD = 5f;

    [SerializeField] private List<WaveDetails> Waves;

    private void Start()
    {
        totalWaves.text = Waves.Count.ToString();
    }

    private void Update()
    {
        
        //If game is over, stop all update
        if (GameManager.gameEnded) return;

        if (EnemiesAlive > 0) return;

        if (waveCD <= 0f && wavesIndex < Waves.Count)
        {
            StartCoroutine(SpawnWave(wavesIndex));
            waveCD = timeBetweenWaves;
            return;
        }

        waveCD -= Time.deltaTime;

        if (wavesIndex + 1 <= Waves.Count)
        {
            currentWave.text = (wavesIndex + 1).ToString();
        }

        if((wavesIndex == Waves.Count) && (EnemiesAlive == 0))
        {
            GameManager.gameWon = true;
        }
    }

    //Spawn enemies with Corroutines so you can have a wait time
    IEnumerator SpawnWave(int index)
    {
        if (GameManager.gameEnded)
        {
            yield return new WaitForSeconds(0);
        }
        else
        {
            for (int k = 0; k < Waves[index].Enemies.Count; k++)
            {
                for (int j = 0; j < Waves[index].Enemies[k].amount; j++)
                {
                    EnemiesAlive++;
                    Transform Enemy = Instantiate(Waves[index].Enemies[k].enemyPrefab, spawnPoint.position, 
                                                  spawnPoint.rotation, EnemiesPlaceholder);
                    yield return new WaitForSeconds(Waves[index].Enemies[k].spawnRate);
                    
                }
            }
            yield return new WaitForSeconds(waitTime);
            wavesIndex++;
        }
    }
    
}
