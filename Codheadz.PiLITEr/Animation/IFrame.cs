using System.Collections.Generic;

namespace Codheadz.PiLITEr.Animation
{
    public interface IFrame
    {
        IList<int> OnPins { get; }
        IList<int> OffPins { get; }
        int Duration { get; set; }
    }
}