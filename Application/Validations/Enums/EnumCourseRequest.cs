using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations.Enums
{
    public static class EnumCourseRequest
    {
        public enum Posibilities
        {
            correct,
            badIdCourse,
            badName,
            duplicateIdKey
        }
    }
}
