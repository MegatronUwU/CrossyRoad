using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin récupérée");
            ScoreManager.Instance.AddScore(1); 
            Destroy(gameObject);
        }
    }
}