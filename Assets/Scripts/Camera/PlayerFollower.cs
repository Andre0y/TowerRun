using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private PlayerTower _playerTower;

    private Vector3 _offset = new Vector3(-5, 7, 0);
    
    private void Update()
    {
        transform.position = _playerTower.transform.position + _offset;
        transform.LookAt(_playerTower.transform);
    }
}
