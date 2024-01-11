namespace IvoryIcicles
{
	public enum CallStatus
	{
		IDLE, AWAITING_OPERATOR, AWAITING_RECEPTOR, ON_GOING, FINISHED
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
					return CallStatus.IDLE;
				if (!operatorAnswered)
					return CallStatus.AWAITING_OPERATOR;
				if (!correctReceptorIsConnected)
					return CallStatus.AWAITING_RECEPTOR;
				if (!finished)
					return CallStatus.ON_GOING;
				else
					return CallStatus.FINISHED;
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