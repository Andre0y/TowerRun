using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;
    private bool isGrounded;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        isGrounded = false;
        _rigidbody.AddForce(Vector3.up * _jumpForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Road road))
        {
            isGrounded = true;
        }
    }
}
