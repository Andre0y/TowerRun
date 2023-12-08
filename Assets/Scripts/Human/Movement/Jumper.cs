using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _currentJumpForce;

    private Rigidbody _rigidbody;
    private bool isGrounded;
    private float normalJumpForce;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        normalJumpForce = _currentJumpForce;
    }

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _currentJumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Road road))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out JumperBooster jumperBooster))
        {
            _currentJumpForce *= jumperBooster.jumperMultiplier;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out JumperBooster jumperBooster))
        {
            _currentJumpForce = normalJumpForce;
        }
    }
}
