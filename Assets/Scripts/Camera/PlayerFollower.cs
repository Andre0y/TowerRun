using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private PlayerTower _playerTower;

    private Vector3 _offset = new Vector3(-7, 5, 0);

    private void Update()
    {
        transform.position = _playerTower.transform.position + _offset;
        transform.LookAt(_playerTower.transform);
    }

    public void AddDistance(Human addedHuman)
    {
        _offset.y += addedHuman.FixationPoint.position.y / 1.2f;
        _offset.x -= addedHuman.FixationPoint.position.y / 4;
    }
}
