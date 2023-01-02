using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject _mapSection;
    [SerializeField] private GameObject _hangarSection;
    [SerializeField] private GameObject _shopSection;
    [Space]
    [SerializeField] private Text _coins;
    [SerializeField] private Text _experience;
    [Space]
    [SerializeField] private GameObject[] _playerIcons;
    [SerializeField] private GameObject[] _planeIcons;
    [SerializeField] private Text _playerName;
    [SerializeField] private Text _playerLevel;
    [SerializeField] private Text _health;
    [SerializeField] private Text _shootingSpeed;
    [SerializeField] private Text _rechargeSpeed;
    [Space]
    [SerializeField] private Text[] _rockets;

    public void UpdatePlayerSection(int playerIndex, string name, float health, float shootingSpeed, float rechargeSpeed)
    {

        _playerIcons[playerIndex].SetActive(true);
        _planeIcons[playerIndex].SetActive(true);
        for (int i = 0; i < _playerIcons.Length; i++)
            if (i != playerIndex)
            {
                _playerIcons[i].SetActive(false);
                _planeIcons[i].SetActive(false);
            }

        _playerName.text = name;
        _health.text = health.ToString();
        _shootingSpeed.text = $"{(shootingSpeed * 10)} bullets/m";
        _rechargeSpeed.text = $"{rechargeSpeed} s";
    }

    public void SetCoinsExpTexts(float coins, float experience)
    {
        _coins.text = FormatNumbers.FormatNumber(coins);
        _experience.text = FormatNumbers.FormatNumber(experience);
    }

    public void SetPlayerLevelText(int value)
    {
        _playerLevel.text = $"Level: {value}";
    }

    public void ShowMapSection()
    {
        _mapSection.SetActive(true);
        _hangarSection.SetActive(false);
        _shopSection.SetActive(false);
    }

    public void ShowHangarSection()
    {
        _hangarSection.SetActive(true);
        _mapSection.SetActive(false);
        _shopSection.SetActive(false);
    }

    public void ShowShopSection()
    {
        _shopSection.SetActive(true);
        _hangarSection.SetActive(false);
        _mapSection.SetActive(false);
    }
}
