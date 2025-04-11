using UnityEngine;
using System.Collections.Generic;

public class FloorManager : MonoBehaviour
{
    public static FloorManager Instance;

    [SerializeField] private int maxFloors = 3;

    private Queue<GameObject> floorQueue = new Queue<GameObject>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void RegisterFloor(GameObject floor)
    {
        floorQueue.Enqueue(floor);

        // Si on dépasse le max, on supprime l’ancien
        if (floorQueue.Count > maxFloors)
        {
            GameObject oldest = floorQueue.Dequeue();
            Destroy(oldest);
        }
    }

    public void ClearAllFloors()
    {
        while (floorQueue.Count > 0)
        {
            Destroy(floorQueue.Dequeue());
        }
    }
}
