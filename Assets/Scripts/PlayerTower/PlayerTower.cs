using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : MonoBehaviour
{
    [SerializeField] private Human _firstHuman;
    
    private int _collisionsCount;
    private Transform _spawnPosition;
    private List<Human> _humansInPlayerTower = new List<Human>();
    
    private void Start()
    {
        _humansInPlayerTower.Add(_firstHuman);

        _spawnPosition = _firstHuman.FixationPoint;
    }

    private void Update()
    {
        _collisionsCount = 0;
    }

    private void OnCollisionEnter(Collision collison)
    {
        if (collison.gameObject.TryGetComponent(out Human human))
        {
            _collisionsCount += 1;
            
            if(_collisionsCount == 1 && _collisionsCount < 2)
            {
                Human newHuman = SpawnNewHuman(human);
                _humansInPlayerTower.Add(newHuman);
                human.HumansHit?.Invoke(human);
            }
        }
    }

    private Human SpawnNewHuman(Human human)
    {
        Human newHuman =  Instantiate(human, _spawnPosition.position, Quaternion.Euler(0,90,0), transform);
        _spawnPosition.position = newHuman.FixationPoint.position;
        
        return newHuman;
    }
}