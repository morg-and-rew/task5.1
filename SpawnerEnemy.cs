using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : EnemyPool
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _timeBetweenSpawn = 2f;

    private void Start()
    {
        Create(_enemy);
        StartCoroutine(SpawnEnemiesRepeatedly());
    }

    private IEnumerator SpawnEnemiesRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeBetweenSpawn);

            if (TryGetObject(out GameObject enemy))
            {
                int spawnPointIndex = Random.Range(0, _spawnPoints.Count);
                SetEnemy(enemy, _spawnPoints[spawnPointIndex].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.transform.position = spawnPoint;
        enemy.SetActive(true);
    }
}
