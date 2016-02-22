using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.Foundation;

namespace Codheadz.PiLITEr.Animation
{
    public delegate void AnimationComplete();

    public sealed class FrameAnimator : IDisposable
    {
        private IPiLITErController controller;
        private List<IFrame> frames;

        public FrameAnimator(IPiLITErController controller)
        {
            frames = new List<IFrame>();
            this.controller = controller;
        }

        public event AnimationComplete OnAnimationComplete;

        public void AddFrame(IFrame frame)
        {
            frames.Add(frame);
        }

        public void AddFrames(IList<IFrame> framesToAdd)
        {
            frames.AddRange(framesToAdd);
        }

        public void Clear()
        {
            frames.Clear();
        }

        public void Dispose()
        {
            if (controller != null)
                controller.Dispose();

            controller = null;
        }

        public IAsyncAction PlayAsync()
        {
            return Task.Run(async () =>
            {
                for (int i = 0; i < frames.Count; i++)
                {
                    var current = frames[i];
                    foreach (var onPin in current.OnPins)
                    {
                        controller.Write(onPin, GpioPinValue.High);
                    }
                    foreach (var offPin in current.OffPins)
                    {
                        controller.Write(offPin, GpioPinValue.Low);
                    }

                    await Task.Delay(current.Duration);
                }

                FireAnimationComplete();
            }).AsAsyncAction();
        }

        private void FireAnimationComplete()
        {
            if (OnAnimationComplete != null)
                OnAnimationComplete();
        }
    }
}