using UnityEngine;

public class Explosion : MonoBehaviour
{
    public void Destroy() => gameObject.SetActive(false);
}
