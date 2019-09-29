using SpaceVIL;
using SpaceVIL.Core;

namespace Tracktor.GUI
{
    class VerticalSpacer : Frame
    {
        public VerticalSpacer(int width = 10) : base()
        {
            SetWidthPolicy(SizePolicy.Fixed);
            SetWidth(width);
        }
    }
}
