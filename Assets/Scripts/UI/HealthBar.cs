using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
	public Player player;
	public void UpdateSlider()
	{
		float healthPercent;
		healthPercent = player.currentHP / player.MaxHP;
		Slider slider = GetComponent<Slider>();
		slider.value = healthPercent;
		slider.GetComponentInChildren<TextMeshProUGUI>().text = $"{player.currentHP} / {player.MaxHP}";
	}


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
