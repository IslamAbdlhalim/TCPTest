using TCPTest;

Server.StartListening();
Client.ConnectToSever();
Server.AcceptConnection();
Client.SendMessageStream();
Server.ReadMessageStream();

