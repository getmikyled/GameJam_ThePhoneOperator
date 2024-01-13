using UnityEngine;
using UnityEngine.EventSystems;


namespace IvoryIcicles.SwitchboardInternals
{
	public class BoardButton : SwitchboardComponentWithLightbulb, IPointerClickHandler
	{
		[SerializeField] private AudioClip buttonClickSound;
		[Range(0f, 1f)][SerializeField] private float soundVolume = 1f;
		[SerializeField] private TMPro.TextMeshProUGUI text;

		AudioManager audioManager;


		protected override LightbulbStatus nextLightbulbStatus
		{
			get
			{
				if (activeCall == null || activeCall.status == CallStatus.FINISHED)
					return LightbulbStatus.OFF;
				if (activeCall.operatorIsConnected)
					return LightbulbStatus.ON;
				return LightbulbStatus.BLINKING;
			}
		}


		public void OnPointerClick(PointerEventData eventData)
		{
			if (buttonClickSound != null)
				audioManager.PlayAudio(buttonClickSound, transform, soundVolume);
            
            if (activeCall == null)
			{
				Debug.LogWarning("Channel doesn't have a call connected.");
				return;
			}

			switchboard.SetOperatorConnection(activeCall, connect: !activeCall.operatorIsConnected);
			if (activeCall.status == CallStatus.AWAITING_CORRECT_RECEPTOR)
				switchboard.AnswerCall(activeCall);

			UpdateLightbulbStatus();
		}


		private void Start()
		{
			audioManager = AudioManager.manager;
			text.text = channelID.ToString();
		}
	}
}