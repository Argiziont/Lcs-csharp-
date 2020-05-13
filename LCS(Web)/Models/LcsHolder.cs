using DataBaseAndLogic.DBlogic;
using DataBaseAndLogic.Logic;
using LCS_Web_.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LCS_Web_.Models
{
    public class LcsHolder
    {
        private Lcs lcs = new Lcs();

        [StringLength(60)]
        [Required(ErrorMessage = "Please enter first string")]
        public string First { get { return lcs.FirstString; } set { lcs.FirstString = value; } }
        [StringLength(60)]
        [Required(ErrorMessage = "Please enter second string")]
        public string Second { get { return lcs.SecondString; } set { lcs.SecondString = value; } }
        public string Answer { get
            {
                if (First == null || Second == null)
                {
                    return null;
                    //
                }
                return lcs.AnswerString.Remove(lcs.AnswerString.Length - 1) ; } }
        public List<Lcs> Strings {get;set;}

    }
}
