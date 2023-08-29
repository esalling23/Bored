using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Sets up and controls the actions panel including sub-panels
/// </summary>
public class ActionsController : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private SubActionPanel[] subPanels;

    private SubActionPanel _openSubPanel;

    public ENTERTAINMENT debugEntertainment;

    public void OnClickFeed()
    {
        CreatureManager.Instance.Feed();
    }

    public void OnClickDrink()
    {
        CreatureManager.Instance.Drink();
    }

    public void OnClickPlay()
    {
        CreatureManager.Instance.Entertain(debugEntertainment);
    }

    public void OpenPanel(ACTION action)
    {
        SubActionPanel panelToOpen = subPanels.FirstOrDefault(
            (SubActionPanel panel) => panel.action == action
        );

        mainPanel.SetActive(false);
        panelToOpen.Open();
        _openSubPanel = panelToOpen;
    }

    public void ClosePanel()
    {
        mainPanel.SetActive(true);

        if (_openSubPanel == null) return;

        _openSubPanel.Close();

    }
}
