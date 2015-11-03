using KerbalParser;
using ksp_techtree_edit.Controls;
using ksp_techtree_edit.Models;
using ksp_techtree_edit.Properties;
using ksp_techtree_edit.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksp_techtree_edit.Loader
{
    public abstract class TreeLoader
    {

        public abstract void LoadTree(KerbalConfig config, TechTreeViewModel treeData);

        public abstract TechNode PopulateFromSource(KerbalNode sourceNode);

        public abstract void PopulateParts(PartCollectionViewModel pc, TechNodeViewModel node);

    }
}
