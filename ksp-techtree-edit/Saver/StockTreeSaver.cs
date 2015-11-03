using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ksp_techtree_edit.ViewModels;

namespace ksp_techtree_edit.Saver
{
    public class StockTreeSaver : TreeSaver
    {
        public override TreeSaver EndNode()
        {
            throw new NotImplementedException();
        }

        public override TreeSaver EndParents()
        {
            throw new NotImplementedException();
        }

        public override TreeSaver EndParts()
        {
            throw new NotImplementedException();
        }

        public override TreeSaver EndTree()
        {
            throw new NotImplementedException();
        }

        public override void Save(TechTreeViewModel techTree, string path)
        {
            throw new NotImplementedException();
        }

        public override TreeSaver SaveAttribute(KeyValuePair<string, string> nameAttributePair)
        {
            throw new NotImplementedException();
        }

        public override TreeSaver SaveParents(IEnumerable<string> parentsList)
        {
            throw new NotImplementedException();
        }

        public override TreeSaver SaveParts(TechNodeViewModel node)
        {
            throw new NotImplementedException();
        }

        public override TreeSaver SavePosition(double x, double y, double z)
        {
            throw new NotImplementedException();
        }

        public override TreeSaver StartNode()
        {
            throw new NotImplementedException();
        }

        public override TreeSaver StartParents()
        {
            throw new NotImplementedException();
        }

        public override TreeSaver StartParts()
        {
            throw new NotImplementedException();
        }

        public override TreeSaver StartTree(TechTreeViewModel techTree = null)
        {
            throw new NotImplementedException();
        }
    }
}
