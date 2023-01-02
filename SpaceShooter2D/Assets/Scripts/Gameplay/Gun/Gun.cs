using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    public virtual void Shoot(string bullet, string tag)
    {
        ObjectPooler.Instance.SpawnFromPool(bullet, tag, transform.position, transform.rotation);
    }
}
