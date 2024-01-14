using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AddressBookUI : MonoBehaviour
{

    [SerializeField] GameObject addressBook;

    public void Open()
    {
        PlayOpenAnimation();
    }

    public void Close()
    {
        PlayCloseAnimation();
    }

    private void PlayOpenAnimation()
    {
        addressBook.GetComponent<RectTransform>().DOAnchorPosY(29, 1);
    }

    private void PlayCloseAnimation() {
        addressBook.GetComponent<RectTransform>().DOAnchorPosY(415, 1);
    }
}
