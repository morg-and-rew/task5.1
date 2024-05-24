using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float deactivateTime = 10f;

    private Vector3 randomDirection;
    private float deactivateTimer;

    private void OnEnable()
    {
        SetRandomDirection();
        deactivateTimer = deactivateTime;
    }

    private void Update()
    {
        MoveInRandomDirection();
        UpdateDeactivateTimer();
    }

    private void MoveInRandomDirection()
    {
        transform.position += randomDirection * moveSpeed * Time.deltaTime;
    }

    private void UpdateDeactivateTimer()
    {
        deactivateTimer -= Time.deltaTime;

        if (deactivateTimer <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void SetRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        randomDirection = Quaternion.Euler(0, randomAngle, 0) * Vector3.forward;
    }
}
