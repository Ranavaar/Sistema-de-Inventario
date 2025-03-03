using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControllerInventory : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[SerializeField] private Slider _slider;
	[SerializeField] private TextMeshProUGUI _pointsText;
	[SerializeField] private TextMeshProUGUI _levelText;
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	#endregion

	#region Public Methods
	public void UpdateSliderLife(float currentLife)
	{
		_slider.value = currentLife;
	}
	public void UpdatePoints(int currentPoints)
	{
		_pointsText.text = currentPoints.ToString();
	}public void UpdateLevel(int currentLevel)
	{
		_levelText.text = currentLevel.ToString();
	}
	#endregion

	#region Private Methods
	#endregion
}
