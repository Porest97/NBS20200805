using NBS.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Models.ViewModels
{
    public class SallaryAccountBalanceViewModel
    {
        public List<SallaryAccount> SalaryAccounts { get; internal set; }

        public List<TimBanksPost> TimBanksPosts { get; internal set; }
    }
}
