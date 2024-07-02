﻿using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace ChatApp.Helpers
{
    public static class ChatHelper
    {
        public static HubConnection hubConnection;

        public static bool IsConnected { get; set; }

        public static HubConnection GetInstanse(string chatUsername)
        {
            if (hubConnection == null || hubConnection.State == HubConnectionState.Disconnected)
            {
                hubConnection = new HubConnectionBuilder()
                .WithUrl("http://192.168.0.163:45455/chatHub?chatUsername=" + chatUsername)
                .Build();
            }
            
            return hubConnection;            
        }

        public static async Task Connect(string chatUsername = null)
        {
            if (IsConnected)
            {
                return;
            }

            try
            {
                await GetInstanse(chatUsername).StartAsync();
                IsConnected = true;                
            }
            catch (Exception ex)
            {
                
            }
        }

        public static async Task Disconnect(string chatUsername = null)
        {
            if (!IsConnected)
            {
                return;
            }

            try
            {
                await GetInstanse(chatUsername).StopAsync();
                IsConnected = false;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
