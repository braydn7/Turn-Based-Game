using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager: MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPrefab; // Prefab for the buttons to be instantiated
    [SerializeField]
	private List<Button> DisplayedButtons; // List of buttons to be populated in the panel
    [SerializeField] 
    private GridLayoutGroup layoutGroup;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        layoutGroup = GetComponent<GridLayoutGroup>();
        if (layoutGroup == null)
        {
            Debug.LogError("HorizontalLayoutGroup component is missing from the PanelManager GameObject.");
		}

        AddMovementButtons();
	}


    private void addButton(string label, System.Action onClick)
    {
        GameObject newButtonObj = Instantiate(buttonPrefab, transform);
        
        Button newButton = newButtonObj.GetComponent<Button>();

        newButton.GetComponentInChildren<TextMeshProUGUI>().SetText(label);

		newButton.onClick.AddListener(() => onClick.Invoke()); // Add the click listener

        DisplayedButtons.Add(newButton); // Add the button to the list of displayed buttons
	}

    private void clearButtons()
    {
        foreach (Button button in DisplayedButtons)
        {
            Destroy(button.gameObject); // Destroy each button GameObject
        }
        DisplayedButtons.Clear(); // Clear the list of displayed buttons
	}

    public void AddMovementButtons()
    {
        clearButtons(); // Clear existing buttons before adding new ones
        addButton("Up", () => Debug.Log("Up button clicked"));
        addButton("Down", () => Debug.Log("Down button clicked"));
        addButton("Left", () => Debug.Log("Left button clicked"));
        addButton("Right", () => Debug.Log("Right button clicked"));
        addButton("Back", () => Debug.Log("Back button clicked")); 
	}
}
