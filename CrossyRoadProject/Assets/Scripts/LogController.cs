using UnityEngine;

public class LogController : MonoBehaviour
{
    public float Speed = 2f;
    public float MinX = -10f;
    public float MaxX = 10f;

    [SerializeField] public PlayerCollisionHandler PlayerHandler; 

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
        // Le player est transporté par le rondin
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player monté sur le log");
            other.transform.SetParent(transform);

            if (PlayerHandler != null)
                PlayerHandler.SetIsOnLog(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Le player quitte le rondin 
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);

            if (PlayerHandler != null)
                PlayerHandler.SetIsOnLog(false);
        }
    }
}
