namespace DemoApp.Services
{
    public class MyScopeService : IMyScopeService
    {
        private static int _counter;

        public void IncrementCounter()
        {
            _counter++;
        }

        public int GetCounterValue()
        {
            return _counter;
        }
    }
}
