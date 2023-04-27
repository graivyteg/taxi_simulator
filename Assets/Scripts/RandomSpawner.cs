using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private List<GameObject> _prefabs;

    [SerializeField] private bool _isThisParent;

    private GameObject _lastSpawned;
    
    public GameObject SpawnObject()
    {
        Transform point = _points[Random.Range(0, _points.Count)];
        _lastSpawned = Instantiate(
            _prefabs[Random.Range(0, _prefabs.Count)],
            point.position,
            point.rotation,
            _isThisParent ? transform : null
        );
        return _lastSpawned;
    }

    public void TryDestroyLast()
    {
        if (_lastSpawned == null) return;
        Destroy(_lastSpawned);
    }
}
