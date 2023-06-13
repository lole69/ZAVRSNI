

#include <SoftwareSerial.h>
SoftwareSerial myConnection(10, 11);


int pushButton = 4;
int pushButton2 = 6;
int pushButton3 = 9;
int pushButton4 = 2;

void setup() {
  Serial.begin(9600);
  myConnection.begin(9600);
  pinMode(pushButton, INPUT);
}

void loop() {
  if (digitalRead(pushButton) == HIGH) {
    myConnection.println("g1");
    //myConnection.println("\n");
    Serial.flush();
  }
  if (digitalRead(pushButton2) == HIGH) {
    myConnection.println("d1");
    //myConnection.println("\n");
    Serial.flush();

  }
  if (digitalRead(pushButton3) == HIGH) {
    myConnection.println("g2");
    //myConnection.println("\n");
    Serial.flush();
  }
  if (digitalRead(pushButton4) == HIGH) {
    myConnection.println("d2");
    Serial.flush();
  }

  else myConnection.println("0");
  Serial.flush();
}


delay(10);
// delay in between reads for stability
}
