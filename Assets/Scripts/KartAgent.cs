using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class KartAgent : Agent
{
   //public CheckpointManager _checkpointManager;
   private KartController _kartController;
   
   //called once at the start
   public override void Initialize()
   {
      _kartController = GetComponent<KartController>();
   }
   
   //Called each time it has timed-out or has reached the goal
   public override void OnEpisodeBegin()
   {
      //_checkpointManager.ResetCheckpoints();
      //_kartController.Respawn();
   }

    public override void CollectObservations(VectorSensor sensor)
    {
        //Vector btw kart and next check point
        //Vector3 diff = _checkpointManager.nextCheckPointToReach.transform.position - transform.position;

        //sensor.AddObservation(diff / 20f);

        //AddReward(-0.001f);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        var input = actions.ContinuousActions;

        _kartController.ApplyAcceleration(input[1]);
        _kartController.Steer(input[0]);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var action = actionsOut.ContinuousActions;

        action[0] = Input.GetAxis("Horizontal"); //sterring

        action[1] = Input.GetKey(KeyCode.W) ? 1f : 0f; //accelation

    }
}
