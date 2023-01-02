using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MultiButton : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private MultiButtonChild[] _childButtons;
    [SerializeField] private float _selectDistanceMin;
    [SerializeField] private float _selectDistanceMax;
    public Action<string> OnSelected; 

    public void OnDrag(PointerEventData eventData)
    {
        if (IsReadyToSelectChild(eventData.position))
        {
            int btnIndex = SelectedChildButton(eventData.position);
            _childButtons[btnIndex].IsSelected(true);

            for (int i = 0; i < _childButtons.Length; i++)
                if (i != btnIndex)
                    _childButtons[i].IsSelected(false);
        }
        else
            foreach (var btn in _childButtons)
                btn.IsSelected(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _menu.SetActive(true);
        foreach (var btn in _childButtons)
            btn.IsSelected(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (IsReadyToSelectChild(eventData.position))
        {
            int btnIndex = SelectedChildButton(eventData.position);
            SelectButton(_childButtons[btnIndex].ButtonTag);
        }
        _menu.SetActive(false);
    }


    private int SelectedChildButton(Vector3 pointerPos)
    {
        int buttonIndex = 0;
        float distance = _selectDistanceMax;
        for(int i = 0;i< _childButtons.Length; i++)
        {
            float btnDistance = Vector2.Distance(pointerPos, _childButtons[i].transform.position);
            if(btnDistance < distance)
            {
                distance = btnDistance;
                buttonIndex = i;
            }
        }
        return buttonIndex;
    }

    public bool IsReadyToSelectChild(Vector2 poinerPos)
    {
        float distance = Vector2.Distance(transform.position, poinerPos);
        if (distance > _selectDistanceMin && distance < _selectDistanceMax)
            return true;
        return false;
    }

    private void SelectButton(string tag) => OnSelected.Invoke(tag);
}
