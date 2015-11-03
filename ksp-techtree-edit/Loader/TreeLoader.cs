using KerbalParser;
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

        protected KerbalConfig _config;
        private TechTreeViewModel _treeData;

        public TechTreeViewModel TreeData { get { return _treeData;  } }

        public abstract TechTreeViewModel LoadTree(Dictionary<string, TechNodeViewModel> nameNodeHashtable);



    }
}
