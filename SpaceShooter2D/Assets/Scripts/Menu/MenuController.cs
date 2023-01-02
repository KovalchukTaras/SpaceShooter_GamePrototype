using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private MenuMapController _menuMapController;
    [SerializeField] private HangarController _hangarController;
    [SerializeField] private MenuUI _menuUI;
    [SerializeField] private PlayerData _playerData;

    private float _coins;
    private float _experience;

    private int _levelToPlay;
    private int _activeLevel;

    private int _playerLevel;
    private int _planeIndex;

    private void Start()
    {
        GetSavedData();
        _menuMapController.Init(_activeLevel);
        _menuUI.SetCoinsExpTexts(_coins, _experience);
        SubscribeLevels();
        _hangarController.Init();
        SubscribePlanePanels();
        SelectPlayer(_planeIndex);
        SetPlayerLevel();

        _levelToPlay = _activeLevel;
    }

    private void GetSavedData()
    {
        _coins = PlayerPrefs.GetFloat("Coins");
        _experience = PlayerPrefs.GetFloat("Experience");
        _activeLevel = PlayerPrefs.GetInt("Level");
        _planeIndex = PlayerPrefs.GetInt("PlaneIndex");
    }

    private void SubscribeLevels()
    {
        foreach (var level in _menuMapController.Levels)
            level.OnSelected += SelectLevelToPlay;
    }

    private void SubscribePlanePanels()
    {
        foreach (var level in _hangarController.PlanePanels)
            level.OnSelected += SelectPlayer;
    }

    private void SelectLevelToPlay(int num)
    {
        _levelToPlay = num;
        PlayerPrefs.SetInt("LevelToPlay", _levelToPlay);
        StartPlay();
    }

    private void SelectPlayer(int index)
    {
        float newPlaneExp = _playerData.Planes[index].Experience;
        if (_experience >= newPlaneExp)
        {
            _planeIndex = index;
            List<PlayerData.Plane> planes = _playerData.Planes;
            _menuUI.UpdatePlayerSection(
                _planeIndex,
                planes[_planeIndex].Name,
                planes[_planeIndex].Health,
                planes[_planeIndex].ShootingSpeed,
                planes[_planeIndex].RechargeSpeed
                );
            PlayerPrefs.SetInt("PlaneIndex", _planeIndex);
            GoToMap();
        }
    }

    private void SetPlayerLevel()
    {
        _playerLevel = Mathf.CeilToInt(_experience / 1000);
        _menuUI.SetPlayerLevelText(_playerLevel);
    }

    private void StartPlay()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToMap() => _menuUI.ShowMapSection();

    public void GoToHangar() => _menuUI.ShowHangarSection();

    public void GoToShop() => _menuUI.ShowShopSection();
}