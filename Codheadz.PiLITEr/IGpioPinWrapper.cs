using System;
using Windows.Devices.Gpio;

namespace Codheadz.PiLITEr
{
    internal interface IGpioPinWrapper : IDisposable
    {
        void SetDriveMode(GpioPinDriveMode mode);

        void Write(GpioPinValue state);
    }
}