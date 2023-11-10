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
    private float _distanceBetweenTowers;
    //private float _distanceTravelled;

    private void Awake() //get previous values
    {
        _towersOnRoad = Random.Range(1, 10);
        
        SetPreviousPositionsAndCalculations();
    }

    public List<Human> Build() //main create for road towers
    {
        List<Human> humans = new List<Human>();

        for (int i = 0; i < _towersOnRoad; i++)
        {
            _humansInTower = Random.Range(1, 10);
            
            for (int j = 0; j < _humansInTower; j++)
            {
                GetNextSpawnPositionZ();
                
                Human newHuman = SpawnHuman();
                
                humans.Add(newHuman);

                _spawnPosition = new Vector3(_spawnPosition.x, _spawnPosition.y + _human.transform.localScale.y * _spawnPositionYMultiplier, _spawnPosition.z);
            }

            //_distanceTravelled += _distanceBetweenTowers;
            _spawnPosition = new Vector3(_spawnPosition.x + _distanceBetweenTowers, 0, _spawnPosition.z);
        }
        
        return humans;
    }

    private Human SpawnHuman() //spawn main human for towers
    {
        Human newHuman = Instantiate(_human, _spawnPosition, Quaternion.Euler(0, -90, 0), transform);
        
        return newHuman;
    }

    private void SetPreviousPositionsAndCalculations() //start calculations for positions
    {
        _startPathPosition = _pathCreator.path.GetPointAtDistance(0);
        _finishPathPosition = _pathCreator.path.GetDirectionAtDistance(1);
        
        _distanceBetweenTowers = (_finishPathPosition.x - _startPathPosition.x) / _towersOnRoad;
        _spawnPosition = _pathCreator.path.GetPointAtDistance(_distanceBetweenTowers);
        //_spawnPosition = _pathCreator.path.GetPointAtDistance(_distanceTravelled);
    }

    private float GetNextSpawnPositionZ() //calculating next spawn position by z axis 
    {
        for (int i = 0; i < _humansInTower; i++)
        {
            _spawnPosition.z = _pathCreator.path.GetClosestPointOnPath(_spawnPosition).z;
        }

        return _spawnPosition.z;
    }
}
