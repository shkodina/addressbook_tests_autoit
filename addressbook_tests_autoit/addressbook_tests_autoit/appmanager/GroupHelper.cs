using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager applicationManager) : base (applicationManager)
        {
        }

        public List<GroupData> GetList()
        {
            List<GroupData> grList = new List<GroupData>();
            OpenGroupsWindow();
            string strCount = manager.Aux.ControlTreeView(
                BaseConfigData.AppGrEditorWindowName
                , ""
                , "WindowsForms10.SysTreeView32.app.0.2c908d51"
                , "GetItemCount"
                , "#0"
                , ""
                );

            for (int i = 0; i < int.Parse(strCount); i++)
            {
                string cmd = "Select";
                System.Console.Out.WriteLine("Group " + "#0|#" + i + " " + cmd + ": " + manager.Aux.ControlTreeView(
                    BaseConfigData.AppGrEditorWindowName
                    , ""
                    , "WindowsForms10.SysTreeView32.app.0.2c908d51"
                    , cmd
                    , "#0|#" + i
                    , ""
                    ));

                string itemName = manager.Aux.ControlTreeView(
                    BaseConfigData.AppGrEditorWindowName
                    , ""
                    , "WindowsForms10.SysTreeView32.app.0.2c908d51"
                    , "GetText"
                    , "#0|#" + i
                    , ""
                    );


                grList.Add(new GroupData()
                    {
                        Name = itemName
                    }
                );
            }

            CloseGroupsWindow();
            return grList;
        }

        public void Add(GroupData gr)
        {
            OpenGroupsWindow();
            manager.Aux.ControlClick(BaseConfigData.AppGrEditorWindowName, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            manager.Aux.Send(gr.Name);
            manager.Aux.Send("{ENTER}");
            CloseGroupsWindow();

        }

        private void CloseGroupsWindow()
        {
            manager.Aux.ControlClick(BaseConfigData.AppGrEditorWindowName, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsWindow()
        {
            manager.Aux.ControlClick(BaseConfigData.AppMainWindowName, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            manager.Aux.WinWait(BaseConfigData.AppGrEditorWindowName);
        }
    }
}