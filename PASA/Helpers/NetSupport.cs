
using PASA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NETAUCTION.Helpers
{
    public class NetSupport 
    {
       
        public decimal NextBidInfo(decimal CurrentAmount)
        {
            try
            {
                if (CurrentAmount < 100)
                {
                    CurrentAmount = CurrentAmount + 10;
                }
                else if (CurrentAmount < 1000)
                {
                    CurrentAmount = CurrentAmount + 100;
                }
                else if (CurrentAmount < 5000)
                {
                    CurrentAmount = CurrentAmount + 500;
                }
                else if (CurrentAmount >= 5000)
                {
                    CurrentAmount = CurrentAmount + 1000;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return CurrentAmount;
        }
    }
}