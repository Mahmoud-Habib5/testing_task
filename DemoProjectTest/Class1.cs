using NUnit.Framework;
using StudentSystem;

namespace DemoProjectTest
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void Test_AllStudents_NotEmpty()
        {
            Program program = new Program();
            var students = program.AllStudents();
            Assert.That(students, Is.Not.Empty);
        }

        [Test]
        public void Test_GetDetails()
        {
            Program program = new Program();
            var studentFound = program.getDetails(1);
            var studentNotFound = program.getDetails(999);

            Assert.That(studentFound, Is.Not.Empty);
            Assert.That(studentFound[0].name, Is.EqualTo("Ahmed"));

            Assert.That(studentNotFound, Is.Empty);
        }

        [Test]
        public void Test_AddUser()
        {
            Program program = new Program();
            var failResult = program.AddUser("", "", "male", new int[] { 90, 80, 70 });
            var successResult = program.AddUser("10", "Sara", "Female", new int[] { 90, 80, 85 });

            Assert.That(failResult, Is.EqualTo("Student ID or Name couldn't be empty"));
            Assert.That(successResult, Is.EqualTo("Success"));

            var addedStudent = program.getDetails(10);
            Assert.That(addedStudent, Is.Not.Empty);
            Assert.That(addedStudent[0].name, Is.EqualTo("Sara"));
        }

        [Test]
        public void Test_DeleteUser()
        {
            Program program = new Program();
            program.AddUser("20", "TestStudent", "Male", new int[] { 70, 75, 80 });

            var successDelete = program.DeleteUser(20, "TestStudent");
            var failDelete = program.DeleteUser(999, "UnknownStudent");

            Assert.That(successDelete, Is.EqualTo("Success"));
            Assert.That(failDelete, Is.EqualTo("Fail"));
        }

        [Test]
        public void Test_TotalResult()
        {
            Program program = new Program();
            int[] degrees = { 80, 90, 70, 60 };
            var total = program.totalresult(degrees);

            Assert.That(total, Is.EqualTo(300));
        }

        [Test]
        public void Test_Grade()
        {
            Program program = new Program();
            int[] excellentDegrees = { 95, 90, 85, 100, 90 };
            int[] veryGoodDegrees = { 80, 78, 76, 75, 79 };
            int[] goodDegrees = { 60, 65, 55, 50, 70 };
            int[] failDegrees = { 30, 40, 20, 35, 25 };

            var excellentGrade = program.grade(excellentDegrees);
            var veryGoodGrade = program.grade(veryGoodDegrees);
            var goodGrade = program.grade(goodDegrees);
            var failGrade = program.grade(failDegrees);

            Assert.That(excellentGrade, Is.EqualTo("Excellent"));
            Assert.That(veryGoodGrade, Is.EqualTo("Very Good"));
            Assert.That(goodGrade, Is.EqualTo("Good"));
            Assert.That(failGrade, Is.EqualTo("Fail"));
        }
    }
}


