using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using KerbalParser;
using ksp_techtree_edit.Util;

namespace ksp_techtree_edit.Models
{
	public class TechNode
	{
		#region Members

		public string NodeName { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Cost { get; set; }
		public Point Pos { get; set; }

		private int _zlayer;

		public int Zlayer
		{
			get { return _zlayer; }
			set { _zlayer = value.Clamp(-24, -1); }
		}

		public string TechId { get; set; }
		public Icon Icon { get; set; }
		public bool AnyParent { get; set; }
		public bool HideIfEmpty { get; set; }
		public bool HideIfNoBranchParts { get; set; }

		public List<TechNode> Parents { get; set; }

		public List<string> Parts { get; set; }

		#endregion Members

		#region Constructors

		public TechNode()
		{
		}

		public TechNode(string name)
		{
			NodeName = name;
			Title = String.IsNullOrEmpty(name)
				        ? String.Empty
				        : char.ToUpper(name[0]) + name.Substring(1);
			Description = "";
			Cost = 0;
			Pos = new Point(0, 0);
			Zlayer = 0;
			TechId = GenerateTechId();
			Icon = Icon.BASICROCKETRY;
			AnyParent = false;
			HideIfEmpty = false;
			HideIfNoBranchParts = false;
			Parents = new List<TechNode>();
			Parts = new List<string>();
		}

		#endregion Constructors

		#region Methods

		public void PopulateFromSource( KerbalNode sourceNode, TreeType treeType = TreeType.TechMananger)
		{
			var v = sourceNode.Values;

			NodeName = v.ContainsKey("name") ? v["name"].First() : "";

			double x;
			double y;
			switch (treeType)
			{
				case TreeType.TechMananger:
					TechId = v.ContainsKey("techID") ? v["techID"].First() : "";

					if (v.ContainsKey("pos"))
					{
						var posString = v["pos"].First();
						var coordinates = posString.Split(',');

						if (coordinates.Length >= 2)
						{
							if (!Double.TryParse(coordinates[0], out x))
							{
								x = 0;
							}

							if (!Double.TryParse(coordinates[1], out y))
							{
								y = 0;
							}
							Pos = new Point(x, y);

							decimal z;
							if (!Decimal.TryParse(coordinates[2], out z))
							{
								Zlayer = -1;
							}
							Zlayer = (int)z;
						}
					}
					break;

				case TreeType.ATC:
					TechId = GenerateTechId();

					x = 0;
					y = 0;
					if (v.ContainsKey("posX"))
					{
						if (!Double.TryParse(v["posX"].First(), out x))
						{
							x = 0;
						}
					}

					if (v.ContainsKey("posY"))
					{
						if (!Double.TryParse(v["posY"].First(), out y))
						{
							y = 0;
						}
					}
					Pos = new Point(x, y);
					break;
			}

			if (v.ContainsKey("icon"))
			{
				Icon icon;
				if (!Enum.TryParse(v["icon"].First(), true, out icon))
				{
					icon = Icon.UNDEFINED;
				}
				Icon = icon;
			}

			Title = v.ContainsKey("title") ? v["title"].First() : "";
			Description = v.ContainsKey("description") ? v["description"].First() : "";

			AnyParent = false;
			HideIfEmpty = false;
			HideIfNoBranchParts = false;

			if (treeType == TreeType.ATC)
			{
				if (v.ContainsKey("scienceCost"))
				{
					int c;
					if (!Int32.TryParse(v["scienceCost"].First(), out c))
					{
						Cost = 0;
					}
					Cost = c;
				}
				if (v.ContainsKey("anyParentUnlocks"))
				{
					switch (v["anyParentUnlocks"].First().Trim().ToLower())
					{
						case "true":
							AnyParent = true;
							break;
					}
				}
				if (v.ContainsKey("hideIfNoparts"))
				{
					switch (v["hideIfNoparts"].First().Trim().ToLower())
					{
						case "true":
							HideIfEmpty = true;
							break;
					}
				}
			}
			else
			{
				if (v.ContainsKey("cost"))
				{
					int c;
					if (!Int32.TryParse(v["cost"].First(), out c))
					{
						Cost = 0;
					}
					Cost = c;
				}
				if (v.ContainsKey("anyParent"))
				{
					switch (v["anyParent"].First().Trim().ToLower())
					{
						case "true":
							AnyParent = true;
							break;
					}
				}
				if (v.ContainsKey("hideIfEmpty"))
				{
					switch (v["hideIfEmpty"].First().Trim().ToLower())
					{
						case "true":
							HideIfEmpty = true;
							break;
					}
				}
				if (v.ContainsKey("hideIfNoBranchParts"))
				{
					switch (v["hideIfNoBranchParts"].First().Trim().ToLower())
					{
						case "true":
							HideIfNoBranchParts = true;
							break;
					}
				}
			}

			// Create an empty parents collection, populated during linking
			Parents = new List<TechNode>();

			var tmpParts = new List<string>();
			foreach (var child in sourceNode.Children.Where(child => child.Name == "PARTS").Where(child => child.Values.ContainsKey("name")))
			{
				tmpParts.AddRange(child.Values["name"]);
			}
			Parts = new List<string>(tmpParts);
		}

		public string GenerateTechId()
		{
			if (String.IsNullOrEmpty(NodeName)) return "";
			var i = NodeName.IndexOf('_');
			return i > 0 && i + 1 < NodeName.Length ? NodeName.Substring(i + 1) : NodeName;
		}

		#endregion Methods
	}
}


