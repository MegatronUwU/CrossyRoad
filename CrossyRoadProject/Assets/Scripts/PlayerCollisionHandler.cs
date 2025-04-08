using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
	public LayerMask obstacleMask;
	public LayerMask coinMask;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == obstacleMask)
		{
			Debug.Log("Game Over");
			Time.timeScale = 0f;
			GameManager.Instance.ShowGameOverUI();
			return;

		}


		if(collision.gameObject.layer == coinMask)
		{
			//=> win coin
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		//=> est-ce qu'on est sur le trigger d'un rondin
	}
}
