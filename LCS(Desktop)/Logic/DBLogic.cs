using DataBaseAndLogic.DBlogic;
using DataBaseAndLogic.Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LCS_Desktop_.Logic
{
    public static class DBLogic
    {
        public static List<Lcs> DBGetter()//Connection to DB for getting results
        {
            using (LocalContext lcsContext = new LocalContext())
            {
                var lst = lcsContext.LcsStrings.Skip(Math.Max(0, lcsContext.LcsStrings.Count() - 5)).ToList();
                lst.Reverse();//reverse list for propper results
                return lst;
            }
        }
        public static void DBSetter(string strFirst, string strSecond)
        {
            using (LocalContext lcsContext = new LocalContext())
            {
                lcsContext.LcsStrings.Add(new Lcs(strFirst, strSecond));//Connection to DB for saving results
                lcsContext.SaveChanges();
            }
        }
    }
}
