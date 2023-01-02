using UnityEngine.EventSystems;
using UnityEngine;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private bool _axisX;
    [SerializeField] private bool _axisY;
    [SerializeField] private float _radius;
    [SerializeField] private bool _canFollow;
    [Space]
    [SerializeField] private RectTransform _handle;
    [HideInInspector] public Vector2 Value;

    private Vector2 _initialPos;
    private RectTransform _rectTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _initialPos = _rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pointerPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out pointerPos);

        Vector2 direction = pointerPos - Vector2.zero;

        if (!_axisX) direction.x = 0f;
        if (!_axisY) direction.y = 0f;

        if (direction.sqrMagnitude > _radius * _radius)
        {
            Vector2 directionNormalized = direction.normalized * _radius;
            if (_canFollow)
                _rectTransform.localPosition += (Vector3)(direction - directionNormalized);

            direction = directionNormalized;
        }
        _handle.localPosition = direction;

        Value = _handle.localPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _handle.localPosition = Vector2.zero;
        _rectTransform.anchoredPosition = _initialPos;
        Value = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData) { }
}