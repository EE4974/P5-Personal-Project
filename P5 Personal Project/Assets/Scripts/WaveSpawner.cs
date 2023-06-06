using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
   public Transform enemyPrefab;
   public  float timeBetweenWaves;
   public float countdown;
   private int waveIndex = 0;
   public Transform spawnPoint;
   public GameObject powerupPrefab;
   public TextMeshProUGUI waveCountdownText;
   public TextMeshProUGUI waveText;
   private int wave;

    void Start()
    {
        wave = -1;
        UpdateWave(0);
    }
    private void UpdateWave(int waveToAdd)
    {
        wave += waveToAdd;
        waveText.text = "Wave: " + wave;

    }
    
    private Vector3 GenerateSpawnPosition() //powerup spawn position
    {
        float spawnPosX = Random.Range(-40, 52);
        float spawnPosZ = Random.Range(-24, 24);
        float spawnPosY = Random.Range(4, 6);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
   
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            UpdateWave(1);
        }
        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave ()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveIndex++;
        PlayerStats.Waves++;
    }

    void SpawnEnemy ()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
