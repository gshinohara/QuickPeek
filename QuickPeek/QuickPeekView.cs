using Eto.Drawing;
using Eto.Forms;

namespace QuickPeek
{
    [System.Runtime.InteropServices.Guid("73FAE334-E8A7-4988-BDE8-AE397AC2633C")]
    public class QuickPeekView : Panel
    {
        private QuickPeekViewModel m_ViewModel;

        private readonly TextArea m_ObjectNameBox = CreateTextArea();
        private readonly TextArea m_ColorBox = CreateTextArea();
        private readonly TextArea m_LayerNameBox = CreateTextArea();
        private readonly TextArea m_ObjectTypeBox = CreateTextArea();
        private readonly TextArea m_GuidBox = CreateTextArea();

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

            layout.AddSeparateRow(new Label { Text = "QuickPeek", Font = new Font(SystemFont.Bold, 12), TextAlignment = TextAlignment.Center });
            layout.AddSeparateRow(CreateGroupBox("Name", m_ObjectNameBox));
            layout.AddSeparateRow(CreateGroupBox("Color", m_ColorBox));
            layout.AddSeparateRow(CreateGroupBox("Layer", m_LayerNameBox));
            layout.AddSeparateRow(CreateGroupBox("Type", m_ObjectTypeBox));
            layout.AddSeparateRow(CreateGroupBox("GUID", m_GuidBox));
            layout.AddSeparateRow(null);

            SizeChanged += (sender, e) =>
            {
                m_ObjectNameBox.Width = Width - 80;
                m_ColorBox.Width = Width - 80;
                m_LayerNameBox.Width = Width - 80;
                m_ObjectTypeBox.Width = Width - 80;
                m_GuidBox.Width = Width - 80;
            };
        }

        private static TextArea CreateTextArea()
        {
            TextArea textArea = new TextArea
            {
                ReadOnly = true,
                Wrap = true,
                Height = 60,
            };
            return textArea;
        }

        private static GroupBox CreateGroupBox(string text, TextArea content)
        {
            Button button = new Button { Text = "Copy" };
            button.Click += (sender, e) => Clipboard.Instance.SetString(content.Text, string.Empty);

            return new GroupBox
            {
                Text = text,
                Padding = 5,
                Content = new StackLayout
                {
                    Orientation = Orientation.Vertical,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Spacing = 5,
                    Items = { content, button }
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
        }
    }
}
