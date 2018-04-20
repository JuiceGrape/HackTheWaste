using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]private GameObject Player;
    public List<EnemyWave> EnemyWaves;
    [Tooltip("Time in seconds untill the next enemy spawns")]
    public float TimeToSpawn;

    private int RoundNumber = 0;

    [System.Serializable]
    public struct EnemyWave
    {
        public List<Enemy> Enemies;
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnTimer());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator SpawnTimer()
    {
        SpawnEnemy();
        yield return new WaitForSeconds(TimeToSpawn);
        StartCoroutine(SpawnTimer());
        yield return null;
    }

    private void SpawnEnemy()
    {
        int count = EnemyWaves[RoundNumber].Enemies.Count;
        if (count >= 1)
        {
            int RandomNumber = Random.Range(0, count);
            Enemy newEnemy = Instantiate(EnemyWaves[RoundNumber].Enemies[RandomNumber]);
            newEnemy.gameObject.transform.position = GetSpawnLocation();
            newEnemy.SetPlayer(this.Player);
            EnemyWaves[RoundNumber].Enemies.RemoveAt(RandomNumber);
        }
        if (EnemyWaves[RoundNumber].Enemies.Count <= 0)
        {
            RoundNumber++;
        }
    }

    private Vector3 GetSpawnLocation() {
        Vector3 Location = new Vector3(0, 0, 0);

        return Location;
    }
}
