using System.Collections.Generic;
using UnityEngine;

public class HumanTransfer : MonoBehaviour
{
    private PlayerTower _playerTower;

    private void Start()
    {
        _playerTower = GetComponent<PlayerTower>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Human collectedHuman))
        {
            Tower collectedTower = collectedHuman.GetComponentInParent<Tower>();

            if (collectedTower != null)
            {
                List<Human> collectedHumans = collectedTower.GiveHumans(collectedHuman);

                _playerTower.AddNewHumans(collectedHumans);
                collectedTower.Break();
            }
        }

        if (other.TryGetComponent(out Tower tower))
        {
            tower.Break();
        }
    }
}
