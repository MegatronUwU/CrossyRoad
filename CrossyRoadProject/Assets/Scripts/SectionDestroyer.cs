using UnityEngine;

public class TriggerDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Activ�" + other.name + "Tag" + other.tag);
        if (!other.CompareTag("Player")) return;

        FloorManager.Instance.ClearAllFloors();
    }
}
