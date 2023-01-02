using UnityEngine;

public abstract class Plane : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _health;
    [SerializeField] protected float _shootingSpeed;
    protected float shootingTimer;

    [Space]
    [SerializeField] protected Gun[] guns;
    [SerializeField] protected string bullet;
    [SerializeField] private Animator _animator;

    [HideInInspector] public bool IsDestroyed;

    private void FixedUpdate()
    {
        Movement();
        Shooting();
    }

    protected abstract void Movement();

    protected virtual void Shooting()
    {
        shootingTimer += Time.fixedDeltaTime;
        if(shootingTimer >= _shootingSpeed)
        {
            Shoot(0, bullet);
            shootingTimer = 0;
        }
    }

    public virtual void GetDamage(float value)
    {
        _animator.SetBool("getHit", true);
        _health -= value;
        if (_health <= 0)
            Death();
    }

    public void Shoot(int gunIndex, string bullet, string tag = "bullet") =>
    guns[gunIndex].Shoot(bullet, tag);

    protected virtual void Death() => _animator.SetBool("destroyed", true);

    public void StopPlane() => _moveSpeed = 0;
}
