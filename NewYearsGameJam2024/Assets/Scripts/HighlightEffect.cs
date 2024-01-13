using UnityEngine;
using UnityEngine.EventSystems;


namespace IvoryIcicles
{
	public class HighlightEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField] private GameObject highlightEffect;
		[SerializeField] private bool usePointerEvents = true;

		public void Activate()
		{
			highlightEffect.SetActive(true);
		}

		public void Deactivate()
		{
			highlightEffect.SetActive(false);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (usePointerEvents) 
				Activate();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (usePointerEvents)
				Deactivate();
		}
	}
}