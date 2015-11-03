using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KerbalParser;
using ksp_techtree_edit.Models;
using ksp_techtree_edit.ViewModels;

namespace ksp_techtree_edit.Loader
{
    public class StockTechTreeLoader : TreeLoader
    {
        public override void LoadTree(KerbalConfig config, TechTreeViewModel treeData)
        {

        }

        public override TechNode PopulateFromSource(KerbalNode sourceNode)
        {
            return null;
        }

        public override void PopulateParts(PartCollectionViewModel partCollectionViewModel, TechNodeViewModel node)
        {
            throw new NotImplementedException();
        }
    }
}
