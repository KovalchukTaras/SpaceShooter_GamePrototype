using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _sprites;
    [SerializeField] private float _moveSpeed;

    private float _distance;
    private float _length;
    private Vector3 _startPos;

    private void Start()
    {
        _startPos = transform.position;
        _length = _sprites[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.right * _moveSpeed * Time.deltaTime;

        _distance = Vector3.Distance(_sprites[0].transform.position, _startPos);
        if(_distance > _length)
        {
            Vector3 newPos = new Vector3(_sprites[1].transform.position.x + _length, _sprites[1].transform.position.y, 0);
            _sprites[0].transform.position = newPos;
            _sprites.Add(_sprites[0]);
            _sprites.RemoveAt(0);
        }
    }
}
