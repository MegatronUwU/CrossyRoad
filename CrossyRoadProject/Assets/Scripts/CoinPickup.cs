using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin r�cup�r�e");
            ScoreManager.Instance.AddScore(1); 
            Destroy(gameObject);
        }
    }
}