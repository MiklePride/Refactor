using UnityEngine;

public class PathController : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _wayPoints;
    private int _wayPointIndex;

    private void Start()
    {
        _wayPoints = new Transform[_path.childCount];

        for (int index = 0; index < _path.childCount; index++)
        {
            _wayPoints[index] = _path.GetChild(index);
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_wayPointIndex].position, _speed * Time.deltaTime);

        if (transform.position == _wayPoints[_wayPointIndex].position)
            PassNextPoint();
    }
    private void PassNextPoint()
    {
        _wayPointIndex++;

        if (_wayPointIndex == _wayPoints.Length)
            _wayPointIndex = 0;
    }
}