using SpaceVIL;
using SpaceVIL.Core;

namespace Tracktor.GUI
{
    class HoriontalSpacer : Frame
    {
        public HoriontalSpacer(int height = 10) : base()
        {            
            SetHeightPolicy(SizePolicy.Fixed);
            SetHeight(height);
        }
    }
}
