using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownButton : MonoBehaviour
{
    public GameObject[] panelsToToggle;
    [System.Serializable]
    public class DropdownItem
    {
        public GameObject objectToToggle;
        //public GameObject[] panelsToToggle;
        public GameObject[] buttonsToToggle;
    }

    public DropdownItem[] dropdownItems;
    public TMP_Dropdown dropdown;

    private void Start()
    {
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);

        // Desactivar todos los objetos y botones al inicio
        ToggleAllObjects(false);
        ToggleAllButtons(false);
    }

    private void OnDropdownValueChanged(int index)
    {
        // Desactivar todos los objetos y botones
        ToggleAllObjects(false);
        ToggleAllButtons(false);

        
        // Activar el objeto y los botones correspondientes al índice del dropdown
        if (index >= 0 && index < dropdownItems.Length)
        {
            DropdownItem selectedItem = dropdownItems[index];
            selectedItem.objectToToggle.SetActive(true);
            foreach (GameObject button in selectedItem.buttonsToToggle)
            {
                button.SetActive(true);
            }
        }
    }

    private void ToggleAllObjects(bool active)
    {
        // Desactivar todos los objetos
        foreach (DropdownItem item in dropdownItems)
        {
            item.objectToToggle.SetActive(active);
        }
        foreach (GameObject panel in panelsToToggle)
        {
            panel.SetActive(active);
        }
    }

    private void ToggleAllButtons(bool active)
    {
        // Desactivar todos los botones
        foreach (DropdownItem item in dropdownItems)
        {
            foreach (GameObject button in item.buttonsToToggle)
            {
                button.SetActive(active);
            }
        }
    }
}