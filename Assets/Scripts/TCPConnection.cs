using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using System.Collections.Generic;
using TMPro;


public static class TcpConnection
{

    private static TcpClient _socketConnection;
    private static Thread _clientReceiveThread;
    public static List<String> messages;
    public static int count;
    public static void ConnectToTcpServer(string IP, int Port)
    {
        try {  			
            _clientReceiveThread = new Thread(() => ListenForData(IP, Port));
            _clientReceiveThread.Start();  	
            Debug.Log("Connected to server"); 	
        } 		
        catch (Exception e) { 		
            connect_to_server._connected = false;
            Debug.Log("On client connect exception " + e); 		
        } 
    }

    private static void ListenForData(string IP, int Port) { 		
        try { 			
            _socketConnection = new TcpClient();
            _socketConnection.Connect(IP, Port);
            Debug.Log("the serve is now listening");
            Byte[] bytes = new Byte[1024];
            messages = new List<string>();
            count = 0;
            while (true)
            {
                // Get a stream object for reading 				
                using NetworkStream stream = _socketConnection.GetStream();
                int length; 
                Debug.Log(stream.Read(bytes, 0, bytes.Length));
                // Read incoming stream into byte array. 	
                
                while ((length = stream.Read(bytes, 0, bytes.Length)) != 0) { 						
                    var incomingData = new byte[length]; 						
                    Array.Copy(bytes, 0, incomingData, 0, length); 						
                    // Convert byte array to string message. 						
                    string serverMessage = Encoding.ASCII.GetString(incomingData);
                    messages.Add(serverMessage);
                    if (serverMessage == "lyrics")
                    {
                        count++;
                    }
                    Debug.Log("server message received as: " + serverMessage); 					
                }
            }
        }         
        catch (SocketException socketException)
        {
            connect_to_server._connected = false;
            Debug.Log("Socket listener exception: " + socketException);
        }   
        connect_to_server._connected = false;
        
    }

    public static void SendMessage(string clientMessage)
    {
        if (_socketConnection == null) {             
            return;         
        }  		
        try { 			
            // Get a stream object for writing. 			
            NetworkStream stream = _socketConnection.GetStream(); 			
            if (stream.CanWrite) {
                // Convert string message to byte array.                 
                byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage); 				
                // Write byte array to socketConnection stream.                 
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);                 
                Debug.Log("Client sent his message - should be received by server");             
            }         
        } 		
        catch (SocketException socketException) {             
            Debug.Log("Socket sender exception: " + socketException);         
        }  
    }
}

