using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : MonoBehaviour
{
    [SerializeField] private Human[] _templatesHumans;
    [SerializeField] private BoxCollider _collectorCollider;

    private List<Human> _humansInPlayerTower = new List<Human>();
    
    private void Start()
    {
        SpawnFirstHuman();
    }

    private void SpawnFirstHuman()
    {
        Human templateHuman = _templatesHumans[Random.Range(1, _templatesHumans.Length)];
        Human firstHuman = Instantiate(templateHuman, transform.position, Quaternion.identity, transform);
        _humansInPlayerTower.Add(firstHuman);
    }

    private void SetHumanPosition()
    {
        Vector3 currentHumanPosition = transform.position;
        
        for (int i = 0; i < _humansInPlayerTower.Count; i++)
        {
            _humansInPlayerTower[i].transform.position = currentHumanPosition;
            _humansInPlayerTower[i].transform.localRotation = Quaternion.identity;
            currentHumanPosition = _humansInPlayerTower[i].FixationPoint.transform.position;
        }
    }

    public void AddNewHumans(List<Human> collectedHumans)
    {
        for (int i = 0; i < _humansInPlayerTower.Count; i++)
        {
            _humansInPlayerTower.Insert(i, _humansInPlayerTower[i]);
            _humansInPlayerTower[i].transform.parent = transform;
        }

        SetHumanPosition();

        _collectorCollider.transform.position = _humansInPlayerTower[0].transform.position;
    }
}