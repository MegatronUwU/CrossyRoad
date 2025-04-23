using UnityEngine;
using CrossyRoad.Old;

namespace CrossyRoad.New
{
    public class Train : MonoBehaviour
    {
        [SerializeField] private float _speed = 15f;
        [SerializeField] private float _lifeTime = 5f;

        [SerializeField] private float _minimumTimeBeforeMoving = 1f;
        [SerializeField] private float _maximumTimeBeforeMoving = 4f;
        private bool _isMoving = false;

        private void Start()
        {
            float timeBeforeMoving = Random.Range(_minimumTimeBeforeMoving, _maximumTimeBeforeMoving);
            Invoke(nameof(StartMoving), timeBeforeMoving);
            Destroy(gameObject, _lifeTime + timeBeforeMoving);
        }

        private void StartMoving()
        {
            _isMoving = true;
        }

        private void Update()
        {
            if (!_isMoving)
                return;

            transform.Translate(_speed * Time.deltaTime * Vector3.forward);
        }

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.CompareTag("Player"))
        //    {
        //        GameManager.Instance.ShowGameOverUI(); 
        //    }
        //}
    }
}
