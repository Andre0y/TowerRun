using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Human _human;
    [SerializeField] private int _humansInTower;
    [SerializeField] private int _towersOnRoad;
    [SerializeField] private PathCreator _pathCreator;

    private Vector3 _spawnPosition;
    private float _spawnPositionYMultiplier = 1.5f;
    private float _distanseBetweenTowers;

    private void Awake()
    {
        _distanseBetweenTowers = _pathCreator.path.length / _towersOnRoad;

        _spawnPosition = _pathCreator.path.GetPointAtDistance(_distanseBetweenTowers - 0.1f);
    }

    public List<Human> Build()
    {
        List<Human> humans = new List<Human>();

        for (int i = 0; i < _towersOnRoad; i++)
        {

            for (int j = 0; j < _humansInTower; j++)
            {
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
        Human newHuman = Instantiate(_human, _spawnPosition, Quaternion.identity, transform);

        return newHuman;
    }
}
