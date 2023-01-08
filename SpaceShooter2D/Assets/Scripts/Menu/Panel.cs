using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Panel : MonoBehaviour, IMenuPanel
{
    [SerializeField] public int Id;
    [SerializeField] protected Text _nameText;
    [SerializeField] protected Text _priceText;

    public Action<int> OnSelected { get; set; }

    public abstract void SetValues();

    public void Select() => OnSelected.Invoke(Id);
}
