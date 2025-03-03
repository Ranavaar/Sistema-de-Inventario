using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

namespace Inventory
{
	public class InventorySystem : MonoBehaviour
	{
		#region Properties
		public event Action<ItemButton> OnItemAdded;
		public static event Action<ItemButton> OnItemSelected;

		public event Action OnButtonFalse;
		#endregion

		#region Fields
		
		[Header("UI Reffs")]
		[SerializeField] private UIController _ui;
		[SerializeField] private ItemButton _prefabButton;

		[Header("Object Definition")]
		[SerializeField] private Weapon[] _weapons;
		[SerializeField] private Food[] _foods;
		[SerializeField] private Other[] _others;
		[Header("Item Pool")]
		[SerializeField] private List<Item> _items = new List<Item>();
		[Header("Item Seleced")]
		[SerializeField] private ItemButton _currentItemSelected;
		#endregion

		#region Unity Callbacks
		// Start is called before the first frame update
		void Start()
		{
			InitializeItems();
			InitializeUI();		
			
		}
		
		#endregion

		#region Public Methods
		public void AddItem(ItemButton buttonItemToAdd)
		{
			ItemButton newButtonItem = Instantiate(buttonItemToAdd);
			newButtonItem.CurrentItem = buttonItemToAdd.CurrentItem;
			OnItemAdded?.Invoke(newButtonItem);
		}

		
		#endregion

		#region Private Methods
		private void InitializeItems()
		{
			//Weapons
			for (int i = 0; i < _weapons.Length; i++)
				_items.Add(_weapons[i]);

			//Food
			for (int i = 0; i < _foods.Length; i++)
				_items.Add(_foods[i]);

			//Other
			for (int i = 0; i < _others.Length; i++)
				_items.Add(_others[i]);
		}
		private void InitializeUI()
		{
			for (int i = 0; i < _items.Count; i++)
			{
				ItemButton newButton = Instantiate(_prefabButton, _prefabButton.transform.parent);
				newButton.CurrentItem = _items[i];
				newButton.OnClick += () => AddItem(newButton);
			}
			_prefabButton.gameObject.SetActive(false);
		}
		

		#endregion
	}
}
