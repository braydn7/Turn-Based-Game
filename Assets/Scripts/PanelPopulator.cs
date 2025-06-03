using UnityEngine;

public class PanelPopulator : MonoBehaviour
{
    public List<Button> DisplayedButtons; // List of buttons to be populated in the panel

    // Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	// Method to populate the panel with buttons
    public void PopulatePanel(List<Button> buttonsToDisplay)
    {
        // Clear existing buttons
        foreach (Button button in DisplayedButtons)
        {
            Destroy(button.gameObject);
        }
        DisplayedButtons.Clear();
        // Add new buttons to the panel
        foreach (Button button in buttonsToDisplay)
        {
            Button newButton = Instantiate(button, transform); // Instantiate a new button as a child of this panel
            DisplayedButtons.Add(newButton);
        }
	}
}
