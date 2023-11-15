
using Application._Resource;
using Application.Validations;
using Microsoft.IdentityModel.Tokens;

namespace Application.Validations
{
    public static class Validations
    {
        public static bool FieldValidation(string field)
        {
            if (field.IsNullOrEmpty())
                return false;
            else
                return true;

        }
        public static string ClassStudentsFieldsValidations(string studentId, string courseId, string name, string age)
        {
            if (studentId.IsNullOrEmpty())
                return string.Format(Resource1.FieldVerify, Constants.STUDENT_ID);
            else if (courseId.IsNullOrEmpty())
                return string.Format(Resource1.FieldVerify, Constants.COURSE_ID);
            else if (name.IsNullOrEmpty())
                return string.Format(Resource1.FieldVerify, Constants.NAME);
            else if (age.IsNullOrEmpty())
                return string.Format(Resource1.FieldVerify, Constants.AGE);
            else
                return Resource1.Ok;
        }
    }
}
