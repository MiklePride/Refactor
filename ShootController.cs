using System.Collections;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _target;
    [SerializeField] private float _timeWaitShooting;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = enabled;
        var waitBetweenShoots = new WaitForSeconds(_timeWaitShooting);

        while (isWork)
        {
            var direction = (_target.position - transform.position).normalized;
            var bullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);

            bullet.transform.up = direction;
            bullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return waitBetweenShoots;
        }
    }
}