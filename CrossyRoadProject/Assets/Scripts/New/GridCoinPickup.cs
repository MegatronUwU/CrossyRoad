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
                Destroy(gameObject);
            }
        }
    }
}
