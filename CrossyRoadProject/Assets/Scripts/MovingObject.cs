using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 5f;
    public float maxX = 10f;
    public float minX = -10f;

	private void Start()
	{
		transform.position = new Vector3(Random.Range(minX, maxX), transform.position.y, transform.position.z);
	}

	void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Si on dépasse la limite droite, on revient à gauche
        if (speed > 0 && transform.position.x > maxX)
        {
            Vector3 newPos = transform.position;
            newPos.x = minX;
            transform.position = newPos;
        }
        // Si on dépasse la limite gauche, on revient à droite
        else if (speed < 0 && transform.position.x < minX)
        {
            Vector3 newPos = transform.position;
            newPos.x = maxX;
            transform.position = newPos;
        }
    }
}