using UnityEngine;


namespace IvoryIcicles.SwitchboardInternals
{
	public class TestingLightbulb : BaseLightbulb
	{
		[SerializeField] private Material onMaterial;
		[SerializeField] private Material offMaterial;

		private MeshRenderer m_renderer;


		protected override void onStatusChanged()
		{
			if (status == LightbulbStatus.OFF)
				m_renderer.sharedMaterial = offMaterial;
			else
				if (status == LightbulbStatus.ON)
				m_renderer.sharedMaterial = onMaterial;
		}


		private void Start()
		{
			m_renderer = GetComponent<MeshRenderer>();
			m_renderer.sharedMaterial = offMaterial;
		}

		private float m_blinkTimeElapsed = 0f;
		private void Update()
		{
			if (status == LightbulbStatus.BLINKING)
			{
				m_blinkTimeElapsed += Time.deltaTime;
				if (m_blinkTimeElapsed > 1f)
				{
					m_blinkTimeElapsed = 0f;
					if (m_renderer.sharedMaterial == onMaterial)
						m_renderer.sharedMaterial = offMaterial;
					else
						m_renderer.sharedMaterial = onMaterial;
				}
			}
		}
	}
}