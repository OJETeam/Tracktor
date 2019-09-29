using System;

using SpaceVIL;
using SpaceVIL.Decorations;
using SpaceVIL.Core;

using Tracktor.GUI;

namespace Tracktor
{
    class MainWindow : ActiveWindow
    {
        private VerticalStack _mainStack;

        private HorizontalStack _topBar;
        private ButtonCore _addButton;
        private ButtonCore _settingsButton;
        private TextEdit _search;

        private HorizontalStack _filter;
        private ComboBox _status;
        private MenuItem _statusAll;
        private MenuItem _statusDone;
        private MenuItem _statusWIP;
        private Label _nameLabel;
        private ComboBox _priority;
        private MenuItem _priorityAll;
        private MenuItem _priorityTrivial;
        private MenuItem _priorityMinor;
        private MenuItem _priorityMajor;
        private MenuItem _priorityCritical;
        private MenuItem _priorityBlocker;
        private ComboBox _type;
        private MenuItem _typeAll;
        private MenuItem _typeFeature;
        private MenuItem _typeBug;
        private MenuItem _typeImprovement;
        private MenuItem _typeRefactor;
        private ListBox _tasks;

        public override void InitWindow()
        {
            
            SetParameters("Tracktor", "Tracktor", 720, 800);
            SetMinSize(650, 300);
            SetBackground(32, 32, 32);
            SetIcon(Resources.Dozer, Resources.Dozer);            

            _mainStack = new VerticalStack();
            _mainStack.SetAlignment(ItemAlignment.Top);
            _mainStack.SetContentAlignment(ItemAlignment.Top);
            _mainStack.SetWidthPolicy(SizePolicy.Expand);
            _mainStack.SetHeightPolicy(SizePolicy.Expand);            
            AddItem(_mainStack);

            _mainStack.AddItem(new HoriontalSpacer());

            _topBar = new HorizontalStack();
            _topBar.SetContentAlignment(ItemAlignment.Left);            
            _topBar.SetWidthPolicy(SizePolicy.Expand);
            _topBar.SetHeightPolicy(SizePolicy.Fixed);
            _topBar.SetHeight(50);            
            _mainStack.AddItem(_topBar);
            _topBar.AddItem(new VerticalSpacer());

            _addButton = new ButtonCore();
            _addButton.SetSizePolicy(SizePolicy.Fixed, SizePolicy.Fixed);
            _addButton.SetSize(50, 50);
            _addButton.SetBackground(32, 32, 32);
            _addButton.EventMouseClick += _addButtonClick;
            _topBar.AddItem(_addButton);
            _addButton.AddItem(new ImageItem(Resources.Add));
            _topBar.AddItem(new VerticalSpacer());

            _settingsButton = new ButtonCore();            
            _settingsButton.SetSizePolicy(SizePolicy.Fixed, SizePolicy.Fixed);
            _settingsButton.SetSize(50, 50);
            _settingsButton.SetBackground(32, 32, 32);
            _settingsButton.EventMouseClick += _settingsButtonClick;
            _topBar.AddItem(_settingsButton);
            _settingsButton.AddItem(new ImageItem(Resources.Settings));
            _topBar.AddItem(new VerticalSpacer());

            _search = new TextEdit();
            _search.SetAlignment(ItemAlignment.VCenter);
            _search.SetHeight(50);
            _search.SetFontSize(48);
            _topBar.AddItem(_search);
            _topBar.AddItem(new VerticalSpacer());            

            _mainStack.AddItem(new HoriontalSpacer());

            _filter = new HorizontalStack();
            _filter.SetWidthPolicy(SizePolicy.Expand);
            _filter.SetHeightPolicy(SizePolicy.Fixed);
            _filter.SetHeight(50);
            _mainStack.AddItem(_filter);

            _statusAll = new CustomMenuItem("All", Resources.All);
            _statusAll.EventMouseClick += _statusAllClick;
            _statusDone = new CustomMenuItem("Done", Resources.Done);
            _statusDone.EventMouseClick += _statusDoneClick;
            _statusWIP = new CustomMenuItem("WIP", Resources.WIP);
            _statusWIP.EventMouseClick += _statusWIPClick;
            _status = new ComboBox(_statusAll, _statusDone, _statusWIP);
            _status.SetWidthPolicy(SizePolicy.Fixed);
            _status.SetWidth(125);
            _status.SetFontSize(25);            
            _status.SetTextMargin(new Indents(22, 0, 0, 0));

            /*
            ImageItem img = new ImageItem(Resources.Done);
            img.SetSizePolicy(SizePolicy.Fixed, SizePolicy.Fixed);
            img.SetSize(20, 20);
            img.SetAlignment(ItemAlignment.Left, ItemAlignment.VCenter);
            img.KeepAspectRatio(true);
            img.SetMargin(new Indents(11, 0, 0, 0));
            */

            _nameLabel = new Label("Name");
            _nameLabel.SetWidthPolicy(SizePolicy.Fixed);
            _nameLabel.SetWidth(106);
            _nameLabel.SetFontSize(48);

            _typeAll = new CustomMenuItem("All", Resources.All);
            _typeAll.EventMouseClick += _typeAllClick;
            _typeFeature = new CustomMenuItem("Feature", Resources.Test);
            _typeFeature.EventMouseClick += _typeFeatureClick;
            _typeBug = new CustomMenuItem("Bug", Resources.Test);
            _typeBug.EventMouseClick += _typeBugClick;
            _typeImprovement = new CustomMenuItem("Improvement", Resources.Test);
            _typeImprovement.EventMouseClick += _typeImprovementClick;
            _typeRefactor = new CustomMenuItem("Refactor", Resources.Test);
            _typeRefactor.EventMouseClick += _typeRefactorClick;
            _type = new ComboBox(_typeAll, _typeFeature, _typeBug, _typeImprovement, _typeRefactor);
            _type.SetWidthPolicy(SizePolicy.Fixed);
            _type.SetWidth(210);
            _type.SetFontSize(25);
            _type.SetTextMargin(new Indents(22, 0, 0, 0));

            _priorityAll = new CustomMenuItem("All", Resources.All);
            _priorityAll.EventMouseClick += _priorityAllClick;
            _priorityTrivial = new CustomMenuItem("Trivial", Resources.Test);
            _priorityTrivial.EventMouseClick += _priorityTrivialClick;
            _priorityMinor = new CustomMenuItem("Minor", Resources.Test);
            _priorityMinor.EventMouseClick += _priorityMinorClick;
            _priorityMajor = new CustomMenuItem("Major", Resources.Test);
            _priorityMajor.EventMouseClick += _priorityMajorClick;
            _priorityCritical = new CustomMenuItem("Critical", Resources.Test);
            _priorityCritical.EventMouseClick += _priorityCriticalClick;
            _priorityBlocker = new CustomMenuItem("Blocker", Resources.Test);
            _priorityBlocker.EventMouseClick += _priorityBlockerClick;
            _priority = new ComboBox(_priorityAll, _priorityTrivial, _priorityMinor, _priorityMajor, _priorityCritical, _priorityBlocker);
            _priority.SetWidthPolicy(SizePolicy.Fixed);     
            _priority.SetWidth(150);
            _priority.SetFontSize(25);
            _priority.SetTextMargin(new Indents(22, 0, 0, 0));

            Frame f = new Frame();
            f.SetWidthPolicy(SizePolicy.Expand);
            _filter.AddItems(new VerticalSpacer(), _status, new VerticalSpacer(), _nameLabel, f, new VerticalSpacer(), _type, new VerticalSpacer(), _priority, new VerticalSpacer());
            //_status.AddItem(img);
            _status.SetCurrentIndex(0);
            _type.SetCurrentIndex(0);
            _priority.SetCurrentIndex(0);

            _mainStack.AddItem(new HoriontalSpacer());

            _tasks = new ListBox();
            _mainStack.AddItem(_tasks);

            for (int i = 0; i < 25; i++)
            {                
                TaskWidget tw = new TaskWidget();
                _tasks.AddItem(tw);            
            }
        }

        private void _priorityBlockerClick(IItem sender, MouseArgs args)
        {
            Console.WriteLine("Priority -> Blocker selected");
        }

        private void _priorityCriticalClick(IItem sender, MouseArgs args)
        {
            Console.WriteLine("Priority -> Critical selected");
        }

        private void _priorityMajorClick(IItem sender, MouseArgs args)
        {
            Console.WriteLine("Priority -> Major selected");
        }

        private void _priorityMinorClick(IItem sender, MouseArgs args)
        {
            Console.WriteLine("Priority -> Minor selected");
        }

        private void _priorityTrivialClick(IItem sender, MouseArgs args)
        {
            Console.WriteLine("Priority -> Trivial selected");
        }

        private void _priorityAllClick(IItem sender, MouseArgs args)
        {
            Console.WriteLine("Priority -> All selected");
        }

        private void _statusWIPClick(IItem sender, MouseArgs args)
        {
            Console.WriteLine("Status -> WIP selected");
        }

        private void _statusDoneClick(IItem sender, MouseArgs args)
        {
            Console.WriteLine("Status -> Done selected");
        }

        private void _statusAllClick(IItem sender, MouseArgs args)
        {
            Console.WriteLine("Status -> All selected");
        }

        private void _typeRefactorClick(IItem sender, MouseArgs args)
        {
            Console.WriteLine("Type -> Refactor selected");
        }

        private void _typeImprovementClick(IItem sender, MouseArgs args)
        {
            Console.WriteLine("Type -> Improvement selected");
        }

        private void _typeBugClick(IItem sender, MouseArgs args)
        {
            Console.WriteLine("Type -> Bug selected");
        }

        private void _typeFeatureClick(IItem sender, MouseArgs args)
        {
            Console.WriteLine("Type -> Feature selected");
        }

        private void _typeAllClick(IItem sender, MouseArgs args)
        {
            Console.WriteLine("Type -> All selected");
        }

        private void _settingsButtonClick(IItem sender, MouseArgs args)
        {
            Console.WriteLine("Settings button clicked");
        }

        private void _addButtonClick(IItem sender, MouseArgs args)
        {
            Console.WriteLine("Add button clicked");
        }
    }
}
