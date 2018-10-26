using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using System;
using System.Threading;

public class weapon1 : MonoBehaviour {
    SerialPort arduino;
    public string portName;
    public int state, past;
    Renderer rend;
    public GameObject currentObject;
    public GameObject playerCam;
    bool isOriginalPosition = true;
    bool typeOfObject = false;   //SWORD IS FALSE -- HAMM is TRUE

    private void Start(){
        playerCam = GameObject.Find("Main Camera");
        arduino = new SerialPort("COM4", 9600);
        arduino.Open();
        state = 0;
        past = -1;
    }

    // Update is called once per frame
    void Update () {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            currentObject = GameObject.Find("Sword");
            Arduino(1, state);
        }
        else if (OVRInput.Get(OVRInput.Button.DpadLeft))
        {
            currentObject = GameObject.Find("Mjolnir");
            Arduino(2, state);
        }
        else if (OVRInput.Get(OVRInput.Button.DpadRight))
        {
            currentObject = GameObject.Find("Nerf");
            Arduino(3, state);
        }
        else if (OVRInput.Get(OVRInput.Button.Two))
        {
            currentObject = GameObject.Find("Gun");
            Arduino(4, state);
        }
    }

    void Arduino(int caso, int estado)
    {
        if (estado == 0){
            arduino.Write(""+caso);
            state=1;
            past = caso;
            currentObject.GetComponent<Renderer>().material.color = Color.black;

            currentObject.transform.Translate(Convert.ToSingle(.541), Convert.ToSingle(.96), Convert.ToSingle(-1.3));

            if (typeOfObject)
            {
                // currentObject.transform.Translate(Convert.ToSingle(.541), Convert.ToSingle(.96), Convert.ToSingle(-1.3));
               // isOriginalPosition = false;

            }
            else {

               // currentObject.transform.Translate(Convert.ToSingle(.541), Convert.ToSingle(.96), Convert.ToSingle(-1.3));
              //  isOriginalPosition = false;

            }

            //Mueve el objeto con una transformacion estandar
            Thread.Sleep(250);
        }
        else if (past == caso){
            arduino.Write("0");
            state=0;
            currentObject.transform.Translate(Convert.ToSingle(-.541), Convert.ToSingle(-.96), Convert.ToSingle(1.3));
            isOriginalPosition = true;
            Thread.Sleep(250);
        }
    }
}
