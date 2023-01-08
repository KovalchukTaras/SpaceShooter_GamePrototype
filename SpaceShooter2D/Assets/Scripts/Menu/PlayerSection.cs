using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSection : MonoBehaviour
{
    [SerializeField] private GameObject[] _playerIcons;
    [SerializeField] private GameObject[] _planeIcons;
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _levelText;
    [SerializeField] private Text _healthText;
    [SerializeField] private Text _shootingSpeedText;
    [SerializeField] private Text _rechargeSpeedText;
    [Space]
    [SerializeField] private PlayerData _playerData;

    public void SetAll(int id, int level)
    {
        SetMainData(id, level);
    }

    public void SetMainData(int id, int level)
    {
        _playerIcons[id].SetActive(true);
        _planeIcons[id].SetActive(true);
        for (int i = 0; i < _playerIcons.Length; i++)
            if (i != id)
            {
                _playerIcons[i].SetActive(false);
                _planeIcons[i].SetActive(false);
            }

        List<PlayerData.Plane> planes = _playerData.Planes;
        _nameText.text = planes[id].Name;
        _healthText.text = planes[id].Health.ToString();
        _shootingSpeedText.text = $"{planes[id].ShootingSpeed} b/m";
        _rechargeSpeedText.text = planes[id].RechargeSpeed.ToString();
        _levelText.text = $"Level: {level}";
    }
}
