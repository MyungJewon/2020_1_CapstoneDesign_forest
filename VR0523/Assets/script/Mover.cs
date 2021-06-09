using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Rail rail;
    public PlayMode mode;

    public float speed = 2.5f;
    public bool isReversed;
    public bool isLooping;
    public bool pingpong;

    private int currentSeg;
    private float transition;
    private bool isCompleted;

    private void Update()
    {
        if (!rail)
            return;
        if (!isCompleted)
            Play(!isReversed);
    }
    private void Play(bool forward = true)
    {
        float m = (rail.nodes[currentSeg + 1].position - rail.nodes[currentSeg].position).magnitude;
        float s = (Time.deltaTime * 1 / m) * speed;
        transition += (forward) ? s : -s;
        if (transition > 1)
        {
            transition = 0;
            currentSeg++;
        }
        else if(transition < 0)
        {
            transition = 1;
            currentSeg--;
        }

        transform.position = rail.PositionOnRail(currentSeg, transition, mode);
        transform.rotation = rail.Orientation(currentSeg, transition);
    }
}
