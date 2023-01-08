using UnityEngine;
using UnityEngine.UI;

public class Ammunition : MonoBehaviour
{
    [SerializeField] private GameObject[] _ammunitionObjects;
    [SerializeField] private Text[] _ammunitionObjectTexts;

    public void SetValues(int[] count)
    {
        for (int i = 0; i < _ammunitionObjects.Length; i++)
        {
            if
                (count[i] < 1) _ammunitionObjects[i].SetActive(false);
            else
            {
                _ammunitionObjects[i].SetActive(true);
                _ammunitionObjectTexts[i].text = $"x{count[i]}";
            }
        }
    }
}
