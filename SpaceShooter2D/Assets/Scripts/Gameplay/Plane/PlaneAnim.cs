using UnityEngine;

public class PlaneAnim : MonoBehaviour
{
    [SerializeField] private Plane _plane;

    public void Destroy() => _plane.gameObject.SetActive(false);

    public void ExitAnimation(string variableName) => GetComponent<Animator>().SetBool(variableName, false);
}
