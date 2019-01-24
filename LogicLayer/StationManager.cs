using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class StationManager
    {
        public static ILog log = LogManager.GetLogger("LogicLayer");
        private static StationManager _Instance;
        private ISubject<string> subject = new Subject<string>();

        private StationManager()
        {
        }

        class ObserverMessaggi : IObserver<string>
        {
            ILog log;
            internal ObserverMessaggi(ILog log)
            {
                this.log = log;
            }

            public void OnCompleted()
            {
                throw new NotImplementedException();
            }

            public void OnError(Exception error)
            {
                throw new NotImplementedException();
            }

            public void OnNext(string value)
            {
                log.Info(value);
            }
        }

        public static StationManager Instance()
        {
            if (_Instance == null)
            {
                _Instance = new StationManager();
                _Instance.Observable().Subscribe(new ObserverMessaggi(log));
            }
            return _Instance;
        }

        public IObservable<string> Observable()
        {
            return subject.AsObservable();
        }

        public void Messaggio(string messaggio)
        {
            subject.OnNext(messaggio);
        }
    }
}
