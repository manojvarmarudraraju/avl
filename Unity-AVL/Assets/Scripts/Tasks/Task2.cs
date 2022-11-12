using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2 : TaskInterface
{   
    float current;
    public Task2(){
        current = 0;
    }
    public void Execute(DeviceRegistry devices) {
        
        if(devices.memory[0] == 4f){
            current = 180;
            if(devices.compass[0] >= (current+0.25) || devices.compass[0] <= (current-0.25)){
                devices.speedControl[0] = 1f;
                devices.speedControl[1] = 0f;
                devices.brakeControl[0] = 1f;
                devices.brakeControl[1] = 2f;
                devices.steeringControl[0] = 1f;
                devices.steeringControl[1] = -0.25f;
            } else {
                devices.steeringControl[0] = 1f;
                devices.steeringControl[1] = 0f;
                devices.speedControl[0] = 1f;
                devices.speedControl[1] = 1f;
                devices.brakeControl[0] = 1f;
                devices.brakeControl[1] = 0f;
            }
        }
    }

}