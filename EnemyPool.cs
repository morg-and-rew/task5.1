using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity = 10;

    private List<GameObject> _pool = new List<GameObject>();

    public void Create(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject enemy = Instantiate(prefab, _container.transform);
            enemy.SetActive(false);

            _pool.Add(enemy);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }
}
