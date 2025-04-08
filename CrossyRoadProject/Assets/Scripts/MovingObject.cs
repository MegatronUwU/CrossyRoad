using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 5f;
    public float maxX = 10f;
    public float minX = -10f;

    Rigidbody _rigidBody = null;

    void Update()
    {
        //_rigidBody.AddForce(Vector3.forward, ForceMode.)

        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Si on d�passe la limite droite, on revient � gauche
        if (speed > 0 && transform.position.x > maxX)
        {
            Vector3 newPos = transform.position;
            newPos.x = minX;
            transform.position = newPos;
        }
        // Si on d�passe la limite gauche, on revient � droite
        else if (speed < 0 && transform.position.x < minX)
        {
            Vector3 newPos = transform.position;
            newPos.x = maxX;
            transform.position = newPos;
        }
    }
}