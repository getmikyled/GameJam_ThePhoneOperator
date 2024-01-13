using UnityEngine;
using UnityEngine.EventSystems;


namespace IvoryIcicles.SwitchboardInternals
{
	public class BoardButton : SwitchboardComponentWithLightbulb, IPointerClickHandler
	{
		[SerializeField] private AudioClip buttonClickSound;
		[Range(0f, 1f)][SerializeField] private float soundVolume = 1f;

		AudioManager audioManager;

        private void Start()
        {
			audioManager = AudioManager.manager;
        }

        protected override LightbulbStatus nextLightbulbStatus
		{
			get
			{
				if (activeCall == null || activeCall.status == CallStatus.IDLE || activeCall.status == CallStatus.FINISHED)
					return LightbulbStatus.OFF;
				if (activeCall.operatorIsConnected)
					return LightbulbStatus.ON;
				else
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
			switchboard.SetOperatorConnection(activeCall, connect: true);
			switchboard.AnswerCall(activeCall);
			UpdateLightbulbStatus();
		}
	}
}