using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanePanel : Panel
{
    [SerializeField] private PlayerData _playerData;
    [Space]
    [SerializeField] private Text _healthText;
    [SerializeField] private Text _speedText;
    [SerializeField] private Text _rechargeText;

    public Action<int> OnSelected { get; set; }

    public override void SetValues()
    {
        List<PlayerData.Plane> planes = _playerData.Planes;
        _nameText.text = planes[Id].Name;
        _priceText.text = $"EXP: {FormatNumbers.FormatNumber(planes[Id].Experience)}";
        _healthText.text = planes[Id].Health.ToString();
        _speedText.text = $"{planes[Id].ShootingSpeed} b/m";
        _rechargeText.text = planes[Id].RechargeSpeed.ToString();
    }
}
