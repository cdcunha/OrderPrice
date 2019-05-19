using OrderBatch.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderBatch.Helpers
{
    public static class CommissionHelper
    {
        /// <summary>
        /// Get a list of total of commissions by Boutiques
        /// </summary>
        /// <param name="commissions">Commissions list</param>
        /// <returns>List of total of commissions by Boutiques</returns>
        public static List<string> GetCommissionsByBoutique(List<Commission> commissions)
        {
            List<string> commissionsByBoutique = new List<string>();

            //Group list by boutique
            commissions.GroupBy(g => g.BoutiqueId).ToList().ForEach(f =>
            {
                //Check if there are more that one orders
                if (f.Count() > 1)
                {
                    //Found the highest price and set commission to zero
                    f.Where(w => w.TotalPrice == f.Max(m => m.TotalPrice)).FirstOrDefault().Commision = 0;
                }

                //Sum commissions of boutique
                decimal sum = f.Sum(s => s.Commision);

                //Add boutique ID and total commission to list of commissionsByBoutique
                commissionsByBoutique.Add($"{f.Key},{sum.ToString("n0")}");
            });

            //Return commissions grouped by boutique
            return commissionsByBoutique;
        }
    }
}
