using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application._Resource.Validations
{
    public class Validations
    {
        public static void FieldValidation(Course field)
        {
            if (field == null || field.Name == "")
            {   
                throw new Exception(string.Format(Resource1.FieldVerify, nameof(field.Name)));
            }            
        }             
    }
}
