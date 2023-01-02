using UnityEngine;
using UnityEngine.UI;

public class MultiButtonChild : MonoBehaviour
{
    public string ButtonTag;
    [SerializeField] private bool _readyToSelect;
    [Space]
    [SerializeField] private Color _isSelectedColor;
    [SerializeField] private Color _isNotActiveColor;
    private Color _defaultColor;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _defaultColor = _image.color;
    }

    public void IsSelected(bool isSelected)
    {
        if (_readyToSelect)
        {
            if (isSelected) _image.color = _isSelectedColor;
            else _image.color = _defaultColor;
        }
        else _image.color = _isNotActiveColor;
    }
}
