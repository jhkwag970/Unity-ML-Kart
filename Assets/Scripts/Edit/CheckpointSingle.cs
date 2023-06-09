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
            trackCheckpoints.KartThroughCheckpoint(this, other.transform.parent);
        }
    }

    public void SetTrackCheckpoint(TrackCheckpoint trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints;
    }
}
