using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kart : MonoBehaviour
{
    [SerializeField] private KartAgent kartAgent;

    [Header("Result Parameters")]
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private MeshRenderer floor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Wall>(out Wall wall))
        {
            Debug.Log("Wall");
            floor.material = loseMaterial;
            kartAgent.AddReward(-0.5f);
            kartAgent.EndEpisode();
            
        }
    }
}
