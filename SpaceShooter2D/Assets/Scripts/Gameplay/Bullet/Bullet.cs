using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private float _destroyDistance;
    [SerializeField] private string _explosionFxTag;

    private Vector2 _startPos;

    private void Start() => _startPos = transform.position;
    private void FixedUpdate() => Movement();

    protected virtual void Movement()
    {
        transform.position += transform.up * _moveSpeed * Time.deltaTime;
        if (Vector2.Distance(_startPos, transform.position) > _destroyDistance)
            Destroy();
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
        ObjectPooler.Instance.SpawnFromPool(_explosionFxTag, "explosionFx", transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag == "enemyBullet")
        {
            if (collision.gameObject.tag == "Player")
            {
                if (collision.gameObject.TryGetComponent(out Player player))
                {
                    player.GetDamage(_damage);
                    Destroy();
                }
            }
        }
        else
        {
            if (collision.gameObject.tag == "Enemy")
                if (collision.gameObject.TryGetComponent(out Enemy enemy))
                {
                    enemy.GetDamage(_damage);
                    Destroy();
                }
        }
    }
}
