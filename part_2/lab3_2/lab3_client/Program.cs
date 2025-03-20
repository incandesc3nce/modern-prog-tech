using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MeetingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            bool meetingCompleted = false;
            int attempt = 0;

            while (!meetingCompleted)
            {
                attempt++;
                
                string invitation = attempt == 1 
                    ? "Приглашение на встречу" 
                    : "Повторное приглашение на встречу";

                Console.WriteLine("Отправляем: " + invitation);
                string response = SendAndReceive(invitation);
                Console.WriteLine("Ответ от сервера: " + response);

                
                if (response.Trim().ToLower() == "да")
                {
                    
                    string timeRequest = "Время";
                    string meetingTime = SendAndReceive(timeRequest);
                    Console.WriteLine("Время встречи: " + meetingTime);
                    meetingCompleted = true;
                }
                
                else if (response.Trim().ToLower() == "нет")
                {
                    Console.WriteLine("Встреча не состоится.");
                    meetingCompleted = true;
                }
                
                else if (response.Trim().ToLower() == "позвони позже")
                {
                    Console.WriteLine("Сервер просит позвонить позже. Ждем 5 секунд...");
                    Thread.Sleep(5000);
                    
                }
                else
                {
                    Console.WriteLine("Получен неожиданный ответ. Завершаем работу.");
                    meetingCompleted = true;
                }
            }

            Console.WriteLine("Клиент завершил работу.");
        }

        static string SendAndReceive(string message)
        {
            int port = 11000;
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = ipHost.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
            string response = "";
            Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sender.Connect(remoteEP);
                Console.WriteLine("Соединение установлено с: " + sender.RemoteEndPoint.ToString());
                byte[] msg = Encoding.UTF8.GetBytes(message);
                sender.Send(msg);
                byte[] bytes = new byte[1024];
                int bytesRec = sender.Receive(bytes);
                response = Encoding.UTF8.GetString(bytes, 0, bytesRec);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            finally
            {
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            return response;
        }
    }
}
