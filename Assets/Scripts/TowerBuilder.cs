using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Human _human;
    [SerializeField] private int _humansOnRoad;
    [SerializeField] private Transform _spawnPosition;
    //[SerializeField] private PathCreator _pathCreator;

    public List<Human> Build()
    {
        List<Human> humans = new List<Human>();

        for (int i = 0; i < _humansOnRoad; i++)
        {
            Human newHuman = SpawnHuman();

            humans.Add(newHuman);
            _spawnPosition.position += _human.transform.position;
        }

        return humans;
    }

    private Human SpawnHuman()
    {
        Human newHuman = Instantiate(_human, _spawnPosition.position, Quaternion.identity, transform);

        return newHuman;
    }
}
