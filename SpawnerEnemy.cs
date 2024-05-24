using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : EnemyPool
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private EnemyMover _enemy;
    [SerializeField] private float _timeBetweenSpawn = 2f;
    [SerializeField] private float deactivateTime = 10f;

    private void Start()
    {
        Create(_enemy);
        StartCoroutine(SpawnEnemiesRepeatedly());
    }

    private void Update()
    {
        if (TryGetObject(out EnemyMover enemy))
            StartCoroutine(UpdateDeactivateTimer(enemy));
    }

    private IEnumerator SpawnEnemiesRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeBetweenSpawn);

            if (TryGetObject(out EnemyMover enemy))
            {
                int spawnPointIndex = Random.Range(0, _spawnPoints.Count);
                SetEnemy(enemy, _spawnPoints[spawnPointIndex].position);
            }
        }
    }

    private IEnumerator UpdateDeactivateTimer(EnemyMover enemy)
    {
        yield return new WaitForSeconds(deactivateTime);
        enemy.gameObject.SetActive(false);
    }

    private void SetEnemy(EnemyMover enemy, Vector3 spawnPoint)
    {
        enemy.gameObject.transform.position = spawnPoint;
        enemy.gameObject.SetActive(true);

        if (enemy.gameObject.TryGetComponent(out EnemyMover enemyMover))
        {
            Vector3 randomDirection = SetRandomDirection();
            enemyMover.SetRandomDirection(randomDirection);
        }
    }

    private Vector3 SetRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        Vector3 randomDirection = Quaternion.Euler(0, randomAngle, 0) * Vector3.forward;
        return randomDirection;
    }
}