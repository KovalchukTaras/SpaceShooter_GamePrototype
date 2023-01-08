using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletPanel : Panel
{
    [SerializeField] private BulletData _bulletData;
    [Space]
    [SerializeField] private Text _damageText;
    [SerializeField] private Text _countText;

    public Action<int> OnSelected { get; set; }

    public override void SetValues()
    {
        List<BulletData.BulletInfo> bullets = _bulletData.Bullets;
        _nameText.text = bullets[Id].Name;
        _damageText.text = FormatNumbers.FormatNumber(bullets[Id].Damage);
        _priceText.text = FormatNumbers.FormatNumber(bullets[Id].Price);
    }

    public void SetCount(int value) => _countText.text = $"x{value}";
}
