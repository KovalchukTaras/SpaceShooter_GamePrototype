using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Map _map;
    [SerializeField] private Hangar _hangar;
    [SerializeField] private Shop _shop;
    [SerializeField] private PlayerSection _playerSection;
    [SerializeField] private Ammunition _ammunition;
    [SerializeField] private Message _message;
    [Space]
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private BulletData _bulletData;
    [SerializeField] private int[] _ammunitionCount;
    [Space]
    [SerializeField] private Text _coinsText;
    [SerializeField] private Text _experienceText;

    private int _planeId;
    private float _coins;
    private float _experience;
    private int _activeLevel;


    private void Start()
    {
        GetSavedData();
        SetMainTexts();
        SelectPlayer(_planeId);
        _ammunition.SetValues(_ammunitionCount);
        GoToMap();
    }

    private void GetSavedData()
    {
        _coins = PlayerPrefs.GetFloat("Coins");
        _experience = PlayerPrefs.GetFloat("Experience");
        _activeLevel = PlayerPrefs.GetInt("Level");
        _planeId = PlayerPrefs.GetInt("PlaneId");

        for(int i = 0; i < _ammunitionCount.Length; i++)
            _ammunitionCount[i] = PlayerPrefs.GetInt($"Ammunition{i}Count");
    }


    private void SubscribeMapPanels(IMenuPanel[] menuPanels)
    {
        foreach (var panel in menuPanels)
            panel.OnSelected += SelectLevelToPlay;
    }

    private void SubscribeHangarPanels(IMenuPanel[] menuPanels)
    {
        foreach (var panel in menuPanels)
            panel.OnSelected += SelectPlayer;
    }

    private void SubscribeShopPanels(IMenuPanel[] menuPanels)
    {
        foreach (var panel in menuPanels)
            panel.OnSelected += AddAmmunition;
    }


    private void SelectLevelToPlay(int level)
    {
        PlayerPrefs.SetInt("LevelToPlay", level);
        StartPlay();
    }

    private void SelectPlayer(int id)
    {
        float newPlaneExp = _playerData.Planes[id].Experience;
        if (_experience >= newPlaneExp)
        {
            _planeId = id;
            PlayerPrefs.SetInt("PlaneId", _planeId);
            _playerSection.SetAll(id, CalculatePlayerLevel());
            GoToMap();
        }
        else _message.ShowMessage("Need more experience!");
    }

    private void AddAmmunition(int id)
    {
        float price = _bulletData.Bullets[id].Price;
        if (price <= _coins)
        {
            _coins -= price;
            _ammunitionCount[id]++;
            SetMainTexts();
            _ammunition.SetValues(_ammunitionCount);
            _shop.Init(_ammunitionCount);

            PlayerPrefs.SetInt($"Ammunition{id}Count", _ammunitionCount[id]);
            PlayerPrefs.SetFloat("Coins", _coins);
        }
        else _message.ShowMessage("Need more gems!");
    }

    private int CalculatePlayerLevel() => Mathf.CeilToInt(_experience / 1000);

    private void StartPlay() => SceneManager.LoadScene(2);

    public void GoToMap()
    {
        _map.gameObject.SetActive(true);
        _hangar.gameObject.SetActive(false);
        _shop.gameObject.SetActive(false);

        _map.Init(_activeLevel);
        SubscribeMapPanels(_map.Levels);
    }

    public void GoToHangar()
    {
        _hangar.gameObject.SetActive(true);
        _map.gameObject.SetActive(false);
        _shop.gameObject.SetActive(false);

        _hangar.Init();
        SubscribeHangarPanels(_hangar.Panels);
    }

    public void GoToShop()
    {
        _shop.gameObject.SetActive(true);
        _map.gameObject.SetActive(false);
        _hangar.gameObject.SetActive(false);

        _shop.Init(_ammunitionCount);
        SubscribeShopPanels(_shop.Panels);
    }

    private void SetMainTexts()
    {
        _coinsText.text = FormatNumbers.FormatNumber(_coins);
        _experienceText.text = FormatNumbers.FormatNumber(_experience);
    }
}