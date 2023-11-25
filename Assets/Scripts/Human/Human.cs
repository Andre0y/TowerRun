using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody))]
public class Human : MonoBehaviour
{
    [SerializeField] private Transform _fixationPoint;

    public Transform FixationPoint => _fixationPoint;

    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _animator = GetComponent<Animator>();
    }

    public void Bounce()
    {
        float explosionForce = Random.Range(500, 1000);
        float explosionRadius = Random.Range(500, 1000);
        
        Vector3 explosionPosition = new Vector3(transform.position.x - Random.Range(1,5), transform.position.y - Random.Range(1, 5), transform.position.z - Random.Range(1, 5));

        _animator.applyRootMotion = false;
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
        transform.parent = null;

        _rigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);

        Destroy(gameObject, 2f);
    }
}
