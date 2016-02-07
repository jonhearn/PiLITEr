using System;
using Windows.Devices.Gpio;

namespace Codheadz.PiLITEr
{
    public interface IPiLITErController : IDisposable
    {
        void AllOff();

        void AllOn();

        void Write(int lightIndex, GpioPinValue state);
    }
}