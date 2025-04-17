using UnityEngine;

namespace CrossyRoad.New
{
    public class GridCoinPickup : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // Todo Ajouter au score 
                Debug.Log("Coin r�cup�r�e");
                Destroy(gameObject);
            }
        }
    }
}
