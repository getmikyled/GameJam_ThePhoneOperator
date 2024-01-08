using IvoryIcycles.SwitchboardInternals;
using UnityEngine;


// https://en.wikipedia.org/wiki/Telephone_switchboard
// https://en.wikipedia.org/wiki/Switchboard_operator

namespace IvoryIcycles
{
    public class Switchboard : MonoBehaviour
    {
        public ConnectionButton[] reqButtons;

        public void PublishConnectionRequest(int button)
        {
            reqButtons[button].PublishRequest();
        }

        /*public void RequestAnswered(ConnectionButton cb)
        {

        }*/
    }
}
