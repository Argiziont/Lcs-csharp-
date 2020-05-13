using DataBaseAndLogic;
using DataBaseAndLogic.DBlogic;
using DataBaseAndLogic.Logic;
using LCS_Web_.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCS_Web_.Models
{
    public class EFLscString : ILscString
    {
        //getting DB
        private LocalContext context;
        public EFLscString(LocalContext context)
        {
            this.context = context;
        }
        //Iqueryably for better DB performance
        public IQueryable<Lcs> LcsStrings => context.LcsStrings;

        public void AddElement(Lcs lcs)
        {
            context.LcsStrings.Add(lcs);
            context.SaveChanges();
        }
        //getting N last elements
        public List<Lcs> LastElements(int n)
        {
            var lcslist = LcsStrings.Skip(Math.Max(0, LcsStrings.Count() - n)).ToList();
            lcslist.Reverse();// using Reverce by itself for propper work
            return lcslist;
        }
    }
}
