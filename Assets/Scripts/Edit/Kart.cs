using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kart : MonoBehaviour
{
    [SerializeField] private KartAgent kartAgent;
    [SerializeField] private KartController kartController;
    public TrackCheckpoint trackCheckpoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Wall>(out Wall wall))
        {
            Debug.Log("Wall");
            kartAgent.AddReward(-1f);
            kartAgent.EndEpisode();


            kartController.Respawn();
            trackCheckpoint.resetCheckpoints();
            
        }
    }
}
