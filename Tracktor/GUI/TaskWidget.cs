using System;

using SpaceVIL;
using SpaceVIL.Core;
using SpaceVIL.Decorations;

using Tracktor.GUI;

namespace Tracktor
{
    class TaskWidget : HorizontalStack
    {

        private ImageItem _statusImage;
        private Label _statusLabel;

        private Label _nameLabel;

        private ImageItem _typeImage;
        private Label _typeLabel;

        private ImageItem _priorityImage;
        private Label _priorityLabel;

        public TaskWidget() : base()
        {
            SetContentAlignment(ItemAlignment.Left);
            SetWidthPolicy(SizePolicy.Expand);
            SetHeightPolicy(SizePolicy.Fixed);
            SetHeight(50);
            SetSpacing(new Spacing(0));
           
            _statusImage = new ImageItem(Resources.Test);
            _statusImage.SetSizePolicy(SizePolicy.Fixed, SizePolicy.Fixed);
            _statusImage.SetSize(20, 20);//20 pixels 
            _statusImage.SetAlignment(ItemAlignment.Left, ItemAlignment.VCenter);
            _statusImage.KeepAspectRatio(true);
            _statusLabel = new Label("Test");
            _statusLabel.SetWidthPolicy(SizePolicy.Fixed);
            _statusLabel.SetWidth(93);
            _statusLabel.SetFontSize(25);            

            _nameLabel = new Label("Test feature or something");
            _nameLabel.SetToolTip(_nameLabel.GetText());
            _nameLabel.SetWidthPolicy(SizePolicy.Expand);
            _nameLabel.SetFontSize(25);
            
            _typeImage = new ImageItem(Resources.Test);            
            _typeImage.SetSizePolicy(SizePolicy.Fixed, SizePolicy.Fixed);            
            _typeImage.SetSize(20, 20);            
            _typeImage.SetAlignment(ItemAlignment.Left, ItemAlignment.VCenter);
            _typeImage.KeepAspectRatio(true);            

            _typeLabel = new Label("Test");
            _typeLabel.SetWidthPolicy(SizePolicy.Fixed);
            _typeLabel.SetWidth(180);
            _typeLabel.SetFontSize(25);

            _priorityImage = new ImageItem(Resources.Test);
            _priorityImage.SetSizePolicy(SizePolicy.Fixed, SizePolicy.Fixed);
            _priorityImage.SetSize(20, 20);
            _priorityImage.SetAlignment(ItemAlignment.Left, ItemAlignment.VCenter);
            _priorityImage.KeepAspectRatio(true);
            _priorityLabel = new Label("Test");
            _priorityLabel.SetWidthPolicy(SizePolicy.Fixed);
            _priorityLabel.SetWidth(112);
            _priorityLabel.SetFontSize(25);

            EventMouseClick += Click;
        }

        public override void InitElements()
        {
            AddItems(new VerticalSpacer(), _statusImage, new VerticalSpacer(), _statusLabel, new VerticalSpacer(),
                _nameLabel, new VerticalSpacer(), _typeImage, new VerticalSpacer(), _typeLabel,
                new VerticalSpacer(), _priorityImage, new VerticalSpacer(), _priorityLabel);  
            foreach(Prototype item in GetItems())
                item.EventMouseClick += Click;
        }

        private void Click(IItem sender, MouseArgs args)
        {
            Console.WriteLine("Im one of TaskWidget");
        }

        public void SetStaus(bool status) // TODO : Change to enum
        {
            if (status)
            {
                _statusImage.SetImage(Resources.Done);
                _statusLabel.SetText("Done");
            }               
            else
            {
                _statusImage.SetImage(Resources.WIP);
                _statusLabel.SetText("WIP");
            }
        }
    }
}
