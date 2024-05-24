using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity = 10;

    private List<EnemyMover> _pool = new List<EnemyMover>();

    public void Create(EnemyMover prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            EnemyMover enemy = Instantiate(prefab, _container.transform);
            enemy.gameObject.SetActive(false);

            _pool.Add(enemy);
        }
    }

    protected bool TryGetObject(out EnemyMover result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);
        return result != null;
    }
}