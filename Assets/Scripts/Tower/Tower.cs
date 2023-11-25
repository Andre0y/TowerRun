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

    public List<Human> GiveHumans(Human givedHuman)
    {
        int countGivedHumans = _humans.IndexOf(givedHuman) + 1;

        List<Human> givedHumans = _humans.GetRange(0, countGivedHumans);
        _humans.RemoveRange(0, countGivedHumans);
        
        return givedHumans;
    }
}
