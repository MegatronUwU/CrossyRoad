using UnityEngine;

public class SectionDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            Destroy(other.gameObject);
        }
    }
}
