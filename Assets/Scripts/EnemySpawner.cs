using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _spawnPeriod;

    private Transform[] _spawnPoints;

    private float _passedTime;
    private int _currentSpawnPoint = 0;

    private void Start()
    {
        _spawnPoints = new Transform[transform.childCount];

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = (transform.GetChild(i));
        }
    }

    private void Update()
    {
        _passedTime += Time.deltaTime;

        if (_passedTime >= _spawnPeriod)
        {
            Instantiate(_enemy, _spawnPoints[_currentSpawnPoint]);
            _passedTime = 0;
            _currentSpawnPoint++;
        }

        if (_currentSpawnPoint >= _spawnPoints.Length)
            _currentSpawnPoint = 0;
    }
}
