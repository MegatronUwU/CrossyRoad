using UnityEngine;

public class LogController : MonoBehaviour
{
    public float Speed = 2f;
    public float MinX = -10f;
    public float MaxX = 10f;

    [SerializeField] public PlayerCollisionHandler _playerHandler; 

    private void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);

        // Si on dépasse la limite droite, on revient à gauche
        if (transform.position.x > MaxX)
        {
            Vector3 newPos = transform.position;
            newPos.x = MinX;
            transform.position = newPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // On vérifie que le joueur est sur le log
        float playerY = other.transform.position.y;
        float logY = transform.position.y;

        // Tolérance de hauteur
        if (playerY >= logY && playerY <= logY + 0.6f)
        {
            Debug.Log("Player monté sur le log");
            _playerHandler?.SetIsOnLog(true, transform, this);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        // Le player quitte le rondin 
        if (other.CompareTag("Player"))
        {
                _playerHandler?.SetIsOnLog(false, null, null);
        }
    }
}