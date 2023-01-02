using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] _backgrounds;
    [SerializeField] private Player[] _players;
    [SerializeField] private EnemyCreator _enemyCreator;
    [SerializeField] private GameUI _gameUI;
    [SerializeField] private PlayerData _playerData;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private MultiButton[] _multibuttons;

    private int _level;
    private float _coins;
    private float _experience;
    private int _planeIndex;
    private Player _player;
    private int _killedEnemies;

    [HideInInspector] public int EnemiesToKill;

    private Vector3 _playerStartPos = new Vector3(-20f, 0, 0);
    private Vector3 _backgroundPos = new Vector3(-13.41f, 0, 0);

    private bool _finished;

    public static GameController Instance;
    private void Awake() => Instance = this;

    private void Start()
    {
        Time.timeScale = 1;
        GetSavedData();
        SetLocation();
        AddPlayer();
        _gameUI.ShowStartMenu();
        _gameUI.SetSliderValues(
            _playerData.Planes[_planeIndex].Health,
            _playerData.Planes[_planeIndex].Health
            );
        SubscribeMultibuttons();
    }

    public void StartGame()
    {
        _gameUI.CloseStartMenu();
        _enemyCreator.Init(_level);
    }

    public void Win()
    {
        if (_finished) return;

        _player.StopPlane();
        float winCoins = _coins * 3;
        float winExperience = _experience * 3;
        _gameUI.ShowWinMenu(winCoins, winExperience);

        if (_level == PlayerPrefs.GetInt("Level"))
            _level++;

        SaveNewData(winCoins, winExperience);
        _finished = true;
    }

    public void Lose()
    {
        if (_finished) return;

        _gameUI.ShowLoseMenu(_coins, _experience);
        SaveNewData(_coins, _experience);
        _finished = true;
    }


    public void AddCoins(float value)
    {
        _coins += value;
        _gameUI.SetCoinsText(_coins);
    }

    public void AddExperience(float value)
    {
        _experience += value;
        _gameUI.SetExperienceText(_experience);
    }

    public void EnemyKilled(int count = 1)
    {
        _killedEnemies += count;
        if (_killedEnemies >= EnemiesToKill)
            Win();
    }

    public void PauseTurnOn()
    {
        _gameUI.ShowPauseMenu();
        Time.timeScale = 0;
    }

    public void PauseTurnOff()
    {
        _gameUI.ClosePauseMenu();
        Time.timeScale = 1;
    }

    public void ReloadScene() =>
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void GoToMainMenu() => SceneManager.LoadScene(1);

    private void SubscribeMultibuttons()
    {
        foreach (var button in _multibuttons)
            button.OnSelected += Shoot;
    }

    private void Shoot(string bulletTag)
    {
        int gunIndex = 0;
        if (bulletTag.Contains("rocket")) gunIndex = 1;
        else if (bulletTag.Contains("bulletBall")) gunIndex = 2;
        _player.Shoot(gunIndex, bulletTag, "bullet");
    }

    private void SetLocation()
    {
        int location = Mathf.CeilToInt(_level / 10);
        if (location >= _backgrounds.Length) location = 0;

        Instantiate(_backgrounds[location], _backgroundPos, Quaternion.identity);
    }

    private void AddPlayer()
    {
        _player = Instantiate(_players[_planeIndex], _playerStartPos, Quaternion.identity);
        _player.Joystick = _joystick;
        _player.OnDestroy += Lose;
        _player.OnHit += UpdateSlider;
    }

    private void UpdateSlider(float value) => _gameUI.UpdateSliderValue(value);

    private void GetSavedData()
    {
        _level = PlayerPrefs.GetInt("LevelToPlay");
        _planeIndex = PlayerPrefs.GetInt("PlaneIndex");
    }

    private void SaveNewData(float coins, float experience)
    {
        PlayerPrefs.SetFloat("Coins", PlayerPrefs.GetFloat("Coins") + coins);
        PlayerPrefs.SetFloat("Experience", PlayerPrefs.GetFloat("Experience") + experience);

        if (_level > PlayerPrefs.GetInt("Level"))
            PlayerPrefs.SetInt("Level", _level);
    }
}
