using UnityEngine;
using UnityEngine.Events;

public class Human : MonoBehaviour
{
    [SerializeField] private Transform _fixationPoint;
    public UnityAction<Human> HumansHit;

    public Transform FixationPoint => _fixationPoint;
    
}
