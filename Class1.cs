using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace ComPortApplication
{
    class MyPort
    {
        int ValueSpeed;
       static SerialPort port;
        public MyPort(string namePort, int IndexSpeed)
        {
            switch (IndexSpeed)
            {
                case 0:
                        ValueSpeed = 2400;
                    break;
                case 1:
                    ValueSpeed = 4800;
                    break;
                case 2:
                    ValueSpeed = 19200;
                    break;
                    
            }
             port = new SerialPort(namePort, ValueSpeed, Parity.None, 8, StopBits.One);


        }
        public void OpenPort()
        {
            port.Open();

        }
        public static void SendMessege(Byte[] data)
        {
            port.Write(data, 0, data.Length);
            System.Threading.Thread.Sleep(300);
        }
        public static string answer()
        {

            
            if (port.BytesToRead > 0)
            {
                Byte[] answer = new byte[port.BytesToRead];     //  Читаем буфер для аналаза ответа на команду Z (управление)
                port.Read(answer, 0, port.BytesToRead);
                string otvet = "";
                foreach (byte elem in answer)
                {
                    otvet += elem.ToString() + " ";
                }
                return otvet;
            }
            else
                return "нет ответа"; 
        }
        static public byte[] codder(string Massege)
        {
            String[] StringData = Massege.Split(' ');
            Byte[] Data = new Byte[StringData.Length];
            int i = 0;
            foreach (string elem in StringData)
            {
                Data[i] = Convert.ToByte(elem, 16);
                ++i;
        
            }
            return Data;
        }
    }
}
