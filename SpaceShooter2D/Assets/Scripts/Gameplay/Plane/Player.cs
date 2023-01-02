using System;
using UnityEngine;

public class Player : Plane
{
    public int Id;
    [SerializeField] private GameObject _turbine;
    [SerializeField] private PlayerData _playerData;

    [HideInInspector] public Joystick Joystick;
    [HideInInspector] public Action OnDestroy;
    [HideInInspector] public Action<float> OnHit;

    private Vector2 _bottomLeftCamPoint;
    private Vector2 _topRightCamPoint;

    private void Start()
    {
        GetPlayerData();
        SetMoveLimits(Camera.main);
    }

    public void SetMoveLimits(Camera cam)
    {
        _bottomLeftCamPoint = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        _topRightCamPoint = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
    }

    private void GetPlayerData()
    {
        _health = _playerData.Planes[Id].Health;
        _shootingSpeed = 0.25f - _playerData.Planes[Id].ShootingSpeed / 1000;
    }

    public override void GetDamage(float value)
    {
        base.GetDamage(value);
        OnHit.Invoke(_health);
    }

    protected override void Movement()
    {
        Vector3 moveVector = new Vector3(Joystick.Value.x * _moveSpeed, Joystick.Value.y * _moveSpeed, 0);
        //position limits
        float posX = Mathf.Clamp(transform.position.x, _bottomLeftCamPoint.x, _topRightCamPoint.x);
        float posY = Mathf.Clamp(transform.position.y, _bottomLeftCamPoint.y, _topRightCamPoint.y);
        transform.position = new Vector3(posX, posY, 0);

        transform.position += moveVector * Time.deltaTime;
    }

    protected override void Death()
    {
        base.Death();
        if (IsDestroyed) return;

        _turbine.SetActive(false);
        OnDestroy.Invoke();
        IsDestroyed = true;
    }
}
