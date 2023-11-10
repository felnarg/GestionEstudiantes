using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application._Resource.Validations
{
    public static class Validations
    {
        public static void FieldValidation(string propertie, string field)
        {
            if (field == null || field == "")
            {   
                throw new Exception(string.Format(Resource1.FieldVerify, propertie));
            }            
        }
    }
}
