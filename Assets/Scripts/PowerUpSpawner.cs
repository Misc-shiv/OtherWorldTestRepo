using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _powerUpPrefab;
    [SerializeField] private Transform _spawnTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_spawnTransform.childCount == 0)
            {
                SpawnPowerUp();
            }
        }
    }

    private void SpawnPowerUp()
    {
        GameObject spawnedPowerUp = Instantiate(
                                    _powerUpPrefab,
                                    _spawnTransform.position,
                                    _spawnTransform.rotation);
        spawnedPowerUp.transform.parent = _spawnTransform;
    }
}