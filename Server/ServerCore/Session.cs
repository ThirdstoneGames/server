using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ServerCore
{
    internal class Session
    {
        Socket _socket;
        int _disconnected = 0;

        object _lock = new object();

        Queue<byte[]> _sendQueue = new Queue<byte[]>();
        List<ArraySegment<byte>> _pendinglist = new List<ArraySegment<byte>>();
       
        SocketAsyncEventArgs _sendArgs = new SocketAsyncEventArgs();
        SocketAsyncEventArgs _recvArgs = new SocketAsyncEventArgs();

        public void Start(Socket socket)
        {
            _socket = socket;

            _recvArgs.Completed += new EventHandler<SocketAsyncEventArgs>(OnRecvCompleted);
            _sendArgs.Completed += new EventHandler<SocketAsyncEventArgs>(OnSendCompleted);
            _recvArgs.SetBuffer(new byte[1024],0,1024);

            RegisterRecv();
        }

        public void Send(byte[] sendBuff)
        {
            //_socket.Send(sendBuff);

            lock (_lock)
            {
                _sendQueue.Enqueue(sendBuff);
                if (_pendinglist.Count == 0)
                {
                    RegisterSend();
                } 
            }
            
        }

        public void Disconnect()
        {
            // disconnect 를 두번하면 발생하는 문제를 막기위함
            // multi-thread 환경이기때문에 Interlocked 를 사용
            if (Interlocked.Exchange(ref _disconnected, 1) == 1)
                return;
            _socket.Shutdown(SocketShutdown.Both);
            _socket.Close();
        }

        #region Net Comm

        void RegisterSend()
        {
            while(_sendQueue.Count > 0)
            {
                byte[] buff = _sendQueue.Dequeue();
                _pendinglist.Add(new ArraySegment<byte>(buff, 0, buff.Length));
            }

            _sendArgs.BufferList = _pendinglist;


            bool pending = _socket.SendAsync(_sendArgs);
            if (pending ==false)
            {
                OnSendCompleted(null, _sendArgs);
            }
        }

        // 전송이 완료됐으면
        void OnSendCompleted(object sender, SocketAsyncEventArgs args)
        {
            lock (_lock)
            {
                if (args.BytesTransferred > 0 && args.SocketError == SocketError.Success)
                {
                    try
                    {
                        _sendArgs.BufferList = null;
                        _pendinglist.Clear();

                        Console.WriteLine($"Transfered bytes : " + _sendArgs.BytesTransferred);
                        if (_sendQueue.Count > 0)
                        {
                            RegisterSend();
                        }
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Send Error {e}");
                    }

                }
                else
                    Disconnect(); 
            }
        }
        void RegisterRecv() 
        {
            bool pending = _socket.ReceiveAsync(_recvArgs);
            if(pending == false)
            {
                OnRecvCompleted(null, _recvArgs);
            }
        }

        void OnRecvCompleted(Object sender, SocketAsyncEventArgs args) 
        {
            if(args.BytesTransferred > 0 && args.SocketError == SocketError.Success) 
            {
                // TODO
                try
                {
                    string recvData = Encoding.UTF8.GetString(args.Buffer, args.Offset, args.BytesTransferred); 
                    Console.WriteLine($"[From Client] {recvData}");
                    RegisterRecv();
                }
                catch(Exception e) 
                {
                    Console.WriteLine($"OnRecvCompleted Failed {e}");
                }
            }
            else
            {
                Disconnect();
            }
        }
        #endregion
    }
}
