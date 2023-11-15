namespace DemoApp.Services
{
    public class MyTransientService : IMyTransientService
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
