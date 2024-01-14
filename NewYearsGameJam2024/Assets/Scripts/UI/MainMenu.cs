using UnityEngine;


namespace IvoryIcicles.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void StartGame()
        {
            animator.SetTrigger("New Game");
            gameObject.SetActive(false);
        }

        public void Quit()
        {
			Application.Quit();
		}
    }
}