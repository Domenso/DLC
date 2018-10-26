#include <Servo.h>

int armState = 0;
Servo arm[2];

void setup() {
  Serial.begin(9600);
  for(int i = 0; i < 2; i++){
    arm[i].attach(i+2);
  }
}

void loop() {
  if (Serial.available()) {
    armState = recvSerial();
    delay(100);

    //Sword
    if (armState == 1){
      arm[0].write(180);
      arm[1].write(0);
      delay(500);
      arm[0].write(90);
      arm[1].write(90);
    }
    //Pickaxe
    else if(armState == 2){
      arm[0].write(100);
      arm[1].write(45);
      arm[2].write(0);
    }
    //HandGun
    else if(armState == 3){
      arm[0].write(80);
      arm[1].write(5);
      arm[2].write(000);
    }
    //Rifle
    else if(armState == 4){
      arm[0].write(80);
      arm[1].write(162);
      arm[2].write(0);
    }
    //DefaultPosition
    else{
      Serial.println("nothing");
      arm[0].write(60);
      arm[1].write(5);
      arm[2].write(000);
    }
  }
}

int recvSerial() {
  if (Serial.available()) {
    int serialData = Serial.read();
    switch (serialData) {
      case '1':
        return 1;
        break;
    case '0':
        return 0;
        break;
      case '2':
        return 2;
        break;
      case '3':
        return 3;
        break;
      case '4':
        return 4;
        break;
      default:
        return -1;
    }
  }
}

void servoWrite(Servo servo, int degree){
  servo.write(degree);
}
