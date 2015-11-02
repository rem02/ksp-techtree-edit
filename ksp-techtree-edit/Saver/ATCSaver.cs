using ksp_techtree_edit.Util;
using ksp_techtree_edit.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksp_techtree_edit.Saver
{
    public class ATCSaver : TreeSaver
    {
        private readonly List<string> _partsBuffer = new List<string>();

        public override void Save(TechTreeViewModel techtreeviewmodel, string path)
        {
            this.StartTree(techtreeviewmodel);
            var totalCost = 0;
            foreach (var node in techtreeviewmodel.TechTree)
            {
                totalCost += node.Cost;
                var parts = new List<string>();
                foreach (var part in node.Parts)
                {
                    parts.Add(part.PartName);
                }
                var parents = new List<string>();
                foreach (var parent in node.Parents)
                {
                    parents.Add(parent.NodeName);
                }
                this.StartNode().
                      SaveAttribute(new KeyValuePair<string, string>("name", node.NodeName)).
                      SaveAttribute(new KeyValuePair<string, string>("techID", node.TechId)).
                      SavePosition(node.Pos.X, node.Pos.Y, node.Zlayer).
                      SaveAttribute(new KeyValuePair<string, string>("icon", node.Icon.ToString())).
                      SaveAttribute(new KeyValuePair<string, string>("cost", node.Cost.ToString(CultureInfo.InvariantCulture))).
                      SaveAttribute(new KeyValuePair<string, string>("title", node.Title)).
                      SaveAttribute(new KeyValuePair<string, string>("description", node.Description)).
                      SaveAttribute(new KeyValuePair<string, string>("anyParent", node.AnyParent.ToString())).
                      SaveAttribute(new KeyValuePair<string, string>("hideIfEmpty", node.HideIfEmpty.ToString())).
                      SaveAttribute(new KeyValuePair<string, string>("hideIfNoBranchParts", node.HideIfNoBranchParts.ToString())).
                      StartParents().
                      SaveParents(parents).
                      EndParents().
                      StartParts().
                      SaveParts(node).
                      EndParts().
                      EndNode();
            }
            this.EndTree();
            this.Save(path);
            Logger.Log("Tree saved succesfully to {0}. Total cost: {1} science. Total nodes: {2} nodes.", path, totalCost, techtreeviewmodel.TechTree.Count);
        }

        public override TreeSaver StartTree(TechTreeViewModel techTree = null)
        {
            AddLine("TECH_TREE");
            AddLine("{");
            IndentationLevel++;
            AddLine("name = test");
            return this;
        }

        public override TreeSaver StartNode()
        {
            AddLine("TECH_NODE");
            AddLine("{");
            IndentationLevel++;
            return this;
        }

        public override TreeSaver SaveAttribute(KeyValuePair<string, string> nameAttributePair)
        {
            var key = nameAttributePair.Key;
            switch (nameAttributePair.Key)
            {
                case "anyParent":
                    key = "anyParentUnlocks";
                    break;

                case "hideIfEmpty":
                    key = "hideIfNoparts";
                    break;

                case "cost":
                    key = "scienceCost";
                    break;
            }
            AddLine(key + " = " + nameAttributePair.Value);
            return this;
        }

        public override TreeSaver SavePosition(double x, double y, double z)
        {
            AddLine("posX = " + x);
            AddLine("posY = " + y);
            return this;
        }

        public override TreeSaver StartParents()
        {
            return this;
        }

        public override TreeSaver SaveParents(IEnumerable<string> parentsList)
        {
            var parents = parentsList as string[] ?? parentsList.ToArray();

            foreach (var parent in parents)
            {
                AddLine("PARENT_NODE");
                AddLine("{");
                IndentationLevel++;
                AddLine("name = " + parent);
                IndentationLevel--;
                AddLine("}");
            }

            return this;
        }

        public override TreeSaver EndParents()
        {
            return this;
        }

        public override TreeSaver EndNode()
        {
            IndentationLevel--;
            AddLine("}");
            return this;
        }

        public override TreeSaver StartParts()
        {
            return this;
        }

        public override TreeSaver SaveParts(TechNodeViewModel node)
        {
            foreach (var part in node.Parts)
            {
                _partsBuffer.Add("@PART[" + part.PartName + "]:FINAL");
                _partsBuffer.Add("{");
                IndentationLevel++;
                _partsBuffer.Add("@TechRequired = " + node.TechId);
                IndentationLevel--;
                _partsBuffer.Add("}");
            }
            return this;
        }

        public override TreeSaver EndParts()
        {
            return this;
        }

        public override TreeSaver EndTree()
        {
            IndentationLevel--;
            AddLine("}");
            AddLineRange(_partsBuffer);
            return this;
        }
    }
}
