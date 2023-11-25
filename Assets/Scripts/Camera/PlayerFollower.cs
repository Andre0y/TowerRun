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
        _offset.y += Mathf.Pow(addedHuman.FixationPoint.position.y, 2);
        _offset.x -= Mathf.Pow(addedHuman.FixationPoint.position.y, 2) / 1.5f;
    }
}
