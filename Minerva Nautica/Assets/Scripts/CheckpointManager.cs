using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CheckpointManager : MonoBehaviour
{
    public TimerController timerControllerScript;
    public GameObject[] checkpoints;
    public TextMeshProUGUI checkpointText;

    public bool raceFinished = false;

    private int checkpointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Finding TimerController script:
        timerControllerScript = GameObject.Find("GameManager").GetComponent<TimerController>();
        // Setting text:
        checkpointText.text = "Checkpoint:\n" + checkpointIndex + " / " + checkpoints.Length;

        // Setting all checkpoints to inactive.
        for (int index = 1; index < checkpoints.Length; index++)
        {
            checkpoints[index].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (checkpointIndex == checkpoints.Length)
        {
            timerControllerScript.EndTimer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            // Making the next checkpoint appear:
            checkpoints[checkpointIndex].SetActive(false);

            if (checkpointIndex < checkpoints.Length - 1)
            {
                checkpoints[checkpointIndex + 1].SetActive(true);
            }
            checkpointIndex++;

            // Updating the text:
            checkpointText.text = "Checkpoint:\n" + checkpointIndex + " / " + checkpoints.Length;
        }
    }
}
