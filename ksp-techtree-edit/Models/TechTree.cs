using System.Collections.Generic;

namespace ksp_techtree_edit.Models
{
	internal class TechTree
	{
		#region Private Properties

		private List<TechNode> _nodes = new List<TechNode>();

		#endregion Private Properties

		#region Public Properties

		public string Name { get; set; }

		public List<TechNode> Nodes
		{
			get { return _nodes; }
			set { _nodes = value; }
		}

		#endregion Public Properties

		#region Public Methods

		public bool AddNode(TechNode node)
		{
			Nodes.Add(node);
			return true;
		}

		public bool RemoveNode(TechNode node)
		{
			Nodes.Remove(node);
			return true;
		}

		#endregion Public Methods
	}

    public enum TreeType
    {
        ATC,
        TechMananger,
        YongeTech
    }

}
