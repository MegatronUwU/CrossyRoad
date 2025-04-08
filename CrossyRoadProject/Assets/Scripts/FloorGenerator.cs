using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    public GameObject[] floorPrefabs; // Ex : route, herbe
    public int initialLength = 20;

    private int zPos = 0;

    void Start()
    {
        for (int i = 0; i < initialLength; i++)
        {
            SpawnFloor();
        }
    }

    void SpawnFloor()
    {
        int index = Random.Range(0, floorPrefabs.Length);
        Instantiate(floorPrefabs[index], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 1;
    }
}
