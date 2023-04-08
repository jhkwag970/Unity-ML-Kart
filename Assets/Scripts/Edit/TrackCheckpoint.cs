using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoint : MonoBehaviour
{
    [Header("Kart Parameters")]
    [SerializeField] private List<Transform> kartTransformList;
    [SerializeField] private List<KartAgent> kartAgentList;

    [Header("Checking Parameters")]
    public List<CheckpointSingle> checkpointSingleList;
    public List<Transform> checkpointSingleTransformList;
    private List<int> nextCheckpointSingleIndexList;

    [Header("Result Parameters")]
    [SerializeField] private Material finishMaterial;
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private MeshRenderer floor;

    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");

        checkpointSingleList = new List<CheckpointSingle>();
        foreach(Transform checkpointsSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointsSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetTrackCheckpoint(this);
            checkpointSingleTransformList.Add(checkpointsSingleTransform);
            checkpointSingleList.Add(checkpointSingle);
        }

        resetCheckpoints();
        
    }

    public void resetCheckpoints()
    {
        nextCheckpointSingleIndexList = new List<int>();
        foreach (Transform carTransform in kartTransformList)
        {
            nextCheckpointSingleIndexList.Add(0);
        }
    }

    public void KartThroughCheckpoint(CheckpointSingle checkpointSingle, Transform kartTransform)
    {
        int kartIdx = kartTransformList.IndexOf(kartTransform);
        int nextCheckpointSingleIndex = nextCheckpointSingleIndexList[kartIdx];
        
        if (checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex)
        {
            //correct checkpoint
           // Debug.Log("Correct");
            floor.material = winMaterial;
            kartAgentList[kartIdx].AddReward(1f);

            if (nextCheckpointSingleIndex == checkpointSingleList.Count - 1)
            {
                Debug.Log("Last Check point");
                floor.material = finishMaterial;
                kartAgentList[kartIdx].EndEpisode();
            }

            nextCheckpointSingleIndexList[kartIdx] = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;
            //nextCheckpointSingleIndexList[kartIdx]++;
        }
        else
        {
            //wrong checkpoint
            //Debug.Log("Wrong");
            floor.material = loseMaterial;
            kartAgentList[kartIdx].AddReward(-1f);
            //nextCheckpointSingleIndexList[kartIdx]--;
            //kartAgentList[kartIdx].EndEpisode();

        }
    }
}
