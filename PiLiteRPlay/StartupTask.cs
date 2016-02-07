using Codheadz.PiLITEr;
using Codheadz.PiLITEr.Animation;
using Windows.ApplicationModel.Background;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace PiLiteRPlay
{
    public sealed class StartupTask : IBackgroundTask
    {
        private FrameAnimator animator;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();

            var pilitr = PiLITErController.GetController();

            animator = new FrameAnimator(pilitr);

            animator.OnAnimationComplete += Animator_OnAnimationComplete;
            var frameA = new Frame("01010101", 60);
            var frameB = new Frame("10101010", 60);

            for (int i = 0; i < 10; i++)
            {
                animator.AddFrame(frameA);
                animator.AddFrame(frameB);
            }

            var frameC = new Frame("00110011", 60);
            var frameD = new Frame("11001100", 60);

            for (int i = 0; i < 10; i++)
            {
                animator.AddFrame(frameC);
                animator.AddFrame(frameD);
            }

            animator.AddFrame(new Frame("00000000", 60));
            animator.AddFrame(new Frame("00000001", 60));
            animator.AddFrame(new Frame("00000010", 60));
            animator.AddFrame(new Frame("00000100", 60));
            animator.AddFrame(new Frame("00001000", 60));
            animator.AddFrame(new Frame("00010000", 60));
            animator.AddFrame(new Frame("00100000", 60));
            animator.AddFrame(new Frame("01000000", 60));
            animator.AddFrame(new Frame("10000000", 60));
            animator.AddFrame(new Frame("11000000", 60));
            animator.AddFrame(new Frame("11100000", 60));
            animator.AddFrame(new Frame("11110000", 60));
            animator.AddFrame(new Frame("11111000", 60));
            animator.AddFrame(new Frame("11111100", 60));
            animator.AddFrame(new Frame("11111110", 60));
            animator.AddFrame(new Frame("11111111", 60));
            animator.AddFrame(new AllOffFrame(60));
            animator.AddFrame(new AllOnFrame(60));
            animator.AddFrame(new AllOffFrame(60));
            animator.AddFrame(new AllOnFrame(60));
            animator.AddFrame(new AllOffFrame(60));
            animator.AddFrame(new AllOnFrame(60));
            animator.AddFrame(new AllOffFrame(60));
            animator.AddFrame(new AllOnFrame(60));
            animator.AddFrame(new AllOffFrame(60));

            animator.AddFrame(new Frame("00000001", 90));
            animator.AddFrame(new Frame("00000010", 90));
            animator.AddFrame(new Frame("00000100", 90));
            animator.AddFrame(new Frame("00001001", 90));
            animator.AddFrame(new Frame("00010010", 90));
            animator.AddFrame(new Frame("00100100", 90));
            animator.AddFrame(new Frame("01001001", 90));
            animator.AddFrame(new Frame("10010010", 90));
            animator.AddFrame(new Frame("10100100", 90));
            animator.AddFrame(new Frame("11001001", 90));
            animator.AddFrame(new Frame("11010010", 90));
            animator.AddFrame(new Frame("11100100", 90));
            animator.AddFrame(new Frame("11101001", 90));
            animator.AddFrame(new Frame("11110010", 90));
            animator.AddFrame(new Frame("11110100", 90));
            animator.AddFrame(new Frame("11111001", 90));
            animator.AddFrame(new Frame("11111010", 90));
            animator.AddFrame(new Frame("11111101", 90));
            animator.AddFrame(new Frame("11111110", 90));
            animator.AddFrame(new AllOnFrame(60));
            animator.AddFrame(new AllOffFrame(60));

            for (int n = 0; n < 10; n++)
            {
                animator.AddFrame(new Frame("10000001", 50));
                animator.AddFrame(new Frame("01000010", 50));
                animator.AddFrame(new Frame("00100100", 50));
                animator.AddFrame(new Frame("00011000", 50));
                animator.AddFrame(new Frame("00100100", 50));
                animator.AddFrame(new Frame("01000010", 50));
            }
            animator.AddFrame(new AllOffFrame(60));

            animator.Play();
        }

        private void Animator_OnAnimationComplete()
        {
            System.Diagnostics.Debug.WriteLine("Animation Complete");
            animator.Play();
        }
    }
}