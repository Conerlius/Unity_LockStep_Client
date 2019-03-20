using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
namespace WDLockstep
{
    public class WDClient : MonoBehaviour
    {
        int port = 6000;
        string host = "127.0.0.1";//服务器端ip地址
                                  //创建连接的Socket
        Socket socketSend;
        //创建接收客户端发送消息的线程
        Thread threadReceive;
        List<string> frames = new List<string>();
        private static WDClient _instance = null;
        // Start is called before the first frame update
        void Start()
        {
            _instance = this;
            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);
            socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Udp);
            socketSend.Connect(ipe);
            //开启一个新的线程不停的接收服务器发送消息的线程
            threadReceive = new Thread(new ThreadStart(Receive));
            //设置为后台线程
            threadReceive.IsBackground = true;
            threadReceive.Start();
        }

        /// <summary>
        /// 接口服务器发送的消息
        /// </summary>
        private void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[2048];
                    //实际接收到的字节数
                    int r = socketSend.Receive(buffer);
                    if (r == 0)
                    {
                        break;
                    }
                    else
                    {
                        string str = Encoding.ASCII.GetString(buffer, 0, r);
                        lock (frames)
                        {
                            frames.Add(str);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public void Send(string sendStr)
        {
            //string sendStr = "Begin=>prepare to begin";
            byte[] sendBytes = Encoding.ASCII.GetBytes(sendStr);
            socketSend.Send(sendBytes);
        }
        private static List<string> mList = new List<string>();
        public static List<string> GetFrames()
        {
            mList.Clear();
            lock (_instance.frames)
            {
                mList.AddRange(_instance.frames);
                _instance.frames.Clear();
            }
            return mList;
        }
        public static WDClient Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}