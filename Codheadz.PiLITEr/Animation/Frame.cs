using System.Collections.Generic;

namespace Codheadz.PiLITEr.Animation
{
    public sealed class Frame : IFrame
    {
        public Frame()
        {
            OnPins = new List<int>();
            OffPins = new List<int>();
        }

        public Frame(string state, int duration)
        {
            Duration = duration;

            OnPins = new List<int>();
            OffPins = new List<int>();

            var pins = state.ToLower().ToCharArray();
            int index = 0;
            foreach (var p in pins)
            {
                if (p == '1')
                    OnPins.Add(index);
                else if (p == '0')
                    OffPins.Add(index);

                index++;
                if (index > 7)
                    break;
            }
        }

        public IList<int> OnPins { get; private set; }
        public IList<int> OffPins { get; private set; }
        public int Duration { get; set; }
    }
}