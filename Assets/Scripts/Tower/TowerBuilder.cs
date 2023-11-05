using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private Human _human;

    private Vector3 _spawnPosition;
    private Vector3 _startPathPosition;
    private Vector3 _finishPathPosition;

    private int _humansInTower;
    private int _towersOnRoad;
    
    private float _spawnPositionYMultiplier = 1.5f;
<<<<<<< HEAD
    private float _distanceBetweenTowers;
=======
    private float _distanñeBetweenTowers;
>>>>>>> origin/main

    private void Awake()
    {
        _towersOnRoad = Random.Range(1, 10);
        
        GetPreviousPositionsAndCalculations();
    }

    public List<Human> Build()
    {
        List<Human> humans = new List<Human>();

        for (int i = 0; i < _towersOnRoad; i++)
        {
            _humansInTower = Random.Range(1, 10);

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

<<<<<<< HEAD
            _spawnPosition = new Vector3(_spawnPosition.x + _distanceBetweenTowers, 0, _spawnPosition.z);
=======
            _spawnPosition = new Vector3(_spawnPosition.x + _distanñeBetweenTowers, 0, _spawnPosition.z);
>>>>>>> origin/main
        }
        
        return humans;
    }

    private Human SpawnHuman()
    {
        Human newHuman = Instantiate(_human, _spawnPosition, Quaternion.Euler(0, -90, 0), transform);
        
        return newHuman;
    }

    private void GetPreviousPositionsAndCalculations()
    {
        _startPathPosition = _pathCreator.path.GetPointAtDistance(0);
        _finishPathPosition = _pathCreator.path.GetDirectionAtDistance(1);

<<<<<<< HEAD
        _distanceBetweenTowers = (_finishPathPosition.x - _startPathPosition.x) / _towersOnRoad;
        _spawnPosition = _pathCreator.path.GetPointAtDistance(_distanceBetweenTowers);
=======
        _distanñeBetweenTowers = (_finishPathPosition.x - _startPathPosition.x) / _towersOnRoad;
        _spawnPosition = _pathCreator.path.GetPointAtDistance(_distanñeBetweenTowers);
>>>>>>> origin/main
    }
}
