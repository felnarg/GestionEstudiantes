
using Application._Resource;

namespace Application.Validations
{
    public static class Validations
    {
        public static bool FieldValidation(string field)
        {
            if (string.IsNullOrEmpty(field))
                return false;
            else
                return true;

        }
        public static string ClassStudentsFieldsValidations(string studentId, string courseId, string name, string age)
        {
            if (string.IsNullOrEmpty(studentId))
                return string.Format(Resource1.FieldVerify, Constants.STUDENT_ID);
            else if (string.IsNullOrEmpty(courseId))
                return string.Format(Resource1.FieldVerify, Constants.COURSE_ID);
            else if (string.IsNullOrEmpty(name))
                return string.Format(Resource1.FieldVerify, Constants.NAME);
            else if (string.IsNullOrEmpty(age))
                return string.Format(Resource1.FieldVerify, Constants.AGE);
            else
                return Resource1.Ok;
        }
    }
}
