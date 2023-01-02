using UnityEngine;

public class Enemy : Plane
{
    [SerializeField] private float _experience;
    private const float _destroyPosX = -30;

    protected override void Movement()
    {
        transform.position += Vector3.left * _moveSpeed;
        if (transform.position.x < _destroyPosX)
            Death();
    }

    protected override void Shooting()
    {
        shootingTimer += Time.fixedDeltaTime;
        if (shootingTimer >= _shootingSpeed)
        {
            for (int i = 0; i < guns.Length; i++)
                Shoot(i, bullet, "enemyBullet");
            shootingTimer = 0;
        }
    }

    protected override void Death()
    {
        base.Death();
        if (IsDestroyed) return;

        ObjectPooler.Instance.SpawnFromPool("coin", "coin", transform.position, transform.rotation);
        ObjectPooler.Instance.SpawnFromPool("experienceText", "experienceText", transform.position, transform.rotation);

        GameController.Instance.EnemyKilled();
        GameController.Instance.AddExperience(_experience);

        IsDestroyed = true;
    }
}
