using UnityEngine;
using System.Collections;
using TMPro;

public class enemySpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float countdownTimer = 1f;
    public float timeBetweenWaves = 5f;
    public int enemyCount = 1;
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public GameObject timerText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdownTimer -= Time.deltaTime;
        if (countdownTimer <= 0f)
        {
            this.StartCoroutine(this.SpawnWave());
            Debug.Log("Resetting timer");
            enemyCount++;
            timeBetweenWaves += (0.2f);
            countdownTimer = timeBetweenWaves;

        }
        timerText.GetComponent<TextMeshProUGUI>().text = Mathf.Floor(countdownTimer+0.5f).ToString("00");
    }

    IEnumerator SpawnWave()
    {
        //Eventually what we'll try to make this is it reads from a text file where each line is a wave.
        Debug.Log("Spawning" + enemyCount +  "enemies");
        for (int i = 0; i < enemyCount; i++)
        {
            Debug.Log("Spawning enemy");
            SpawnEnemy();
            yield return new WaitForSeconds(0.2f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, new Vector3(spawnPoint.position.x, 1, spawnPoint.position.z), spawnPoint.rotation);

    }
}
