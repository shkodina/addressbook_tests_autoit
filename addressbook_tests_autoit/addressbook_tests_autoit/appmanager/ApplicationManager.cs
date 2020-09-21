using System;
using System.Collections.Generic;
using System.Text;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        private GroupHelper grHelper;
        public ApplicationManager() {
            grHelper = new GroupHelper(this);
        }

        public void Stop() { }

        public GroupHelper Groups
        {
            get
            {
                return grHelper;
            }
        }
    }
}
