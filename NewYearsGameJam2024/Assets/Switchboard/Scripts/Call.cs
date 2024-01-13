namespace IvoryIcicles
{
	public enum CallStatus
	{
		AWAITING_CONNECTION, AWAITING_CORRECT_RECEPTOR, ON_GOING, FINISHED
	}

	public class Call
	{
		public int emisorId { get; private set; }
		public int receptorId { get; private set; }

		public CallInfo callInfo { get; private set; }

		public int channelInID = -1;
		public int channelOutID = -1;

		public bool operatorIsConnected = false;
		
		public bool started = true;
		public bool operatorAnswered = false;

		public bool finished = false;
		
		public bool correctReceptorIsConnected => receptorId == channelOutID;
		public bool connected => channelOutID > -1;
		public CallStatus status
		{
			get
			{
				if (!started)
					return CallStatus.AWAITING_CONNECTION;
				if (finished)
					return CallStatus.FINISHED;
				if (correctReceptorIsConnected)
					return CallStatus.ON_GOING;
				return CallStatus.AWAITING_CORRECT_RECEPTOR;
			}
		}

		public Call(int emisorId, int receptorId, CallInfo callInfo)
		{
			this.emisorId = emisorId;
			this.receptorId = receptorId;
			this.callInfo = callInfo;
		}
	}
}