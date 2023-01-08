using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/BulletData", order = 2)]
public class BulletData : ScriptableObject
{
    [System.Serializable]
    public class BulletInfo
    {
        public string Name;
        public float Damage;
        public float Price;
    }
    public List<BulletInfo> Bullets;
}
