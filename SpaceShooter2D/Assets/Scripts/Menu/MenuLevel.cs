using System;
using UnityEngine;

public class MenuLevel : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private GameObject[] _stages;

    public Action<int> OnSelected;

    public void CheckActive(int activeLevel)
    {
        if (_levelNumber > activeLevel)
            _stages[0].SetActive(true);
        else if (_levelNumber == activeLevel)
            _stages[1].SetActive(true);
        else if (_levelNumber < activeLevel)
            _stages[2].SetActive(true);
    }

    public void Select()
    {
        OnSelected(_levelNumber);
    }
}
