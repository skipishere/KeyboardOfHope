using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LightupKeyboardStatus;

namespace LightMeUp
{
    public class Light
    {
        private const string name = "Keyboard Beacon";

        public Light()
        {
            var LedInitialized = LogitechGSDK.LogiLedInitWithName(name);

            if (!LedInitialized)
            {
                Console.WriteLine("LogitechGSDK.LogiLedInit() failed.");
                return;
            }

            Console.WriteLine("LED SDK Initialized");
            LogitechGSDK.LogiLedSetTargetDevice(LogitechGSDK.LOGI_DEVICETYPE_RGB);
            LogitechGSDK.LogiLedSaveCurrentLighting();
        }

        private bool Setup()
        {
            if (LogitechGSDK.LogiLedInitWithName(name))
            {
                LogitechGSDK.LogiLedSetTargetDevice(LogitechGSDK.LOGI_DEVICETYPE_RGB);
                return true;
            }

            LogitechGSDK.LogiLedStopEffects();

            return false;
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
        public void PulseRed()
        {
            Setup();
            
            LogitechGSDK.LogiLedPulseLighting(100, 0, 0, LogitechGSDK.LOGI_LED_DURATION_INFINITE, 750);
        }

        public void SolidBlue()
        {
            Setup();
            
            LogitechGSDK.LogiLedSetLighting(0, 0, 100);
        }

        public async Task SolidGreen()
        {
            Setup();

            LogitechGSDK.LogiLedPulseLighting(0, 100, 0, 10000, 750);

            await Task.Run(() => { 
                Thread.Sleep(10000);
                //bool LedInitialized = LogitechGSDK.LogiLedInitWithName("Keyboard Beacon");
                //LogitechGSDK.LogiLedStopEffects();

                //LogitechGSDK.LogiLedSetLighting(0, 100, 0);
                //LogitechGSDK.LogiLedRestoreLighting();
                //LogitechGSDK.LogiLedShutdown();
                ShutDown();
            });
        }

        public void ShutDown()
        {
            LogitechGSDK.LogiLedShutdown();
        }

        ~Light()
        {
            LogitechGSDK.LogiLedShutdown();
        }
    }
}
