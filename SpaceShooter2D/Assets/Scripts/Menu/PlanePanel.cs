using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanePanel : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private PlayerData _playerData;
    [Space]
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _experienceText;
    [SerializeField] private Text _healthText;
    [SerializeField] private Text _speedText;
    [SerializeField] private Text _rechargeText;

    public Action<int> OnSelected;

    public void Init()
    {
        SetTexts();
    }

    private void SetTexts()
    {
        List<PlayerData.Plane> planes = _playerData.Planes;
        _nameText.text = planes[_id].Name;
        _experienceText.text = $"EXP: {FormatNumbers.FormatNumber(planes[_id].Experience)}";
        _healthText.text = planes[_id].Health.ToString();
        _speedText.text = $"{planes[_id].ShootingSpeed} b/m";
        _rechargeText.text = planes[_id].RechargeSpeed.ToString();
    }

    public void Select()
    {
        OnSelected.Invoke(_id);
    }
}
