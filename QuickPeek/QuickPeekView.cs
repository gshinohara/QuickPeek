using Eto.Drawing;
using Eto.Forms;

namespace QuickPeek
{
    [System.Runtime.InteropServices.Guid("73FAE334-E8A7-4988-BDE8-AE397AC2633C")]
    public class QuickPeekView: Panel
    {
        private TextArea m_ObjectNameBox;
        private TextArea m_ColorBox;
        private TextArea m_LayerNameBox;
        private TextArea m_ObjectTypeBox;
        private TextArea m_GuidBox;

        public QuickPeekView()
        {
            InitializeComponent();
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
    }
}
