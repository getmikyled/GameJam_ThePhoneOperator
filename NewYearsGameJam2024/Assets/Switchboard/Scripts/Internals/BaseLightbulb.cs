using UnityEngine;


namespace IvoryIcicles.SwitchboardInternals
{
	public enum LightbulbStatus { OFF = 0, BLINKING = 1, ON = 2 }
	public class BaseLightbulb : MonoBehaviour
	{
		private LightbulbStatus _status = LightbulbStatus.OFF;
		public virtual LightbulbStatus status
		{
			get => _status;
			set
			{
				if (_status == value) return;
				_status = value;
				onStatusChanged();
			}
		}


		protected virtual void onStatusChanged()
		{
			print($"{name} -> {_status}");
		}
	}
}