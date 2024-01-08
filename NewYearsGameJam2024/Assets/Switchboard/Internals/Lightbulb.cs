using UnityEngine;


namespace IvoryIcycles.SwitchboardInternals
{
	public enum LightbulbStatus { OFF = 0, BLINKING = 1, ON = 2 }
	public class Lightbulb : MonoBehaviour
	{
		private LightbulbStatus _status = LightbulbStatus.OFF;
		public LightbulbStatus status
		{
			get => _status;
			set
			{
				_status = value;
				print($"{name} -> {_status}");
			}
		}
	}
}