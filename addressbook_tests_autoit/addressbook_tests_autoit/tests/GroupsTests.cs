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

            List<GroupData> oldGroups = UtilGetGroupsList();

            GroupData gr = new GroupData()
            {
                Name = "test"
            };

            app.Groups  .OpenGroupsWindow()
                        .Add(gr)
                        .CloseGroupsWindow();

            List<GroupData> newGroups = UtilGetGroupsList();

            oldGroups.Add(gr);

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }
       [Test]
        public void TestGroupRemoval()
        {
            int victumIndex;
            //Assert.Pass();

            List<GroupData> oldGroups = UtilGetGroupsList();

            if (oldGroups.Count == 1)
            {
                TestGroupCreation();
                oldGroups = UtilGetGroupsList();
            }

            victumIndex = oldGroups.Count - 1; // the last one

            GroupData victumGr = oldGroups[victumIndex];

            oldGroups.RemoveAt(victumIndex);

            app.Groups.OpenGroupsWindow()
                .RemoveAt(victumIndex)
                .CloseGroupsWindow();

            List<GroupData> newGroups = UtilGetGroupsList();

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }

        private List<GroupData> UtilGetGroupsList()
        {
            List<GroupData> groups = app.Groups.OpenGroupsWindow().GetList();
            app.Groups.CloseGroupsWindow();
            return groups;
        }
    }
}