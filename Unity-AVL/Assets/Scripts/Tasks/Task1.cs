using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1 : TaskInterface
{

    float current;
    public Task1(){
        current = 0;
    }
    
    public void Execute(DeviceRegistry devices) {
        Debug.Log($"Initial: {devices.microphone[0]}");
        if(devices.memory[0] == 0f && devices.gps[1] > 27){
            current = 180;
            devices.memory[0] = 2f;
        } else if(devices.memory[0] == 0f && devices.gps[1] < 26){
            current = 0;
            devices.memory[0] = 2f;
        }

        if(devices.memory[1] < 4f && devices.compass[0] >= (current+0.25) || devices.compass[0] <= (current-0.25)){
            devices.speedControl[0] = 1f;
            devices.speedControl[1] = 0f;
            devices.brakeControl[0] = 1f;
            devices.brakeControl[1] = 2f;
            devices.steeringControl[0] = 1f;
            devices.steeringControl[1] = -0.25f;
        } else if(devices.memory[0] != 3f) {
            Debug.Log($"Initial done {current}");
            if(devices.gps[1] <= 27 && devices.gps[1] >= 26){
                Debug.Log($"current done");
                current = 90;
                devices.speedControl[0] = 1f;
                devices.speedControl[1] = 0f;
                devices.brakeControl[0] = 1f;
                devices.brakeControl[1] = 2f;
                devices.memory[0] = 3f;    
            } else {
                devices.speedControl[0] = 1f;
                devices.speedControl[1] = 1f;
                devices.brakeControl[0] = 1f;
                devices.brakeControl[1] = 0f;
            }
        } else if(devices.gps[0] <= 15.5) {
            Debug.Log($"{devices.lidar[4]} -> {devices.lidar[5]}");
            devices.speedControl[0] = 1f;
            devices.speedControl[1] = 1f;
            devices.brakeControl[0] = 1f;
            devices.brakeControl[1] = 0f;
        } else {
            devices.memory[0] = 4f;
            devices.speedControl[0] = 1f;
            devices.speedControl[1] = 0f;
            devices.brakeControl[0] = 1f;
            devices.brakeControl[1] = 2f;
        }
    }
}