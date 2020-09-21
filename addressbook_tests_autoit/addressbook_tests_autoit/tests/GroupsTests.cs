using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupsTests : TestBase
    {


        [Test]
        public void TestGroupCreation()
        {
            //Assert.Pass();

            List<GroupData> oldGroups = app.Groups.GetList();

            GroupData gr = new GroupData()
            {
                Name = "test"
            };

            app.Groups.Add(gr);

            List<GroupData> newGroups = app.Groups.GetList();

            oldGroups.Add(gr);

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}