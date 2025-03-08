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
        private string m_BlockName;
        private string m_BlockType;
        private string m_LayerStyle;
        private string m_SourceArchive;

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

        public string BlockName
        {
            get => m_BlockName;
            set
            {
                m_BlockName = value;
                OnPropertyChanged();
            }
        }

        public string BlockType
        {
            get => m_BlockType;
            set
            {
                m_BlockType = value;
                OnPropertyChanged();
            }
        }

        public string LayerStyle
        {
            get => m_LayerStyle;
            set
            {
                m_LayerStyle = value;
                OnPropertyChanged();
            }
        }

        public string SourceArchive
        {
            get => m_SourceArchive;
            set
            {
                m_SourceArchive = value;
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

                if (obj is InstanceObject instanceObj)
                    UpdateFromBlock(instanceObj);
                else
                {
                    BlockName += "\n";
                    BlockType += "\n";
                    LayerStyle += "\n";
                    SourceArchive += "\n";
                }
            }
            ObjectName = ObjectName.Trim('\n');
            Color = Color.Trim('\n');
            LayerName = LayerName.Trim('\n');
            ObjectType = ObjectType.Trim('\n');
            Guid = Guid.Trim('\n');
            BlockName = BlockName.Trim('\n');
            BlockType = BlockType.Trim('\n');
            LayerStyle = LayerStyle.Trim('\n');
            SourceArchive = SourceArchive.Trim('\n');
        }

        private void UpdateFromBlock(InstanceObject blockInstance)
        {
            var instanceDef = blockInstance.InstanceDefinition;
            if (instanceDef == null) return;

            BlockName += $"{instanceDef.Name}\n";
            BlockType += $"{instanceDef.GetBlockType()}\n";
            LayerStyle += $"{instanceDef.LayerStyle}\n";
            SourceArchive += $"{instanceDef.SourceArchive}\n";
        }

        private void Initialize()
        {
            ObjectName = string.Empty;
            Color = string.Empty;
            LayerName = string.Empty;
            ObjectType = string.Empty;
            Guid = string.Empty;
            BlockName = string.Empty;
            BlockType = string.Empty;
            LayerStyle = string.Empty;
            SourceArchive = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
