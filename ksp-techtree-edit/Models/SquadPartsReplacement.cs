using System;
using System.IO;
using KerbalParser;
using ksp_techtree_edit.Models;
using ksp_techtree_edit.Util;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SquadPartsReplacement
{
    public class SquadPartsReplacement
    {
        public static string ReplaceSquadTextTitle(IDictionary<string, List<string>> WrongPart)
        {
            string replacement = "nothing";
            StreamReader file = new StreamReader(@"SquadParts.txt");
            string line;
            string[] token;
            while((line = file.ReadLine()) != null)
            {
                if (line.Contains(WrongPart["name"].First()))
                {
                    token = line.Split('=');
                    foreach(var tokentest in token)
                    {
                        if((tokentest.Contains("autoLOC")) || (tokentest.Contains(WrongPart["name"].First())))
                        {
                        }
                        else
                        {
                            replacement = tokentest;
                            return replacement;
                        }
                    }
                    return replacement;
                }
                else
                {

                }
            }

            return replacement;
        }
        public static string ReplaceSquadTextDescription(IDictionary<string, List<string>> WrongPart)
        {
            string replacement = "nothing";
            StreamReader file = new StreamReader(@"SquadParts.txt");
            string line;
            string[] token;
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(WrongPart["name"].First()))
                {
                    token = line.Split('=');
                    foreach (var tokentest in token)
                    {
                        if ((tokentest.Contains("autoLOC")) || (tokentest.Contains(WrongPart["description"].First())))
                        {
                        }
                        else
                        {
                            replacement = tokentest;
                            return replacement;
                        }
                    }
                }
                else
                {

                }
            }

            return replacement;
        }
    }
}
