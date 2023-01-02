using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    [System.Serializable]
    public class Plane
    {
        public string Name;
        public float Experience;
        public float Health;
        public float ShootingSpeed;
        public float RechargeSpeed;
    }
    public List<Plane> Planes;
}
