using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KerbalParser
{
	[DataContract]
	public class KerbalNode
	{
		public KerbalNode(string name, KerbalNode parent = null)
		{
			Name = name;
			Parent = parent;
			Values = new Dictionary<string, List<string>>();
			Children = new List<KerbalNode>();

			if (Parent != null)
                Parent.Children.Add(this);
		}

		[DataMember(Order = 1)]
		public string Name { get; set; }

		public KerbalNode Parent { get; set; }

		[DataMember(Order = 3)]
		public IDictionary<string, List<string>> Values { get; set; }

		[DataMember(Order = 4)]
		public IList<KerbalNode> Children { get; set; }

		public override string ToString()
		{
			return JsonSerializer.To(this);
		}
	}
}
