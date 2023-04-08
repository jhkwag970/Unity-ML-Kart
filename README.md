# Unity-ML-Kart
Unity for ML Kart Simulation

<h3> Test Case V.1 </h3> April 7th 2023

At first, I set the previous check point with negative reward and next check point with positive reward. Then, whenever the agent hits the previous check point, I ended th episode so that the agent can start over.

However, this method cause the agent to slow in getting to next checkpoint because of respawn due to previous check point.
Thus, I tried deleted the endEpisode for the previous check point and it seems to be work fine.

The agent can go back to the preivous checkpoint for the turning the wheel around. But, it starts to learn the previous check point deduct the reward. Therefore, it avoids to pass through the previous check point and process to next check point.

Right now, I am testing with the previous check point without deducting the reward. So, only wall reduces the reward and end episode and next check point increases the reward. 

In this case, I am worrying about the agnet will learn to move back too much becuase there is no harm for getting back to previous check point. I will update the result as soon as the testing is done. 

<h3> Test Case V.1</h3> April 7th 2023

![Honeycam 2023-04-07 01-49-19](https://user-images.githubusercontent.com/54969114/230549875-a55844c3-2851-46ab-bf6e-e4fb4356dad8.gif)

![testCase](https://user-images.githubusercontent.com/54969114/230549666-18cc5548-270e-49c8-bb77-d92d0b81acb8.png)

With the Step 1,284,000, ML ables to learn how to get to the final check point (wiht Mean Reward 1.93 and Std of 0.437)

The lowest Std for whole test case was 0.063 and highest mean was 1.991 which were good results.

![Honeycam 2023-04-07 01-48-05](https://user-images.githubusercontent.com/54969114/230549850-3a946a56-881d-4f31-85d1-839e06d359c5.gif)
