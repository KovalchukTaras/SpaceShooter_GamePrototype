using UnityEngine;

public class Shop : MonoBehaviour
{
    public BulletPanel[] Panels;

    public void Init(int[] count)
    {
        ActivatePanels();
        SetCount(count);
    }

    private void ActivatePanels()
    {
        foreach (var panel in Panels)
            panel.SetValues();
    }

    public void SetCount(int[] count)
    {
        for(int i = 0; i< Panels.Length; i++)
            Panels[i].SetCount(count[i]);
    }
}
