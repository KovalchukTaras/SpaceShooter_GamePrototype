using UnityEngine;

public class HangarController : MonoBehaviour
{
    public PlanePanel[] PlanePanels;

    public void Init()
    {
        ActivatePanels(ref PlanePanels);
    }

    private void ActivatePanels(ref PlanePanel[] panels)
    {
        foreach (var panel in panels)
            panel.Init();
    }
}
