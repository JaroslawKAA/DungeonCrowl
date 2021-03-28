using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEditor.Experimental.GraphView;

namespace Source.Actors.Items
{
    public interface ItemDetector
    {
        // TODO Jarek is working on it 
        public List<ISelectable> ItemsAround { get; set; }
        public ISelectable SelectedItem { get; set; }

    }
}