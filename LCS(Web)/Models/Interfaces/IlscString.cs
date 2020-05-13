using DataBaseAndLogic;
using DataBaseAndLogic.Logic;
using System.Collections.Generic;
using System.Linq;

namespace LCS_Web_.Models.Interfaces
{
    public interface ILscString
    {
        IQueryable<Lcs> LcsStrings { get; }
        public void AddElement(Lcs lcs);
        public List<Lcs> LastElements(int n);
    }
}
