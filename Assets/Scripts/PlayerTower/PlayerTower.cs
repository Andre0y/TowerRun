using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : MonoBehaviour
{
    [SerializeField] private Human[] _templateHumans;
    
    private Transform _spawnPosition;
    private List<Human> _humansInPlayerTower = new List<Human>();
    
    private void Start()
    {
        SpawnFirstHuman(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Human human))
        {
            Human newHuman = SpawnNewHuman(human);
            _humansInPlayerTower.Add(newHuman);
            
            human.HumansHit?.Invoke(human);
        }
    }

    private Human SpawnNewHuman(Human human)
    {
        Human newHuman =  Instantiate(human, _spawnPosition.position, Quaternion.Euler(0,90,0), transform);
        _spawnPosition.position = newHuman.FixationPoint.position;
        
        return newHuman;
    }

    private void SpawnFirstHuman()
    {
        Human templateHuman = _templateHumans[Random.Range(0, _templateHumans.Length)];
        Human firstHuman = Instantiate(templateHuman, transform.position, Quaternion.identity, transform);

        _spawnPosition = firstHuman.FixationPoint;
    }
}