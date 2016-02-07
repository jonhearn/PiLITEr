using System.Collections.Generic;

namespace Codheadz.PiLITEr.Animation
{
    public sealed class AllOffFrame : IFrame
    {
        public AllOffFrame(int duration)
        {

            OnPins = new List<int>();
            OffPins = new List<int>();

            Duration = duration;
            for (int i = 0; i < 8; i++)
            {
                OffPins.Add(i);
            }
        }

        public int Duration
        {
            get; set;
        }

        public IList<int> OffPins
        {
            get; private set;
        }

        public IList<int> OnPins
        {
            get; private set;
        }
    }
}