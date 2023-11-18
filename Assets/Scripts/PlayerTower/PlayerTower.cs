using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : MonoBehaviour
{
    [SerializeField] private Human[] _templatesHumans;
    
    private Transform _spawnPosition;
    private List<Human> _humansInPlayerTower = new List<Human>();
    
    private void Start()
    {
        SpawnFirstHuman();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Human human) && other.transform.position.y >= human.transform.localScale.y)
        {
            Human newHuman = SpawnNewHuman(human);
            _humansInPlayerTower.Add(newHuman);
            
            human.HumansHit?.Invoke(human);
        }
    }

    private Human SpawnNewHuman(Human human)
    {
        Human newHuman = Instantiate(human, _spawnPosition.position, Quaternion.Euler(0,90,0), transform);
        _spawnPosition.position = newHuman.FixationPoint.position;
        
        return newHuman;
    }

    private void SpawnFirstHuman()
    {
        Human templateHuman = _templatesHumans[Random.Range(1, _templatesHumans.Length)];
        Human firstHuman = Instantiate(templateHuman, transform.position, Quaternion.identity, transform);
        _humansInPlayerTower.Add(firstHuman);

        _spawnPosition = firstHuman.FixationPoint;
    }
}