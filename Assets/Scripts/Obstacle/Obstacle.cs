using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _countOfDeletedHumans;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerTower playerTower))
        {
            playerTower.DeleteHumans(_countOfDeletedHumans);
        }
    }
}
