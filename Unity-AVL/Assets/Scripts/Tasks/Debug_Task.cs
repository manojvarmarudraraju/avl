using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Task : TaskInterface
{
    public void Execute(DeviceRegistry devices) {

        Debug.Log($"{devices.gps[0]} -> {devices.gps[1]} -> {devices.compass[0]}");
        if (Input.GetKey("w")) {
            // STUDENTS
            // Put your control code here
            devices.speedControl[0] = 1f;
            devices.speedControl[1] = 1f;
        }

        if (Input.GetKey("s")) {
            devices.speedControl[0] = 1f;
            devices.speedControl[1] = 1f;
        }

        if (Input.GetKey("x")) {
            devices.speedControl[0] = 1f;
            devices.speedControl[1] = 0f;
        }

        if (Input.GetKey("a") || Input.GetKey("d")) {
            devices.steeringControl[0] = 1f;

            if (Input.GetKey("a")) {
                devices.steeringControl[1] = -1;
            } else {
                devices.steeringControl[1] = 1;
            }
        } else {
            devices.steeringControl[0] = 1f;
            devices.steeringControl[1] = 0f;
        }

        if (Input.GetKey("space")) {
            devices.brakeControl[0] = 1f;
            devices.brakeControl[1] = 1f;
            devices.speedControl[0] = 1f;
            devices.speedControl[1] = 0f;
        }
    }
}