using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemExamProd.Models
{
    public partial class User
    {
        public string FullName
        {
            get => string.Join(" ", FirstName, Surname, Middlename);
        }
    }
}
