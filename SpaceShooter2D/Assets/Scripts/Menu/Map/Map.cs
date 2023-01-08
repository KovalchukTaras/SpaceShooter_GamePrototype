using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] public MapLevel[] Levels;
    [SerializeField] private GameObject[] _maps;
    private int _activeMap;

    public void Init(int activeLevel)
    {
        ActivateLevels(activeLevel);
        ActivateMap(FindActiveMap(activeLevel));
    }

    private void ActivateLevels(int activeLevel)
    {
        for(int i = 0; i < Levels.Length; i++)
        {
            if (i > activeLevel) Levels[i].SetStage(0);
            else if(i == activeLevel) Levels[i].SetStage(1);
            else if(i < activeLevel) Levels[i].SetStage(2);
        }
    }

    private int FindActiveMap(int level)
    {
        return _activeMap = Mathf.CeilToInt(level / 10);
    }

    private void ActivateMap(int num)
    {
        for (int i = 0; i < _maps.Length; i++)
            if (i == num)
                _maps[i].gameObject.SetActive(true);
            else
                _maps[i].gameObject.SetActive(false);
    }

    public void ShowNextMap(bool next)
    {
        if (next) _activeMap++;
        else _activeMap--;

        if (_activeMap >= _maps.Length) _activeMap = 0;
        else if (_activeMap < 0) _activeMap = _maps.Length - 1;

        ActivateMap(_activeMap);
    }
}
