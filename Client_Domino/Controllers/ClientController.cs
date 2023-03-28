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
        public string connectionString;
        public Font fontBotons = new Font("Arial", 35);

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
            f.bt_passarTorn.Click += Bt_passarTorn_Click;
        }

        private async void Bt_passarTorn_Click(object sender, EventArgs e)
        {
            var message = Encoding.UTF8.GetBytes("passarTorn");
            var sendBuffer = new ArraySegment<byte>(message);
            await socket.SendAsync(sendBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async void Bt_StartGame_Click(object sender, EventArgs e)
        {
            string playerName = f.tb_PlayerName.Text.ToString();
            connectionString = "ws://localhost:6666/ws/";//f.tb_ConnectionString.Text.ToString();
            DisableConfigComponents();
            EnableBoardAndTiles();
            jugador = new Jugador(playerName, connectionString);
            await SocketGame();
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
        public async Task SocketGame()
        {
            var cts = new CancellationTokenSource();
            socket = new ClientWebSocket();

            //TODO: Modificar wsUri de local a agafar jugador.ConnectedToString

            string wsUri = $"{connectionString}{jugador.Nom}";
            await socket.ConnectAsync(new Uri(wsUri), cts.Token);
            Console.WriteLine(socket.State);

            var buffer = new byte[1024];
            var receivedTiles = new List<string>();
            bool isMyTurn = false;

            while (socket.State == WebSocketState.Open)
            {
                var rcvBuffer = new ArraySegment<byte>(buffer);

                var receiveResult = await socket.ReceiveAsync(rcvBuffer, CancellationToken.None);

                //Added afer, borrar si no funciona
                cts.CancelAfter(TimeSpan.FromSeconds(30));

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
                            llistaFitxesBotons[i].Font = fontBotons;
                            llistaFitxesBotons[i].Text = receivedTiles[i];

                            //Listener al botó
                            llistaFitxesBotons[i].MouseDown += Button_Click;
                        }
                    }

                    if (receivedData.ToLower().Equals("gamestarted"))
                    {
                        f.lbl_missatgesDelServidor.Text = "El joc ha començat!";

                    }
                    if (receivedData.ToLower().Contains("!"))
                    {
                        //To do refactor
                        string[] fitxes = receivedData.Split(':');

                        string fitxaToShow = fitxes[0].Substring(1);
                        string fitxaAuxiliar = fitxes[1];
                        f.board_fitxes.Text = fitxaToShow + f.board_fitxes.Text;

                        f.lbl_missatgesDelServidor.Text = "Fitxa colocada!";
                        f.lbl_missatgesDelServidor.ForeColor = Color.Green;

                        this.DesactivarBoto(fitxaToShow, llistaFitxesBotons);
                        this.DesactivarBoto(fitxaAuxiliar, llistaFitxesBotons);

                    }
                    if (receivedData.ToLower().Contains("?"))
                    {
                        string[] fitxes = receivedData.Split(':');

                        string fitxaToShow = fitxes[0].Substring(1);
                        string fitxaAuxiliar = fitxes[1];
                        f.board_fitxes.Text += fitxaToShow;

                        f.lbl_missatgesDelServidor.Text = "Fitxa colocada!";
                        f.lbl_missatgesDelServidor.ForeColor = Color.Green;

                        this.DesactivarBoto(fitxaToShow, llistaFitxesBotons);
                        this.DesactivarBoto(fitxaAuxiliar, llistaFitxesBotons);
                    }
                    if (receivedData.ToLower().Equals("fitxanovalida"))
                    {
                        f.lbl_missatgesDelServidor.Text = "Aquesta fitxa no es pot posar!";
                        f.lbl_missatgesDelServidor.ForeColor = Color.Orange;

                    }
                    if (receivedData.ToLower().Equals("notyourturn"))
                    {
                        f.lbl_missatgesDelServidor.Text = "Espera el teu torn!";
                        f.lbl_missatgesDelServidor.ForeColor = Color.Red;

                    }
                    if (receivedData.ToLower().Contains("torn"))
                    {
                        string torn = receivedData.Substring(4);
                        f.lbl_torn.Text = torn;

                    }

                }
                else if (receiveResult.MessageType == WebSocketMessageType.Close)
                {
                    await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing Connection...", CancellationToken.None);
                }

            }
        }

        private void DesactivarBoto(string fitxaToShow, List<Button> llistaBotons)
        {
            foreach (var bt in llistaBotons)
            {
                if (bt.Text.ToString().Equals(fitxaToShow))
                {
                    bt.Enabled = false;
                }
            }
        }
        //Listener del botó, envia el text del botó clickat
        private async void Button_Click(object sender, MouseEventArgs e)
        {
            //To do, diferenciar click left o right i comunicar a servidor
            var button = (Button)sender;
            string text = "";

            if (e.Button == MouseButtons.Left)
            {
                text = "!" + button.Text.ToString();
            }
            if (e.Button == MouseButtons.Right)
            {
                text = "?" + button.Text.ToString();
            }
            var message = Encoding.UTF8.GetBytes(text);
            var sendBuffer = new ArraySegment<byte>(message);
            await socket.SendAsync(sendBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
