using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore
{
    class Listener
    {
        Socket _listenSocket;
        Action<Socket> _onAcceptHandler;

        public void Init(IPEndPoint endPoint, Action<Socket> onAcceptHandler)
        {
            _listenSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _onAcceptHandler += onAcceptHandler;
            _listenSocket.Bind(endPoint);
            _listenSocket.Listen(10);

            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.Completed += new EventHandler<SocketAsyncEventArgs>(OnAcceptCompleted);
            RegisterAccept(args);
        }

        void RegisterAccept(SocketAsyncEventArgs args)
        {
            args.AcceptSocket = null;

            bool pending = _listenSocket.AcceptAsync(args);
            if (pending == false)
            {
                OnAcceptCompleted(null, args);
            }
        }

        // 실제 accept 가 이루어졌다면 OnAcceptCompleted 실행
        // redzone (멀티스레드에서 문제가 발생할 수 있는 영역
        // 지금은 데이터가 race condition 을 할 일이 없겠지만
        // 복잡해 진다면 lock 을 건다거나. 해야 한다. 
        void OnAcceptCompleted(object sender, SocketAsyncEventArgs args)
        {
            if(args.SocketError == SocketError.Success)
            {
                //SocketAsyncEventArgs 가 Socket 을 뱉어준다
                //AcceptSocket 은 리스너 전용일때 사용된다
                _onAcceptHandler.Invoke(args.AcceptSocket);
            }
            else
                Console.WriteLine(args.SocketError.ToString());

            RegisterAccept(args);
        }
     
    }
}
