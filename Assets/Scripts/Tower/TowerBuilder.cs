using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Human[] _differentHumans;

    private Vector3 _spawnPosition;
    private int _humansInTower;

    private void Awake() //get previous values
    {
        _humansInTower = Random.Range(1, 10);

        _spawnPosition = transform.position;
    }

    public List<Human> Build() //main create for tower
    {
        List<Human> humans = new List<Human>();

        for (int i = 0; i < _humansInTower; i++)
        {
            Human newHuman = BuildHuman();
            humans.Add(newHuman);
        }
        
        return humans;
    }

    private Human BuildHuman() //spawn main human for towers
    {
        Human templateHuman = _differentHumans[Random.Range(0, _differentHumans.Length)];
        Human newHuman = Instantiate(templateHuman, _spawnPosition, Quaternion.Euler(0, -90, 0), transform);

        _spawnPosition = newHuman.FixationPoint.position;
        
        return newHuman;
    }
}
