using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemExamProd.Models
{
    public partial class Order
    {
        public bool Pay { get => PaymentStatusId == 1 ? true : false; }
    }
}
