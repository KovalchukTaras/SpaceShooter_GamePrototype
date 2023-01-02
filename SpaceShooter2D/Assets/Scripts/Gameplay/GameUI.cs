using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private GameObject _loseMenu;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _startMenu;
    [Space]
    [SerializeField] private Text _coinsText;
    [SerializeField] private Text _experienceText;
    [SerializeField] private Slider _sliderHealth;
    [Space]
    [SerializeField] private Text _winMenuCoinsText;
    [SerializeField] private Text _winMenuExperienceText;
    [SerializeField] private Text _loseMenuCoinsText;
    [SerializeField] private Text _loseMenuExperienceText;

    public void SetSliderValues(float maxValue, float value)
    {
        _sliderHealth.maxValue = maxValue;
        _sliderHealth.value = value;
    }

    public void UpdateSliderValue(float value) => _sliderHealth.value = value;

    public void SetCoinsText(float value) => _coinsText.text = FormatNumbers.FormatNumber(value);

    public void SetExperienceText(float value) => _experienceText.text = FormatNumbers.FormatNumber(value);

    public void ShowPauseMenu() => _pauseMenu.SetActive(true);

    public void ClosePauseMenu() => _pauseMenu.SetActive(false);

    public void ShowStartMenu() => _startMenu.SetActive(true);

    public void CloseStartMenu()
    {
        _startMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }

    public void ShowWinMenu(float coins, float experience)
    {
        _winMenu.SetActive(true);
        _mainMenu.SetActive(false);

        _winMenuCoinsText.text = FormatNumbers.FormatNumber(coins);
        _winMenuExperienceText.text = FormatNumbers.FormatNumber(experience);
    }

    public void ShowLoseMenu(float coins, float experience)
    {
        _loseMenu.SetActive(true);
        _mainMenu.SetActive(false);

        _loseMenuCoinsText.text = FormatNumbers.FormatNumber(coins);
        _loseMenuExperienceText.text = FormatNumbers.FormatNumber(experience);
    }
}
