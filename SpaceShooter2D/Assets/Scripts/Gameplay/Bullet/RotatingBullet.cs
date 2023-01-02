using UnityEngine;

public class RotatingBullet : Bullet
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _rightMoveSpeed;

    protected override void Movement()
    {
        base.Movement();
        transform.position += Vector3.right * _rightMoveSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, _rotationSpeed));
    }
}
