using UnityEngine;

public class MenuMapController : MonoBehaviour
{
    [SerializeField] public MenuLevel[] Levels;
    [SerializeField] private GameObject[] _maps;

    private int _activeLevel;
    private int _activeMap;

    public void Init(int activeLevel)
    {
        _activeLevel = activeLevel;
        CheckMenuLevels(_activeLevel);
        FindActiveMap(_activeLevel);
    }

    public void CheckMenuLevels(int activeLevel)
    {
        foreach (var level in Levels)
            level.CheckActive(activeLevel);
    }

    private void FindActiveMap(int level)
    {
        _activeMap = Mathf.CeilToInt(level / 10);
        ActivateMap(_activeMap);
    }

    private void ActivateMap(int num)
    {
        for (int i = 0; i < _maps.Length; i++)
            if (i == num)
                _maps[i].gameObject.SetActive(true);
            else
                _maps[i].gameObject.SetActive(false);
    }

    public void ShowNextMap()
    {
        _activeMap++;
        if (_activeMap >= _maps.Length)
            _activeMap = 0;
        ActivateMap(_activeMap);
    }

    public void ShowPrevMap()
    {
        _activeMap--;
        if (_activeMap < 0)
            _activeMap = _maps.Length - 1;
        ActivateMap(_activeMap);
    }
}
