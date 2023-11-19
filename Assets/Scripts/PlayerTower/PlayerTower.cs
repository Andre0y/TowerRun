using System.Collections.Generic;
using TMPro;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Human human) && transform.position.y > human.transform.localScale.y)
        {
            Human newHuman = SpawnNewHuman(human);
            _humansInPlayerTower.Add(newHuman);
            
            human.HumansHit?.Invoke(human);
        }
    }

    private Human SpawnNewHuman(Human human)
    {
        Human newHuman = Instantiate(human, _spawnPosition.position, Quaternion.Euler(0,90,0), transform);
        _spawnPosition = newHuman.FixationPoint;
        
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