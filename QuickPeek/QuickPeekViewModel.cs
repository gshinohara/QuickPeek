using Rhino;
using Rhino.DocObjects;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QuickPeek
{
    public class QuickPeekViewModel : INotifyPropertyChanged
    {
        private string m_ObjectName;
        private string m_Color;
        private string m_LayerName;
        private string m_ObjectType;
        private string m_Guid;

        public string ObjectName
        {
            get => m_ObjectName;
            set
            {
                m_ObjectName = value;
                OnPropertyChanged();
            }
        }

        public string Color
        {
            get => m_Color;
            set
            {
                m_Color = value;
                OnPropertyChanged();
            }
        }

        public string LayerName
        {
            get => m_LayerName;
            set
            {
                m_LayerName = value;
                OnPropertyChanged();
            }
        }

        public string ObjectType
        {
            get => m_ObjectType;
            set
            {
                m_ObjectType = value;
                OnPropertyChanged();
            }
        }

        public string Guid
        {
            get => m_Guid;
            set
            {
                m_Guid = value;
                OnPropertyChanged();
            }
        }

        public QuickPeekViewModel(QuickPeekView view)
        {
            Initialize();

            RhinoDoc.SelectObjects += OnSelectionChanged;
            RhinoDoc.DeselectObjects += OnSelectionChanged;
            RhinoDoc.DeselectAllObjects += RhinoDoc_DeselectAllObjects;

            view.Load += (s, e) =>
            {
                RhinoDoc.SelectObjects += OnSelectionChanged;
                RhinoDoc.DeselectObjects += OnSelectionChanged;
                RhinoDoc.DeselectAllObjects += RhinoDoc_DeselectAllObjects;
            };

            view.UnLoad += (s, e) =>
            {
                RhinoDoc.SelectObjects -= OnSelectionChanged;
                RhinoDoc.DeselectObjects -= OnSelectionChanged;
                RhinoDoc.DeselectAllObjects -= RhinoDoc_DeselectAllObjects;
            };
        }

        private void OnSelectionChanged(object sender, RhinoObjectSelectionEventArgs e)
        {
            Update(e.Document);
        }

        private void RhinoDoc_DeselectAllObjects(object sender, RhinoDeselectAllObjectsEventArgs e)
        {
            Update(e.Document);
        }

        private void Update(RhinoDoc doc)
        {
            Initialize();
            foreach (RhinoObject obj in doc.Objects.GetSelectedObjects(true, false))
            {
                ObjectName += $"{obj.Attributes.Name}\n";
                Color += $"{obj.Attributes.ObjectColor.ToProperString()}\n";
                LayerName += $"{doc.Layers.FindIndex(obj.Attributes.LayerIndex).FullPath}\n";
                ObjectType += $"{obj.ObjectType.ToString()}\n";
                Guid += $"{obj.Id.ToString()}\n";
            }
            ObjectName = ObjectName.Trim('\n');
            Color = Color.Trim('\n');
            LayerName = LayerName.Trim('\n');
            ObjectType = ObjectType.Trim('\n');
            Guid = Guid.Trim('\n');
        }

        private void Initialize()
        {
            ObjectName = string.Empty;
            Color = string.Empty;
            LayerName = string.Empty;
            ObjectType = string.Empty;
            Guid = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
