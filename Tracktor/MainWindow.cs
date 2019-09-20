using System;
using System.Drawing;
using SpaceVIL;

namespace Tracktor
{
    class MainWindow : ActiveWindow
    {

        //public static VerticalStack Tasks;

        private VerticalStack _mainstack;

        private HorizontalStack _topbar;
        private ImageItem _addbutton;
        private ImageItem _settingsbutton;
        private TextEdit _search;

        private HorizontalStack _filter;
        private Label _namelabel;
        private ComboBox _priority;
        private ComboBox _status;

        public override void InitWindow()
        {
            SetParameters("Tracktor", "Tracktor", 720, 800);
            SetMinSize(400, 300);
            SetBackground(32, 32, 32);
            SetIcon(Resources.dozer, Resources.dozer);

            _mainstack = new VerticalStack();
            _mainstack.SetAlignment(SpaceVIL.Core.ItemAlignment.Top);
            _mainstack.SetWidthPolicy(SpaceVIL.Core.SizePolicy.Expand);
            _mainstack.SetHeightPolicy(SpaceVIL.Core.SizePolicy.Expand);
            _mainstack.SetContentAlignment(SpaceVIL.Core.ItemAlignment.Top);
            AddItem(_mainstack);

            _mainstack.AddItem(AddHorisontalSpacer());

            _topbar = new HorizontalStack();
            _topbar.SetContentAlignment(SpaceVIL.Core.ItemAlignment.Left);            
            _topbar.SetWidthPolicy(SpaceVIL.Core.SizePolicy.Expand);
            _topbar.SetMaxHeight(50);
            _mainstack.AddItem(_topbar);

            _topbar.AddItem(AddVerticalSpacer());

            _addbutton = new ImageItem(Resources.add);
            _addbutton.KeepAspectRatio(true);
            _addbutton.SetMaxSize(50, 50);
            _topbar.AddItem(_addbutton);

            _topbar.AddItem(AddVerticalSpacer());

            _settingsbutton = new ImageItem(Resources.settings);
            _settingsbutton.KeepAspectRatio(true);
            _settingsbutton.SetMaxSize(50, 50);
            _topbar.AddItem(_settingsbutton);

            _topbar.AddItem(AddVerticalSpacer());

            _search = new TextEdit();
            _search.SetAlignment(SpaceVIL.Core.ItemAlignment.VCenter);
            _search.SetHeight(50);
            _search.SetFontSize(48);
            _topbar.AddItem(_search);

            _topbar.AddItem(AddVerticalSpacer());

            _mainstack.AddItem(AddHorisontalSpacer());

            _filter = new HorizontalStack();
            _filter.SetContentAlignment(SpaceVIL.Core.ItemAlignment.Left);
            _filter.SetWidthPolicy(SpaceVIL.Core.SizePolicy.Expand);
            _filter.SetMaxHeight(50);
            _mainstack.AddItem(_filter);

            _filter.AddItem(AddVerticalSpacer());

            _namelabel = new Label("Name");
            _namelabel.SetWidthPolicy(SpaceVIL.Core.SizePolicy.Expand);
            _namelabel.SetMaxHeight(50);
            _namelabel.SetMaxWidth(110);
            _namelabel.SetFontSize(48);
            _filter.AddItem(_namelabel);

            _filter.AddItem(AddVerticalSpacer());

            _priority = new ComboBox();
            _priority.SetWidthPolicy(SpaceVIL.Core.SizePolicy.Expand);
            _priority.SetMaxHeight(50);
            _priority.SetFontSize(48);
            _filter.AddItem(_priority);

            _filter.AddItem(AddVerticalSpacer());

            _status = new ComboBox();
            _status.SetWidthPolicy(SpaceVIL.Core.SizePolicy.Expand);
            _status.SetMaxHeight(50);
            _status.SetFontSize(48);            
            _filter.AddItem(_status);
            _status.AddItem(new Label("test"));

            _filter.AddItem(AddVerticalSpacer());
        }

        private BlankItem AddHorisontalSpacer(int height = 10)
        {
            BlankItem result = new BlankItem();
            result.SetHeight(height);
            result.SetMaxHeight(height);
            return result;
        }

        private BlankItem AddVerticalSpacer(int width = 10)
        {
            BlankItem result = new BlankItem();
            result.SetWidth(width);
            result.SetMaxWidth(width);
            return result;
        }
    }
}
