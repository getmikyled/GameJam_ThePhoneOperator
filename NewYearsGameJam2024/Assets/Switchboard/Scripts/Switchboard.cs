using IvoryIcicles.SwitchboardInternals;
using UnityEngine;


// https://en.wikipedia.org/wiki/Telephone_switchboard
// https://en.wikipedia.org/wiki/Switchboard_operator

namespace IvoryIcicles
{
    public class Switchboard : MonoBehaviour
    {
        public ConnectionButton[] reqButtons;

        public void PublishConnectionRequest(int buttonId)
        {
            reqButtons[buttonId].PublishRequest();
        }

        public void AnswerRequest(int buttonId)
        {
            print($"Answered {buttonId}");
        }
    }
}
