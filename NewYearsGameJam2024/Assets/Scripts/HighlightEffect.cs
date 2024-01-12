using UnityEngine;
using UnityEngine.EventSystems;


namespace IvoryIcicles
{
	public class HighlightEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField] private GameObject highlightEffect;

		public void OnPointerEnter(PointerEventData eventData)
			=> highlightEffect.SetActive(true);

		public void OnPointerExit(PointerEventData eventData)
			=> highlightEffect.SetActive(false);
	}
}