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
        List<Button> llistaFitxesBotons;
        ClientWebSocket socket;

        public ClientController()
        {
            f = new Form1();
            InitListeners();
            llistaFitxesBotons = new List<Button>();
            GetAllButtonsInForm();
            Application.Run(f);
        }

        private void GetAllButtonsInForm()
        {
            foreach (Control ctrl in f.grup_fitxes.Controls)
            {
                if (ctrl is Button)
                {
                    llistaFitxesBotons.Add((Button)ctrl);
                }
            }
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
            EnableBoardAndTiles();
            jugador = new Jugador(playerName, connectionString);

            //SocketGame().Wait();
        }

        private void EnableBoardAndTiles()
        {
            f.board_fitxes.Visible = true;
            f.grup_fitxes.Visible = true;
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
            f.tb_PlayerName.Enabled = false;
        }

        //Old socket config
        /*
        public async Task SocketGameOld()
        {

            var cts = new CancellationTokenSource();
            socket = new ClientWebSocket();

            //TODO: Modificar wsUri de local a agafar jugador.ConnectedToString

            string wsUri = $"ws://localhost:6666/ws/{jugador.Nom}";
            await socket.ConnectAsync(new Uri(wsUri), cts.Token);
            Console.WriteLine(socket.State);

            var buffer = new byte[256];

            //llista buida preparada per rebre les fitxes que envii el server
            List<string> fitxesRebudes = new List<string>();
            bool isPlayerTurn = false;

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

        public async Task SocketGame()
        {
            var cts = new CancellationTokenSource();
            socket = new ClientWebSocket();

            //TODO: Modificar wsUri de local a agafar jugador.ConnectedToString

            string wsUri = $"ws://localhost:6666/ws/{jugador.Nom}";
            await socket.ConnectAsync(new Uri(wsUri), cts.Token);
            Console.WriteLine(socket.State);

            var buffer = new byte[1024]; // increase buffer size if necessary
            var receivedTiles = new List<string>();
            bool isMyTurn = false;

            while (socket.State == WebSocketState.Open)
            {
                var rcvBuffer = new ArraySegment<byte>(buffer);

                var receiveResult = await socket.ReceiveAsync(rcvBuffer, CancellationToken.None);

                if (receiveResult.MessageType == WebSocketMessageType.Text)
                {
                    var receivedData = Encoding.UTF8.GetString(buffer, 0, receiveResult.Count);

                    // es mira si és el torn del jugador o no. El servidor ha d'enviar el missatge true o false;
                    if (receivedData.ToLower() == "true" || receivedData.ToLower() == "false")
                    {
                        isMyTurn = bool.Parse(receivedData.ToLower());
                    }
                    if (receivedData.ToLower().Contains(";")) // quan el servidor envii la llista de fitxes separades cada una per ;
                    {
                        receivedTiles.AddRange(receivedData.Split(';')); // assuming tiles are separated by ';'

                        for (int i = 0; i < receivedTiles.Count; i++)
                        {
                            llistaFitxesBotons[i].Text = receivedTiles[i];
                        }
                    }
                }
                else if (receiveResult.MessageType == WebSocketMessageType.Close)
                {
                    await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
                }

                // do something with the received data here
                if (isMyTurn)
                {
                    //f.grup_fitxes.Enabled = true;
                }
                if (!isMyTurn)
                {
                    //f.grup_fitxes.Enabled = false;
                }

            }
        }



    }
}
