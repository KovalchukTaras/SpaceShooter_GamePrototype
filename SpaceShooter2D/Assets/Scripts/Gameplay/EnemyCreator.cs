using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private float _timeSpace;
    [HideInInspector] private int _level;
    [HideInInspector] public bool _isActive;
    private int _count;
    private float _timer;
    private const float _enemyStartPosX = 35;
    private const float _enemyStartPosYLimit = 11f;

    private void FixedUpdate()
    {
        if (_isActive && _count > 0)
        {
            _timer += Time.deltaTime;
            if (_timer >= _timeSpace)
            {
                CreateEnemy();
                _timer = 0;
            }
        }
    }

    public void Init(int level)
    {
        _level = level;
        _count = (level + 1) * 5;
        GameController.Instance.EnemiesToKill = _count;
        _isActive = true;
    }

    public void Deactivate() => _isActive = false;

    private void CreateEnemy()
    {
        int enemySmallestNum = 0;
        int enemyBiggestNum = _level + 1;
        if (enemyBiggestNum > 9) enemyBiggestNum = 9;

        int randEnemy = Random.Range(enemySmallestNum, enemyBiggestNum);
        string enemyName = "enemy" + randEnemy;

        float randPosY = Random.Range(-_enemyStartPosYLimit, _enemyStartPosYLimit);
        Vector3 enemyPos = new Vector3(_enemyStartPosX, randPosY, 0);
        ObjectPooler.Instance.SpawnFromPool(enemyName, "Enemy", enemyPos, transform.rotation);

        _count--;
    }
}
