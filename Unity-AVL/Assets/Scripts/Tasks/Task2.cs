using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2 : TaskInterface
{   
    int once;
    public Task2(){
        once = 0;
    }

    public bool isBrown(DeviceRegistry devices){
        for(int i=3; i<4;i++){
            for(int j=8; j<11; j++){
                if(devices.pixels[i,j,0] != 101) return false;
                if(devices.pixels[i,j,1] != 33) return false;
                if(devices.pixels[i,j,2] != 0) return false;
            }
        }
        return true;
    }

    public bool isBlue(DeviceRegistry devices){
        for(int i=3; i<4;i++){
            for(int j=6; j<9; j++){
                if(devices.pixels[i,j,0] != 0) return false;
                if(devices.pixels[i,j,1] != 124) return false;
                if(devices.pixels[i,j,2] !=255) return false;
            }
        }
        return true;
    }

    public bool isFarGreen(DeviceRegistry devices){
        for(int i=4; i<5;i++){
            for(int j=8; j<11; j++){
                if(devices.pixels[i,j,0] != 0) return false;
                if(devices.pixels[i,j,2] != 27) return false;
            }
        }
        return true;
    }

    public void Execute(DeviceRegistry devices) {
        if(once == 2 && devices.microphone[0] == 0 && isBrown(devices)){
            Debug.Log("Second brown");
            
            devices.speedControl[0] = 1f;
            devices.speedControl[1] = 4f;
        }else if(isFarGreen(devices) && devices.compass[0] >= -90.25 && devices.compass[0] <= -89.75){
            Debug.Log("First Blue");
            once = 1;
        }
        else if(once == 1 && devices.microphone[0] == 41 && isBlue(devices) && devices.compass[0] >= -0.25 && devices.compass[0] <= 0.25){
            Debug.Log("bridge up");
            once = 2;
            devices.speedControl[0] = 1f;
            devices.speedControl[1] = 0f;
        }
         else if(once == 1 && devices.microphone[0] == 0 && isBrown(devices) && devices.compass[0] >= -0.25 && devices.compass[0] <= 0.25){
            Debug.Log("first brown");
            devices.speedControl[0] = 1f;
            devices.speedControl[1] = 0f;
        }

    }

}