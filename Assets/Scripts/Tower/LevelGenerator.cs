using PathCreation;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private Tower _templateTower;
    [SerializeField] private int _minCountTowers;
    [SerializeField] private int _maxCountTowers;

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        float pathLength = _pathCreator.path.length;
        int countTowers = Random.Range(_minCountTowers, _maxCountTowers);
        float distanceBetweenTowers = pathLength / countTowers;

        float distanceTravelled = 0;
        Vector3 spawnPosition;

        for (int i = 0; i < countTowers; i++)
        {
            distanceTravelled += distanceBetweenTowers;
            spawnPosition = _pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);

            Instantiate(_templateTower, spawnPosition, Quaternion.identity);
        }
    }

    private void SetPreviousValues()
    {
        //add
    }
}
