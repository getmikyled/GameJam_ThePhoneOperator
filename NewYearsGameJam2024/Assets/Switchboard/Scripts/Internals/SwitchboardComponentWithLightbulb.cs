using UnityEngine;


namespace IvoryIcicles.SwitchboardInternals
{
	public class SwitchboardComponentWithLightbulb : SwitchboardComponent
	{
		[SerializeField] private BaseLightbulb lightbulb;

		protected virtual LightbulbStatus nextLightbulbStatus
			=> LightbulbStatus.ON;


		public override void ConnectCall(Call call)
		{
			base.ConnectCall(call);
			UpdateLightbulbStatus();
		}

		public override void DisconnectCall()
		{
			base.DisconnectCall();
			UpdateLightbulbStatus();
		}


		public virtual void UpdateLightbulbStatus()
		{
			lightbulb.status = nextLightbulbStatus;
		}
	}
}