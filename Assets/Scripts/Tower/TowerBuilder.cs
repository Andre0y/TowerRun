using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private Human _human;
    [SerializeField] private int _humansInTower;
    [SerializeField] private int _towersOnRoad;

    private Vector3 _spawnPosition;
    private Vector3 _startPathPosition;
    private Vector3 _finishPathPosition;
    private float _spawnPositionYMultiplier = 1.5f;
    private float _distanseBetweenTowers;

    private void Awake()
    {
        _startPathPosition = _pathCreator.path.GetPointAtDistance(0);
        _finishPathPosition = _pathCreator.path.GetDirectionAtDistance(1);
        
        _distanseBetweenTowers = (_finishPathPosition.x - _startPathPosition.x) / _towersOnRoad;
        _spawnPosition = _pathCreator.path.GetPointAtDistance(_distanseBetweenTowers);
    }

    public List<Human> Build()
    {
        List<Human> humans = new List<Human>();
       
        for (int i = 0; i < _towersOnRoad; i++)
        {
            for (int j = 0; j < _humansInTower; j++)
            {
                for (int k = 0; k < _humansInTower; k++)
                {
                    _spawnPosition.z = _pathCreator.path.GetClosestPointOnPath(_spawnPosition).z;
                }
                
                Human newHuman = SpawnHuman();
                
                humans.Add(newHuman);

                _spawnPosition = new Vector3(_spawnPosition.x, _spawnPosition.y + _human.transform.localScale.y * _spawnPositionYMultiplier, _spawnPosition.z);
            }

            _spawnPosition = new Vector3(_spawnPosition.x + _distanseBetweenTowers, 0, _spawnPosition.z);
        }
        
        return humans;
    }

    private Human SpawnHuman()
    {
        Human newHuman = Instantiate(_human, _spawnPosition, Quaternion.Euler(0, -90, 0), transform);
        
        return newHuman;
    }
}
