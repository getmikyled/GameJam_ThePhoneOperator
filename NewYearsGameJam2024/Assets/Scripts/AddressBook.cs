using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class AddressBook : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] AddressBookUI addressBookUI;
    public void OnPointerClick(PointerEventData eventData)
    {
        addressBookUI.Open();
    }
}
