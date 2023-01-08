using System;
using UnityEngine;

public class MapLevel : MonoBehaviour, IMenuPanel
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private GameObject[] _stages;

    public Action<int> OnSelected { get; set; }

    public void SetStage(int stage)
    {
        _stages[stage].SetActive(true);

        for(int i = 0; i < _stages.Length; i++)
            if(i != stage)
                _stages[i].SetActive(false);
    }

    public void Select() => OnSelected(_levelNumber);
}
