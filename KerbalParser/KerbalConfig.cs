using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KerbalParser
{
	[DataContract]
	public class KerbalConfig : IList<KerbalNode>
	{
		[DataMember(Order = 1)]
		public string FileName { get; set; }

		[DataMember(Order = 2)]
		public IList<KerbalNode> Nodes;

		public KerbalConfig(string fileName, IList<KerbalNode> nodes = null)
		{
			FileName = fileName;
			Nodes = nodes ?? new List<KerbalNode>();
		}

		public KerbalNode First()
		{
			return Nodes.Count > 0 ? Nodes[0] : null;
		}

		#region Member implementations

		public IEnumerator<KerbalNode> GetEnumerator()
		{
			return Nodes.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable) Nodes).GetEnumerator();
		}

		public void Add(KerbalNode item)
		{
			Nodes.Add(item);
		}

		public void Clear()
		{
			Nodes.Clear();
		}

		public bool Contains(KerbalNode item)
		{
			return Nodes.Contains(item);
		}

		public void CopyTo(KerbalNode[] array, int arrayIndex)
		{
			Nodes.CopyTo(array, arrayIndex);
		}

		public bool Remove(KerbalNode item)
		{
			return Nodes.Remove(item);
		}

		public int Count
		{
			get { return Nodes.Count; }
		}

		public bool IsReadOnly
		{
			get { return Nodes.IsReadOnly; }
		}

		public int IndexOf(KerbalNode item)
		{
			return Nodes.IndexOf(item);
		}

		public void Insert(int index, KerbalNode item)
		{
			Nodes.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			Nodes.RemoveAt(index);
		}

		public KerbalNode this[int index]
		{
			get { return Nodes[index]; }
			set { Nodes[index] = value; }
		}

		#endregion
	}
}
