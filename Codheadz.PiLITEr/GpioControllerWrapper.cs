using Windows.Devices.Gpio;

namespace Codheadz.PiLITEr
{
    internal class GpioControllerWrapper : IGpioControllerWrapper
    {
        private GpioController controller;

        public GpioControllerWrapper(GpioController controller)
        {
            this.controller = controller;
        }

        public IGpioPinWrapper OpenPin(int i)
        {
            var pin = controller.OpenPin(i);
            var wrapped = new GpioPinWrapper(pin);
            return wrapped;
        }
    }
}