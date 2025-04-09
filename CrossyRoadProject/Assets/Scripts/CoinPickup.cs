using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin récupérée");
            Destroy(gameObject); 
            // To do à rajouter au score
        }
    }
}