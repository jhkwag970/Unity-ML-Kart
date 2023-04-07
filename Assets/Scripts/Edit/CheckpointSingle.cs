using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour
{
    private TrackCheckpoint trackCheckpoints;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Kart>(out Kart kart))
        {
            //Debug.Log(other.transform.name);
            trackCheckpoints.KartThroughCheckpoint(this, other.transform);
        }
    }

    public void SetTrackCheckpoint(TrackCheckpoint trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints;
    }
}
