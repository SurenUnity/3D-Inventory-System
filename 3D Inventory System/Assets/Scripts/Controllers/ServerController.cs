using System.Collections;
using MassageBrokers;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

namespace Controllers
{
    public class ServerController
    {
        private string _url = "https://dev3r02.elysium.today/inventory/status";

        public ServerController()
        {
            MessageBroker.Default
                .Receive<WebRequestMassage>()
                .Subscribe(_ => Login());
        }

        private async void Login()
        {
            var form = new WWWForm();
            form.AddField("auth", "BMeHG5xqJeB4qCjpuJCTQLsqNGaqkfB6");

            var request = UnityWebRequest.Post(_url, form);

            await request.SendWebRequest().AsObservable();
        }
    }
}
