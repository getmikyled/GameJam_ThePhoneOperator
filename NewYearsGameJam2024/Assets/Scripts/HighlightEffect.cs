using UnityEngine;
using UnityEngine.EventSystems;


namespace IvoryIcicles
{
	public class HighlightEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField] private GameObject highlightEffect;

		public void Activate()
		{
			highlightEffect.SetActive(true);
		}

		public void Deactivate()
		{
			highlightEffect.SetActive(false);
		}

		public void OnPointerEnter(PointerEventData eventData)
			=> Activate();

		public void OnPointerExit(PointerEventData eventData)
			=> Deactivate();
	}
}