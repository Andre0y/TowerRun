using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private List<Human> _humans;
    private TowerBuilder _towerBuilder;

    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();

        _humans = _towerBuilder.Build();
    }
}
