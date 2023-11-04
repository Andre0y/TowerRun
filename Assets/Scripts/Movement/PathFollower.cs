using UnityEngine;
using PathCreation;

[RequireComponent(typeof(Rigidbody))]
public class PathFollower : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreation;
    [SerializeField] private float _speed;

    private float _distanceTravelled;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _distanceTravelled += _speed * Time.deltaTime;
        Vector3 newPoint = _pathCreation.path.GetPointAtDistance(_distanceTravelled, EndOfPathInstruction.Loop);

        newPoint.y = transform.position.y;
        transform.LookAt(newPoint);
        _rigidbody.MovePosition(newPoint);
    }
}
