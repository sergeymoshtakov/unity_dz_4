using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<UnitMover> _templates;
    [SerializeField] private int _spawnSize;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private int _spawnPositionRange;
    
    private List<UnitMover> _spawnedUnits = new List<UnitMover>();

    private float _timeToSpawn;
    
    private void Start()
    {
        InitializeSpawn();
    }

    private void Update()
    {
        ActiveSelfChecker();
    }

    private void InitializeSpawn()
    {
        for (var i = 0; i < _spawnSize; i++)
        {
            var newUnit = Instantiate(GetRandomUnit(), RandomPosition(), Quaternion.identity);
            newUnit.gameObject.SetActive(false);
            _spawnedUnits.Add(newUnit);
        }
    }

    private void ActiveSelfChecker()
    {
        _timeToSpawn += Time.deltaTime;

        foreach (var unit in _spawnedUnits)
        {
            if (!unit.gameObject.activeSelf && _timeToSpawn >= _spawnDelay)
            {
                unit.transform.position = RandomPosition();
                unit.gameObject.SetActive(true);
                _timeToSpawn = 0f;
            }
        }
    }

    private UnitMover GetRandomUnit()
    {
        return _templates[Random.Range(0, _templates.Count)];
    }
    
    private Vector2 RandomPosition()
    {
        return new Vector2(transform.position.x, Random.Range(-_spawnPositionRange, _spawnPositionRange));
    }
}
