using System;
using System.Collections.Generic;
using BestHTTP.SocketIO;
using UnityEngine;

namespace Assets.Scripts.Network
{
    public class Network : MonoBehaviour
    {
        public string Uri;

        private SocketManager _manager;

        public void Start()
        {
            SocketOptions options = new SocketOptions();
            options.AutoConnect = false;

             _manager = new SocketManager(new Uri(Uri), options);

            // Set up custom chat events
            //_manager.Socket.On("login", OnLogin);
            _manager.Socket.On("onconnected", (socket, packet, args) => { Debug.Log("On Connected");});
            //_manager.Socket.On("boop", (socket, packet, args) => { Debug.Log("Boop");});
            //_manager.Socket.On("new message", OnNewMessage);
            //_manager.Socket.On("user joined", OnUserJoined);
            //_manager.Socket.On("user left", OnUserLeft);

            // The argument will be an Error object.
            _manager.Socket.On(SocketIOEventTypes.Error, (socket, packet, args) => Debug.LogError(string.Format("Error: {0}", args[0].ToString())));
            _manager.Socket.On(SocketIOEventTypes.Connect, (socket, packet, args) => Debug.Log("Connect"));
            _manager.Socket.On(SocketIOEventTypes.Disconnect, (socket, packet, args) => Debug.Log("Disconnect"));

            // We set SocketOptions' AutoConnect to false, so we have to call it manually.
            _manager.Open();
        }

        void OnLogin(Socket socket, Packet packet, params object[] args)
        {
            Debug.Log("login");

            addParticipantsMessage(args[0] as Dictionary<string, object>);
        }

        void OnNewMessage(Socket socket, Packet packet, params object[] args)
        {

        }

        void OnUserJoined(Socket socket, Packet packet, params object[] args)
        {
            var data = args[0] as Dictionary<string, object>;
            var username = data["username"] as string;

            addParticipantsMessage(data);
        }

        void OnUserLeft(Socket socket, Packet packet, params object[] args)
        {
            var data = args[0] as Dictionary<string, object>;
            var username = data["username"] as string;

            addParticipantsMessage(data);
        }

        void addParticipantsMessage(Dictionary<string, object> data)
        {
            int numUsers = Convert.ToInt32(data["numUsers"]);
        }
    }
}