using System;
using System.Collections.Generic;
using System.Text;

namespace LightupKeyboardStatus
{
    public class Lights
    {
        public Lights()
        {
            bool LedInitialized = LogitechGSDK.LogiLedInitWithName("SetTargetZone Sample C#");

            if (!LedInitialized)
            {
                Console.WriteLine("LogitechGSDK.LogiLedInit() failed.");
                return;
            }

            Console.WriteLine("LED SDK Initialized");
            LogitechGSDK.LogiLedSetTargetDevice(LogitechGSDK.LOGI_DEVICETYPE_ALL);
        }

        public void Black()
        {
            // Set all devices to Black
            LogitechGSDK.LogiLedSetLighting(0, 0, 0);
        }

        public void Go()
        {
            LogitechGSDK.LogiLedSetLightingForTargetZone(DeviceType.Keyboard, 1, 100, 0, 0);
            LogitechGSDK.LogiLedSetLightingForTargetZone(DeviceType.Keyboard, 2, 100, 100, 0);
            LogitechGSDK.LogiLedSetLightingForTargetZone(DeviceType.Keyboard, 3, 0, 100, 0);
            LogitechGSDK.LogiLedSetLightingForTargetZone(DeviceType.Keyboard, 4, 0, 100, 100);
            LogitechGSDK.LogiLedSetLightingForTargetZone(DeviceType.Keyboard, 5, 0, 0, 100);
        }

        public void Pulse()
        {
            LogitechGSDK.LogiLedPulseLighting(100, 50, 0, 500, 100);
        }

        ~Lights()
        {
            LogitechGSDK.LogiLedShutdown();
        }
    }
}
