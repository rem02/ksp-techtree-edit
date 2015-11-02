using ksp_techtree_edit.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksp_techtree_edit.Saver
{
    public abstract class TreeSaver
    {
        private readonly List<string> _output = new List<string>();

        protected int IndentationLevel = 0;

        public abstract TreeSaver StartTree(TechTreeViewModel techTree = null);

        public abstract void Save(TechTreeViewModel techTree, string path);

        public abstract TreeSaver StartNode();
        public abstract TreeSaver SaveAttribute(KeyValuePair<string, string> nameAttributePair);
        public abstract TreeSaver SavePosition(double x, double y, double z);
        public abstract TreeSaver StartParents();
        public abstract TreeSaver SaveParents(IEnumerable<string> parentsList);
        public abstract TreeSaver EndParents();
        public abstract TreeSaver StartParts();
        public abstract TreeSaver SaveParts(TechNodeViewModel node);
        public abstract TreeSaver EndParts();
        public abstract TreeSaver EndNode();
        public abstract TreeSaver EndTree();

        public void Save(string path)
        {
            File.WriteAllLines(path, _output);
        }

        protected void AddLine(int count = 1)
        {
            for (var i = 0; i < count; i++)
            {
                _output.Add(Environment.NewLine);
            }
        }

        protected void AddLine(string line)
        {
            _output.Add(Tabs + line);
        }

        protected void AddLineRange(ICollection<string> lines)
        {
            foreach (var line in lines)
            {
                AddLine(line);
            }
        }

        private string Tabs
        {
            get { return new String('\t', IndentationLevel); }
        }
    }
}
