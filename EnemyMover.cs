using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Vector3 randomDirection;

    public void SetRandomDirection(Vector3 direction)
    {
        randomDirection = direction;
    }

    private void Update()
    {
        MoveInRandomDirection();
    }

    private void MoveInRandomDirection()
    {
        transform.position += randomDirection * moveSpeed * Time.deltaTime;
    }
}