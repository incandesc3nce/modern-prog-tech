using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MeetingServer
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 11000;
            
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);
                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    
                    Socket handler = listener.Accept();
                    string data = "";
                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec).ToLower();
                    Console.WriteLine("Получено сообщение: " + data);

                    string response = "";
                    
                    if (data.Contains("приглашение"))
                    {
                        
                        if (data.Contains("повторное"))
                        {
                            Console.WriteLine("Получено повторное приглашение.");
                            Console.Write("Введите ответ (да/нет): ");
                            response = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Получено приглашение.");
                            Console.Write("Введите ответ (да/нет/позвони позже): ");
                            response = Console.ReadLine();
                        }
                    }
                    
                    else if (data.Contains("время"))
                    {   
                        Console.Write("Введите время встречи: ");
                        response = Console.ReadLine();
                        if (response == "") {
                            response = "10:00";
                        }
                        Console.WriteLine("Клиент запросил время встречи. Отправляем: " + response);
                    }
                    else
                    {
                        response = "Неверное сообщение";
                    }

                    byte[] msg = Encoding.UTF8.GetBytes(response);
                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}
