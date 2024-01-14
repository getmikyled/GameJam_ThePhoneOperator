using UnityEngine;


namespace IvoryIcicles.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject dialogUI;

        public void StartGame()
        {
            animator.SetTrigger("New Game");
            gameObject.SetActive(false);
            dialogUI.SetActive(true);
        }

        public void Quit()
        {
			Application.Quit();
		}
    }
}