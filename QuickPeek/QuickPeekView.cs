using Eto.Drawing;
using Eto.Forms;

namespace QuickPeek
{
    [System.Runtime.InteropServices.Guid("73FAE334-E8A7-4988-BDE8-AE397AC2633C")]
    public class QuickPeekView : Panel
    {
        private QuickPeekViewModel m_ViewModel;

        private TextArea m_ObjectNameBox;
        private TextArea m_ColorBox;
        private TextArea m_LayerNameBox;
        private TextArea m_ObjectTypeBox;
        private TextArea m_GuidBox;
        private TextArea m_BlockNameBox;
        private TextArea m_BlockTypeBox;
        private TextArea m_LayerStyleBox;
        private TextArea m_SourceArchiveBox;

        public QuickPeekView()
        {
            m_ViewModel = new QuickPeekViewModel(this);
            DataContext = m_ViewModel;
            InitializeComponent();
            BindToViewModel();
        }

        private void InitializeComponent()
        {
            DynamicLayout layout = new DynamicLayout
            {
                Padding = 10,
                Spacing = new Size(5, 5),
            };
            Content = new Scrollable
            {
                Content = layout,
            };

            TabControl tabControl = new TabControl();

            TabPage basicPage = CreateTabPage(
                "Basic",
                CreateUI("Name", out m_ObjectNameBox),
                CreateUI("Color", out m_ColorBox),
                CreateUI("Layer", out m_LayerNameBox),
                CreateUI("Type", out m_ObjectTypeBox),
                CreateUI("GUID", out m_GuidBox)
                );
            tabControl.Pages.Add(basicPage);

            TabPage blockPage = CreateTabPage(
                "Block",
                CreateUI("Block Name", out m_BlockNameBox),
                CreateUI("Block Type", out m_BlockTypeBox),
                CreateUI("Layer Style", out m_LayerStyleBox),
                CreateUI("Linked Block Path", out m_SourceArchiveBox)
                );
            tabControl.Pages.Add(blockPage);

            layout.AddSeparateRow(new Label { Text = "QuickPeek", Font = new Font(SystemFont.Bold, 12), TextAlignment = TextAlignment.Center });
            layout.AddSeparateRow(tabControl);
            layout.AddSeparateRow(null);
        }

        private static TabPage CreateTabPage(string text,params GroupBox[] groups)
        {
            StackLayout layout = new StackLayout
            {
                Orientation = Orientation.Vertical,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Spacing = 5,
            };

            foreach (GroupBox group in groups)
                layout.Items.Add(group);

            return new TabPage
            {
                Text = text,
                Content = layout,
            };
        }

        private GroupBox CreateUI(string text, out TextArea content)
        {
            TextArea textArea = new TextArea
            {
                ReadOnly = true,
                Wrap = true,
                Height = 60,
            };
            content = textArea;
            this.SizeChanged += (s, e) => textArea.Width = this.Width - 80;

            Button button = new Button { Text = "Copy" };
            button.Click += (sender, e) => Clipboard.Instance.SetString(textArea.Text, string.Empty);

            return new GroupBox
            {
                Text = text,
                Padding = 5,
                Content = new StackLayout
                {
                    Orientation = Orientation.Vertical,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Spacing = 5,
                    Items = { textArea, button }
                },
            };
        }

        private void BindToViewModel()
        {
            m_ObjectNameBox.BindDataContext(c => c.Text, (QuickPeekViewModel vm) => vm.ObjectName);
            m_ColorBox.BindDataContext(c => c.Text, (QuickPeekViewModel vm) => vm.Color);
            m_LayerNameBox.BindDataContext(c => c.Text, (QuickPeekViewModel vm) => vm.LayerName);
            m_ObjectTypeBox.BindDataContext(c => c.Text, (QuickPeekViewModel vm) => vm.ObjectType);
            m_GuidBox.BindDataContext(c => c.Text, (QuickPeekViewModel vm) => vm.Guid);
            m_BlockNameBox.BindDataContext(c => c.Text, (QuickPeekViewModel vm) => vm.BlockName);
            m_BlockTypeBox.BindDataContext(c => c.Text, (QuickPeekViewModel vm) => vm.BlockType);
            m_LayerStyleBox.BindDataContext(c => c.Text, (QuickPeekViewModel vm) => vm.LayerStyle);
            m_SourceArchiveBox.BindDataContext(c => c.Text, (QuickPeekViewModel vm) => vm.SourceArchive);
        }
    }
}
