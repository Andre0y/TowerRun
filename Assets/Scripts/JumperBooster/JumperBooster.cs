using UnityEngine;

public class JumperBooster : MonoBehaviour
{
    [SerializeField] private float _jumperMultiplier;

    public float jumperMultiplier => _jumperMultiplier; 
}
