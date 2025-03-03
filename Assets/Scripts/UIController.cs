using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


namespace Inventory
{
	public class UIController : MonoBehaviour
	{
		#region Properties

		#endregion

		#region Fields
		[Header("Inventory Reffs")]
		[SerializeField] private InventorySystem _inventorySystem;
		[Header("Transform InventoryPanel")]
		[SerializeField] private Transform _inventoryPanel;
		[Header("Buttons Sell & Use")]
		[SerializeField] private Button _useButton;
		[SerializeField] private Button _sellButton;
		[Header("Prefab Reffs")]
		[SerializeField] private ItemButton _prefabButton;
		[Header("Item Seleced")]
		[SerializeField] private ItemButton _currentItemSelected;
		#endregion

		#region Unity Callbacks
		// Start is called before the first frame update
		void Start()
		{			
			_inventorySystem.OnItemAdded += AddItemToUI;

			_useButton.onClick.AddListener(UseCurrentItem);
			_sellButton.onClick.AddListener(SellCurrentItem);

			ButtonFalse();
		}
		
		#endregion

		#region Public Methods	
		
		public void SelectItem(ItemButton currentItem)
		{
			_currentItemSelected = currentItem;
			//If Sellable
			if (_currentItemSelected.CurrentItem is ISellable)
				_sellButton.gameObject.SetActive(true);

			//If Usable
			if (_currentItemSelected.CurrentItem is IUsable)
				_useButton.gameObject.SetActive(true);
		}
		#endregion

		#region Private Methods
		private void ButtonFalse()
		{
			_sellButton.gameObject.SetActive(false);
			_useButton.gameObject.SetActive(false);
		}
		private void AddItemToUI(ItemButton newButtonItem)
		{
			newButtonItem.transform.SetParent(_inventoryPanel);
			newButtonItem.OnClick += () => SelectItem(newButtonItem);
		}
		private void SellCurrentItem()
		{
			(_currentItemSelected.CurrentItem as ISellable).Sell();
			Consume(_currentItemSelected);
		}
		//Refactor
		private void UseCurrentItem()
		{
			(_currentItemSelected.CurrentItem as IUsable).Use();
			if (_currentItemSelected.CurrentItem is IConsumable)
				Consume(_currentItemSelected);
		}
		private void Consume(ItemButton currentItemSelected)
		{
			Destroy(_currentItemSelected.gameObject);
			_currentItemSelected = null;
			ButtonFalse();
		}
		#endregion
	}
}
