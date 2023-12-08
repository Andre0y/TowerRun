using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTower : MonoBehaviour
{
    [SerializeField] private Human[] _templatesHumans;
    [SerializeField] private PlayerFollower _playerFollower;

    private List<Human> _humansInPlayerTower = new List<Human>();
    
    private void Start()
    {
        SpawnFirstHuman();
    }

    private void SpawnFirstHuman()
    {
        Human templateHuman = _templatesHumans[Random.Range(0, _templatesHumans.Length)];
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
        for (int i = 0; i < collectedHumans.Count; i++)
        {
            _playerFollower.AddDistance(collectedHumans[i]);
            
            _humansInPlayerTower.Insert(i, collectedHumans[i]);
            _humansInPlayerTower[i].transform.parent = transform;
        }

        SetHumanPosition();
    }

    public void DeleteHumans(int countOfDeletedHumans)
    {
        if (countOfDeletedHumans >= _humansInPlayerTower.Count)
        {
            SceneManager.LoadScene(0);
        }
        
        for(int i = 0; i < countOfDeletedHumans; i++)
        {
            _humansInPlayerTower[i].transform.parent = null;
            Destroy(_humansInPlayerTower[i].gameObject);
            _humansInPlayerTower.RemoveAt(i);
        }

        SetHumanPosition();
    }
}