using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace Codheadz.PiLITEr.Animation
{
    public delegate void AnimationComplete();

    public sealed class FrameAnimator
    {
        private List<IFrame> frames;
        private IPiLITErController controller;

        public event AnimationComplete OnAnimationComplete;

        private void FireAnimationComplete()
        {
            if (OnAnimationComplete != null)
                OnAnimationComplete();
        }

        public FrameAnimator(IPiLITErController controller)
        {
            
            frames = new List<IFrame>();
            this.controller = controller;
        }

        private Task task;
        private CancellationTokenSource tokenSource;

        public void Stop()
        {
            controller.AllOff();
            tokenSource.Cancel();
        }

        public void Play()
        {
            if (tokenSource != null && tokenSource.IsCancellationRequested)
                tokenSource.Cancel();

            tokenSource = new CancellationTokenSource();
            CancellationToken ct = tokenSource.Token;

            task = Task.Factory.StartNew(async () =>
            {
                for (int i = 0; i < frames.Count; i++)
                {
                    ct.ThrowIfCancellationRequested();

                    var current = frames[i];
                    foreach (var onPin in current.OnPins)
                    {
                        controller.Write(onPin, GpioPinValue.High);
                    }
                    foreach (var offPin in current.OffPins)
                    {
                        controller.Write(offPin, GpioPinValue.Low);
                    }

                    if (ct.IsCancellationRequested)
                    {
                        // Clean up here, then...
                        ct.ThrowIfCancellationRequested();
                    }

                    await Task.Delay(current.Duration);
                }
                FireAnimationComplete();
            });

            try
            {
                task.Wait();
            }
            catch (AggregateException e)
            {
            }
            finally
            {
                tokenSource.Dispose();
            }
        }

        public void AddFrame(IFrame frame)
        {
            if(tokenSource != null)
                tokenSource.Cancel();

            frames.Add(frame);
        }

        public void AddFrames(IList<IFrame> framesToAdd)
        {
            if (tokenSource != null)
                tokenSource.Cancel();

            frames.AddRange(framesToAdd);
        }

        public void Clear()
        {
            if (tokenSource != null)
                tokenSource.Cancel();

            frames.Clear();
        }
    }
}