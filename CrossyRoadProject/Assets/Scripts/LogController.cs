using UnityEngine;

public class LogController : MonoBehaviour
{
    public float Speed = 2f;   
    public float MinX = -10f;  
    public float MaxX = 10f;  

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

    private void OnCollisionEnter(Collision collision)
    {
        // Le player est transporté par le rondin
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Le player quitte le rondin 
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
