using Client_Domino.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Domino.Controllers
{
    public class ClientController
    {
        Form1 f;
        public Jugador jugador;
        public string textHintConnectionString = "IP del host de la partida";
        public string textHintPlayerName = "Introdueix el teu nom";

        public ClientController()
        {
            f = new Form1();
            InitListeners();
            Application.Run(f);
        }

        private void InitListeners()
        {
            f.tb_ConnectionString.GotFocus += Tb_ConnectionString_GotFocus;
            f.tb_PlayerName.GotFocus += Tb_PlayerName_GotFocus;
            f.tb_PlayerName.LostFocus += Tb_PlayerName_LostFocus;
            f.tb_ConnectionString.LostFocus += Tb_ConnectionString_LostFocus;
            f.bt_StartGame.Click += Bt_StartGame_Click;
        }

        private void Bt_StartGame_Click(object sender, EventArgs e)
        {
            string playerName = f.tb_PlayerName.Text.ToString();
            string connectionString = f.tb_ConnectionString.Text.ToString();
            DisableConfigComponents();
            jugador = new Jugador(playerName, connectionString);
        }

        private void Tb_ConnectionString_LostFocus(object sender, EventArgs e)
        {
            if (f.tb_ConnectionString.Text == "" || f.tb_ConnectionString.Text == " ")
            {
                f.tb_ConnectionString.Text = textHintConnectionString;
                f.tb_ConnectionString.ForeColor = Color.LightGray;
                f.tb_ConnectionString.ForeColor = Color.LightGray;
            }
        }

        private void Tb_PlayerName_LostFocus(object sender, EventArgs e)
        {
            if (f.tb_PlayerName.Text == "" || f.tb_PlayerName.Text == " ")
            {
                f.tb_PlayerName.Text = textHintPlayerName;
                f.tb_PlayerName.ForeColor = Color.LightGray;
            }
        }

        private void Tb_PlayerName_GotFocus(object sender, EventArgs e)
        {
            if (f.tb_PlayerName.Text.Equals(textHintPlayerName))
            {
                f.tb_PlayerName.Text = "";
                f.tb_PlayerName.ForeColor = Color.Black;
            }
        }

        private void Tb_ConnectionString_GotFocus(object sender, EventArgs e)
        {
            if (f.tb_ConnectionString.Text.Equals(textHintConnectionString))
            {
                f.tb_ConnectionString.Text = "";
                f.tb_ConnectionString.ForeColor = Color.Black;
            }
        }

        private void DisableConfigComponents()
        {
            f.bt_StartGame.Enabled = false;
            f.tb_ConnectionString.Enabled = false;
            f.tb_ConnectionString.Enabled = false;
        }

        public async Task SocketGame()
        {

            var cts = new CancellationTokenSource();
            var socket = new ClientWebSocket();

            //TODO: Modificar wsUri de local a agafar jugador.ConnectedToString

            string wsUri = $"ws://localhost:6666/ws/{jugador.Nom}";
            await socket.ConnectAsync(new Uri(wsUri), cts.Token);
            Console.WriteLine(socket.State);

            var buffer = new byte[256];
            if (socket.State == WebSocketState.Open)
            {
                await Task.Factory.StartNew(
                    async () =>
                    {
                        var rcvBytes = new byte[256];
                        var rcvBuffer = new ArraySegment<byte>(rcvBytes);
                        while (true)
                        {
                            WebSocketReceiveResult rcvResult = await socket.ReceiveAsync(rcvBuffer, cts.Token);
                            if (rcvResult.MessageType == WebSocketMessageType.Close)
                            {
                                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
                            }
                            else //
                            {
                                byte[] msgBytes = rcvBuffer.Skip(rcvBuffer.Offset).Take(rcvResult.Count).ToArray();
                                string rcvMsg = Encoding.UTF8.GetString(msgBytes);
                                Console.WriteLine(rcvMsg);
                            }
                        }
                    }, cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);

                /*

                //ENVIA MISSATGE
                while (true)
                {
                    string missatge = Console.ReadLine();

                    //missatge per sortir
                    if (missatge == "exit")
                    {
                        cts.Cancel();
                        return;
                    }


                    byte[] sendBytes = Encoding.ASCII.GetBytes(missatge);
                    var sendBuffer = new ArraySegment<byte>(sendBytes);
                    await socket.SendAsync(sendBuffer, WebSocketMessageType.Text, endOfMessage: true, cancellationToken: cts.Token);


                }
                
                 */
            }
        }
    }
}
