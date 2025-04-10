using UnityEngine;

public class TriggerDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Floor")) return;

        Destroy(other.gameObject);
        Debug.Log("Destroy");
    }
}
