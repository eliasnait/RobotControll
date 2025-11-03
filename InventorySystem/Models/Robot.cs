using System;

namespace InventorySystem.Models
{
    public class Robot
    {
        // 1️⃣ Private backing events
        private event Action<string> _onLog;
        private event Action<string> _onError;

        // 2️⃣ Offentlige wrappers (så andre kan lytte)
        public event Action<string> OnLog
        {
            add { _onLog += value; }
            remove { _onLog -= value; }
        }

        public event Action<string> OnError
        {
            add { _onError += value; }
            remove { _onError -= value; }
        }

        // 3️⃣ Beskyttet metode til at sende URScript
        protected void SendUrscript(string script)
        {
            Console.WriteLine("URScript sent: " + script);
        }

        // 4️⃣ Hjælpemetoder til at aktivere logning
        protected void RaiseLog(string message)
        {
            _onLog?.Invoke(message);
        }

        protected void RaiseError(string message)
        {
            _onError?.Invoke(message);
        }
    }
}