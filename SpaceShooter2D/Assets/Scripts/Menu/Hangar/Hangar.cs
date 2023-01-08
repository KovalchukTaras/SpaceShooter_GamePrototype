using UnityEngine;

public class Hangar : MonoBehaviour
{
    public Panel[] Panels;

    public void Init()
    {
        ActivatePanels();
    }

    private void ActivatePanels()
    {
        foreach (var panel in Panels)
            panel.SetValues();
    }
}
