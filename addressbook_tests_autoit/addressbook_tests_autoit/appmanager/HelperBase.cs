namespace addressbook_tests_autoit
{
    public class HelperBase
    {
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager applicationManager)
        {
            this.manager = applicationManager;
        }

        public void ThreeStepWinActivate(string winTitle)
        {
            manager.Aux.WinWait(winTitle);
            manager.Aux.WinActivate(winTitle);
            manager.Aux.WinWaitActive(winTitle);
        }
    }
}