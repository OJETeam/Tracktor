using System;
using System.Drawing;

using SpaceVIL;
using SpaceVIL.Core;
using SpaceVIL.Decorations;

namespace Tracktor.GUI
{
    class CustomMenuItem : MenuItem
    {
        public CustomMenuItem(String name, Bitmap bitmap) : base(name)
        {
            SetFont(new Font(new FontFamily("Arial"), 26, FontStyle.Regular));
            SetTextMargin(new Indents(22, 0, 0, 0));
            ImageItem img = new ImageItem(bitmap);
            img.SetSizePolicy(SizePolicy.Fixed, SizePolicy.Fixed);
            img.SetSize(20, 20);
            img.SetAlignment(ItemAlignment.Left, ItemAlignment.VCenter);
            img.KeepAspectRatio(true);
            AddItem(img);
        }
    }
}
