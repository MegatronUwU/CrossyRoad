using UnityEngine;

public class SectionSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _floorPrefab;
    [SerializeField] private Vector3 _spawnOffset = new Vector3(0, 0, 30f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(_floorPrefab, transform.position + _spawnOffset, Quaternion.identity);
        }
    }
}
