using UnityEngine;


namespace IvoryIcicles.SwitchboardInternals
{
	public class CableDockingHelper : MonoBehaviour
	{
		[SerializeField] private Transform dockingTransform;
		[SerializeField] private HighlightEffect highlightEffect;

		private BoardSocket socket;

		public void DockCable(BoardCable cable)
		{

		}

		public void UndockCable(BoardCable cable)
		{

		}


		private void Start()
		{
			socket = GetComponent<BoardSocket>();
		}

		private void OnTriggerEnter(Collider other)
		{
			highlightEffect.Activate();
		}

		private void OnTriggerExit(Collider other)
		{
			highlightEffect.Deactivate();
		}
	}
}