using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1 : TaskInterface
{

    float current;
    int rotation;
    bool goStraight;
    bool done;
    int turn;
    public Task1(){
        current = 0;
        rotation = 1;
        goStraight = true;
        done  = false;
        turn = 0;
    }


    public bool colorCheck(DeviceRegistry devices){
        
        for(int i=6; i<7;i++){
            for(int j=6; j<9; j++){
                Debug.Log($"{i} - {j} - 0 -{devices.pixels[i,j,0]}");
                Debug.Log($"{i} - {j} - 1 -{devices.pixels[i,j,1]}");
                Debug.Log($"{i} - {j} - 2 -{devices.pixels[i,j,2]}");
                if(devices.pixels[i,j,0] != 120) return false;
                if(devices.pixels[i,j,1] != 120) return false;
                if(devices.pixels[i,j,2] != 120) return false;
            }
        }
        return true;
    }

    public bool isGreen(DeviceRegistry devices){
        for(int i=6; i<7;i++){
            for(int j=6; j<9; j++){
                if(devices.pixels[i,j,0] != 0) return false;
                if(devices.pixels[i,j,2] != 27) return false;
            }
        }
        return true;
    }

    public bool isFarGreen(DeviceRegistry devices){
        for(int i=4; i<5;i++){
            for(int j=8; j<11; j++){

                Debug.Log($"{i} - {j} - 0 -{devices.pixels[i,j,0]}");
                Debug.Log($"{i} - {j} - 1 -{devices.pixels[i,j,1]}");
                Debug.Log($"{i} - {j} - 2 -{devices.pixels[i,j,2]}");
                if(devices.pixels[i,j,0] != 0) return false;
                if(devices.pixels[i,j,2] != 27) return false;
            }
        }
        return true;
    }
    
    public void Execute(DeviceRegistry devices) {
        
        devices.memory[0] = 0f;
        Debug.Log($"Siren: {devices.microphone[0]}");
        if(rotation == 1 && (devices.compass[0] >= (current+0.25) || devices.compass[0] <= (current-0.25))) {
            // Debug.Log($"Not north {devices.compass[0]} ---- {current}");
            devices.speedControl[0] = 1f;
            devices.speedControl[1] = 0f;
            devices.brakeControl[0] = 1f;
            devices.brakeControl[1] = 2f;
            devices.steeringControl[0] = 1f;
            devices.steeringControl[1] = -0.25f;
        } 
        else {
            rotation = 0;
            devices.brakeControl[0] = 1f;
            devices.brakeControl[1] = 0f;
            devices.steeringControl[0] = 1f;
            devices.steeringControl[1] = 0f;
            if(!done){
            if(rotation == 0 && goStraight){
                devices.speedControl[0] = 1f;
                devices.speedControl[1] = 3f;
            }

            if(turn ==0 && isGreen(devices)){
                Debug.Log($"Near Green");
                rotation = 1;
                current = -90;
                devices.speedControl[0] = 1f;
                devices.speedControl[1] = 0f;
                devices.brakeControl[0] = 1f;
                devices.brakeControl[1] = 0f;
                goStraight = true;
                //done = true;
                devices.memory[0] = 1f;
                turn = 1;
            }
            if(turn == 1 && isFarGreen(devices)){

                    Debug.Log($"Far Green");
                    rotation = 1;
                    current = 0;
                    goStraight = false;
                    devices.speedControl[0] = 1f;
                    devices.speedControl[1] = 0f;
                    devices.brakeControl[0] = 1f;
                    devices.brakeControl[1] = 0f;
                }
            }
        }

        // if((devices.compass[0]<= 0.25 && devices.compass[0] >= -0.25) || (devices.compass[0] >= -90.25 && devices.compass[0] <= 89.75)){devices.speedControl[0] = 1f;
        // devices.speedControl[1] = 3f;}
        // else{devices.speedControl[0] =0f; devices.speedControl[1] = 0f;}
    }
}