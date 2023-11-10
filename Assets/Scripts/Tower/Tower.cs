using System.Collections.Generic;
using UnityEngine;
using PathCreation;


[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private List<Human> _humans;
    private TowerBuilder _towerBuilder;
    
    private void Start() //directly build road towers
    {
        _towerBuilder = GetComponent<TowerBuilder>();

        _humans = _towerBuilder.Build();
    }
}
