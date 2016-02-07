using System.Collections.Generic;
using Windows.Devices.Gpio;

namespace Codheadz.PiLITEr
{
    public sealed class PiLITErController : IPiLITErController
    {
        private static PiLITErController controller;
        private IGpioControllerWrapper gpioController;
        private Dictionary<int, IGpioPinWrapper> pins;

        internal PiLITErController(IGpioControllerWrapper controller)
        {
            gpioController = controller;

            Initialize();
        }

        public static PiLITErController GetController()
        {
            var gpioController = new GpioControllerWrapper(GpioController.GetDefault());

            if (controller == null)
                controller = new PiLITErController(gpioController);

            return controller;
        }

        public void AllOff()
        {
            foreach (var pin in pins.Values)
            {
                pin.Write(GpioPinValue.Low);
            }
        }

        public void AllOn()
        {
            foreach (var pin in pins.Values)
            {
                pin.Write(GpioPinValue.High);
            }
        }

        public void Dispose()
        {
            foreach (var pin in pins.Values)
            {
                pin.Dispose();
            }

            pins.Clear();
        }

        public void Write(int lightIndex, GpioPinValue state)
        {
            var pin = pins[lightIndex];
            pin.Write(state);
        }

        private void Initialize()
        {
            var pinsList = new List<int>();
            pinsList.Add(4);
            pinsList.Add(17);
            pinsList.Add(27);
            pinsList.Add(18);
            pinsList.Add(22);
            pinsList.Add(23);
            pinsList.Add(24);
            pinsList.Add(25);

            pins = new Dictionary<int, IGpioPinWrapper>();
            for (int i = 0; i < pinsList.Count; i++)
            {
                var pin = this.gpioController.OpenPin(pinsList[i]);
                pin.Write(GpioPinValue.Low);
                pin.SetDriveMode(GpioPinDriveMode.Output);
                pins.Add(i, pin);
            }
        }
    }
}