using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoomMenuManager : MonoBehaviour
{
    [System.Serializable]
    public class StoryPanel
    {
        public string storyName;
        public int sceneIndex;
        public Button selectButton;
        public GameObject highlightEffect;
    }

    [Header("Story Panels in the Room")]
    public List<StoryPanel> storyPanels = new List<StoryPanel>();

    public SceneTransitionManager sceneTransitionManager;

    void Start()
    {
        foreach (var panel in storyPanels)
        {
            int index = panel.sceneIndex;

            if (panel.selectButton != null)
                panel.selectButton.onClick.AddListener(() => SelectStory(index));

            if (panel.highlightEffect != null)
                panel.highlightEffect.SetActive(false);
        }

        // Place room story panels near shelf_B_large_decorated around (-10.91, 4.01, 2.84).
        // Use TrackedDeviceGraphicRaycaster on world-space story Canvases for VR ray interaction.
    }

    public void SelectStory(int sceneIndex)
    {
        if (sceneTransitionManager != null)
            sceneTransitionManager.GoToSceneAsync(sceneIndex);
    }

    public void OnPanelHoverEnter(int panelIndex)
    {
        if (panelIndex >= 0 && panelIndex < storyPanels.Count && storyPanels[panelIndex].highlightEffect != null)
            storyPanels[panelIndex].highlightEffect.SetActive(true);
    }

    public void OnPanelHoverExit(int panelIndex)
    {
        if (panelIndex >= 0 && panelIndex < storyPanels.Count && storyPanels[panelIndex].highlightEffect != null)
            storyPanels[panelIndex].highlightEffect.SetActive(false);
    }
}
