using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _value;
    private const float _destroyPosX = -30;

    private void FixedUpdate()
    {
        transform.position += Vector3.left * _moveSpeed;
        if (transform.position.x < _destroyPosX)
            Death();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.Instance.AddCoins(_value);
            Death();
        }
    }

    private void Death() => gameObject.SetActive(false);

}
