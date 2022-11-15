/*
 * Description:
 *    使用 Raspberry pi 硬體 PWM 做出呼吸燈
*/
using System;
using System.Device.Gpio;
using System.Device.Pwm;
using System.Threading;

Console.WriteLine("Hardware PWM Breathe Led Start.");
// chip 0, channel 0 -> GPIO 12
int pin = 0;
int channel = 0;
var pwm = PwmChannel.Create(pin, channel, 400, 1.0);
pwm.Start();

while(true){
  Console.WriteLine("逐漸變亮");
  for (double fill = 0.0; fill <= 1.0;fill+=0.01){
    pwm.DutyCycle = fill;
    Thread.Sleep(10);
  }
  Thread.Sleep(1000);
  Console.WriteLine("逐漸變暗");
  for (double fill = 1.0; fill >= 0.0;fill-=0.01){
    pwm.DutyCycle = fill;
    Thread.Sleep(10);
  }
}

