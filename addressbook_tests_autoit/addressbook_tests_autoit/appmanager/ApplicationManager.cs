using System;
using System.Collections.Generic;
using System.Text;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        private AutoItX3 aux;
        private GroupHelper grHelper;
        public ApplicationManager() {
            grHelper = new GroupHelper(this);
            aux = new AutoItX3();
            aux.Run(BaseConfigData.AppSysPath, "", aux.SW_SHOW);
            aux.WinWait(BaseConfigData.AppMainWindowName);
            aux.WinActivate(BaseConfigData.AppMainWindowName);
            aux.WinWaitActive(BaseConfigData.AppMainWindowName);
        }

        public void Stop() 
        {
            aux.ControlClick(BaseConfigData.AppMainWindowName, "", "WindowsForms10.BUTTON.app.0.2c908d510");
            
        }

        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return grHelper;
            }
        }
    }
}
