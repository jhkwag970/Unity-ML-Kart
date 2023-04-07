using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoint : MonoBehaviour
{
    [SerializeField] private List<Transform> kartTransformList;
    [SerializeField] private List<KartAgent> kartAgentList;
    [SerializeField] private List<KartController> kartControllerList;
    public List<CheckpointSingle> checkpointSingleList;
    private List<int> nextCheckpointSingleIndexList;

    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");

        checkpointSingleList = new List<CheckpointSingle>();
        foreach(Transform checkpointsSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointsSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetTrackCheckpoint(this);
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
            Debug.Log("Correct");
            kartAgentList[kartIdx].AddReward(1f);

            if (nextCheckpointSingleIndex == checkpointSingleList.Count - 1)
            {
                Debug.Log("Last Check point");
                kartAgentList[kartIdx].EndEpisode();


                kartControllerList[kartIdx].Respawn();
                resetCheckpoints();
            }

            nextCheckpointSingleIndexList[kartTransformList.IndexOf(kartTransform)] = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;


        }
        else
        {
            //wrong checkpoint
            Debug.Log("Wrong");
            kartAgentList[kartIdx].AddReward(-1f);
            kartAgentList[kartIdx].EndEpisode();


            kartControllerList[kartIdx].Respawn();
            resetCheckpoints();
            
        }
    }
}
