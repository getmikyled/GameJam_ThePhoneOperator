using IvoryIcicles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    [SerializeField] Transform wireStart;
    [SerializeField] Transform wireEnd;
    [SerializeField] Transform wire;

    [SerializeField] float scale;

    private void Update()
    {
        wireStart.LookAt(wireEnd);
        wireEnd.LookAt(wireStart);

        float distance = Vector3.Distance(wireStart.position, wireEnd.position);
        wire.position = wireStart.position + distance / 2 * wireStart.forward;
        wire.rotation = wireStart.rotation;
        wire.localScale = new Vector3(wire.localScale.x, wire.localScale.y, distance * scale);
    }


}
