using Codheadz.PiLITEr;
using Codheadz.PiLITEr.Animation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace PiLiteRPlay
{
    public sealed class StartupTask : IBackgroundTask
    {
        private FrameAnimator animator;
        private IList<IFrame> frames;

        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();

            BuildFrames();

            var pilitr = PiLITErController.GetController();

            animator = new FrameAnimator(pilitr);

            animator.AddFrames(frames);

            animator.OnAnimationComplete += Animator_OnAnimationComplete;

            await Task.Run(async () =>
            {
                while (true)
                    await animator.PlayAsync();
            });
        }

        private void Animator_OnAnimationComplete()
        {
            System.Diagnostics.Debug.WriteLine("Animation Complete");
        }

        private void BuildFrames()
        {
            frames = new List<IFrame>();

            var frameA = new Frame("01010101", 80);
            var frameB = new Frame("10101010", 80);

            for (int i = 0; i < 10; i++)
            {
                frames.Add(frameA);
                frames.Add(frameB);
            }

            var frameC = new Frame("00110011", 80);
            var frameD = new Frame("11001100", 80);

            for (int i = 0; i < 10; i++)
            {
                frames.Add(frameC);
                frames.Add(frameD);
            }

            frames.Add(new Frame("00000000", 80));
            frames.Add(new Frame("00000001", 80));
            frames.Add(new Frame("00000010", 80));
            frames.Add(new Frame("00000100", 80));
            frames.Add(new Frame("00001000", 80));
            frames.Add(new Frame("00010000", 80));
            frames.Add(new Frame("00100000", 80));
            frames.Add(new Frame("01000000", 80));
            frames.Add(new Frame("10000000", 80));
            frames.Add(new Frame("11000000", 80));
            frames.Add(new Frame("11100000", 80));
            frames.Add(new Frame("11110000", 80));
            frames.Add(new Frame("11111000", 80));
            frames.Add(new Frame("11111100", 80));
            frames.Add(new Frame("11111110", 80));
            frames.Add(new Frame("11111111", 80));
            frames.Add(new AllOffFrame(80));
            frames.Add(new AllOnFrame(80));
            frames.Add(new AllOffFrame(80));
            frames.Add(new AllOnFrame(80));
            frames.Add(new AllOffFrame(80));
            frames.Add(new AllOnFrame(80));
            frames.Add(new AllOffFrame(80));
            frames.Add(new AllOnFrame(80));
            frames.Add(new AllOffFrame(80));

            frames.Add(new Frame("00000001", 45));
            frames.Add(new Frame("00000010", 45));
            frames.Add(new Frame("00000100", 45));
            frames.Add(new Frame("00001001", 45));
            frames.Add(new Frame("00010010", 45));
            frames.Add(new Frame("00100100", 45));
            frames.Add(new Frame("01001001", 45));
            frames.Add(new Frame("10010010", 45));
            frames.Add(new Frame("10100100", 45));
            frames.Add(new Frame("11001001", 45));
            frames.Add(new Frame("11010010", 45));
            frames.Add(new Frame("11100100", 45));
            frames.Add(new Frame("11101001", 45));
            frames.Add(new Frame("11110010", 45));
            frames.Add(new Frame("11110100", 45));
            frames.Add(new Frame("11111001", 45));
            frames.Add(new Frame("11111010", 45));
            frames.Add(new Frame("11111101", 45));
            frames.Add(new Frame("11111110", 45));
            frames.Add(new AllOnFrame(80));
            frames.Add(new AllOffFrame(80));

            for (int n = 0; n < 15; n++)
            {
                frames.Add(new Frame("10000001", 20));
                frames.Add(new Frame("01000010", 20));
                frames.Add(new Frame("00100100", 20));
                frames.Add(new Frame("00011000", 20));
                frames.Add(new Frame("00100100", 20));
                frames.Add(new Frame("01000010", 20));
            }
            frames.Add(new AllOffFrame(80));
        }
    }
}