using Windows.Devices.Gpio;

namespace Codheadz.PiLITEr
{
    internal class GpioPinWrapper : IGpioPinWrapper
    {
        private GpioPin pin;

        public GpioPinWrapper(GpioPin pin)
        {
            this.pin = pin;
        }

        public void Dispose()
        {
            if (pin != null)
                pin.Dispose();

            pin = null;
        }

        public void SetDriveMode(GpioPinDriveMode mode)
        {
            pin.SetDriveMode(mode);
        }

        public void Write(GpioPinValue state)
        {
            pin.Write(state);
        }
    }
}