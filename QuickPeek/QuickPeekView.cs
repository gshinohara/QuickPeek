using Eto.Drawing;
using Eto.Forms;

namespace QuickPeek
{
    [System.Runtime.InteropServices.Guid("73FAE334-E8A7-4988-BDE8-AE397AC2633C")]
    public class QuickPeekView: Panel
    {
        private QuickPeekViewModel m_ViewModel;

        private TextArea m_ObjectNameBox;
        private TextArea m_ColorBox;
        private TextArea m_LayerNameBox;
        private TextArea m_ObjectTypeBox;
        private TextArea m_GuidBox;

        public QuickPeekView()
        {
            m_ViewModel = new QuickPeekViewModel(this);
            DataContext = m_ViewModel;
            InitializeComponent();
            BindToViewModel();
        }

        private void InitializeComponent()
        {
            m_ObjectNameBox = new TextArea
            {
                ReadOnly = true,
                Size = new Size(200, 40),
                Wrap = true
            };

            m_ColorBox = new TextArea
            {
                ReadOnly = true,
                Size = new Size(200, 40),
                Wrap = true
            };

            m_LayerNameBox = new TextArea
            {
                ReadOnly = true,
                Size = new Size(200, 40),
                Wrap = true
            };

            m_ObjectTypeBox = new TextArea
            {
                ReadOnly = true,
                Size = new Size(200, 40),
                Wrap = true
            };

            m_GuidBox = new TextArea
            {
                ReadOnly = true,
                Size = new Size(200, 40),
                Wrap = true
            };

            DynamicLayout layout = new DynamicLayout
            {
                Padding = 10,
                Spacing = new Size(5, 5)
            };
            Content = layout;

            layout.AddSeparateRow(new Label { Text = "QuickPeek", Font = new Font(SystemFont.Bold, 12), TextAlignment = TextAlignment.Center });
            layout.AddSeparateRow(new GroupBox { Text = "Name", Padding = 5, Content = m_ObjectNameBox });
            layout.AddSeparateRow(new GroupBox { Text = "Color", Padding = 5, Content = m_ColorBox });
            layout.AddSeparateRow(new GroupBox { Text = "Layer", Padding = 5, Content = m_LayerNameBox });
            layout.AddSeparateRow(new GroupBox { Text = "Type", Padding = 5, Content = m_ObjectTypeBox });
            layout.AddSeparateRow(new GroupBox { Text = "GUID", Padding = 5, Content = m_GuidBox });
            layout.AddSeparateRow(null);
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
