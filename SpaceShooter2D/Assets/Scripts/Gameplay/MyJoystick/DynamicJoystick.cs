using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{ 
    [SerializeField] private Joystick _joystick;

    public void OnPointerDown(PointerEventData eventData) => _joystick.transform.position = eventData.position;

    public void OnPointerUp(PointerEventData eventData) => _joystick.OnPointerUp(eventData);

    public void OnDrag(PointerEventData eventData) => _joystick.OnDrag(eventData);
}
