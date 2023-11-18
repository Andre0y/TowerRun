using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private List<Human> _humans;
    private TowerBuilder _towerBuilder;
    
    private void Start() //directly build road towers
    {
        _towerBuilder = GetComponent<TowerBuilder>();

        _humans = _towerBuilder.Build();

        foreach (Human human in _humans)
        {
            human.HumansHit += OnHumansHit;
        }
    }

    private void OnHumansHit(Human hittedHuman)
    {
        _humans.Remove(hittedHuman);
        Destroy(hittedHuman.gameObject);
        
        hittedHuman.HumansHit -= OnHumansHit;

        if (_humans.Count == 0)
        {
            Destroy(gameObject);
        }
    }
}
