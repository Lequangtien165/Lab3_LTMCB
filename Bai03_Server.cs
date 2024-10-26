using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_23521572_LeQuangTien
{
    public partial class Bai03_Server : Form
    {
        private TcpListener tcpListener;
        private CancellationTokenSource cts;
        private int port;
        private IPAddress localIPAddress;

        public Bai03_Server()
        {
            InitializeComponent();
        }

        private async void bt_listen_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tb_IP.Text) ||
                string.IsNullOrEmpty(tb_port.Text))
                {
                    MessageBox.Show("Please enter all required information", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!IPAddress.TryParse(tb_IP.Text, out _))
                {
                    MessageBox.Show("Invalid IP Address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(tb_port.Text, out int port) || port < 1 || port > 65535)
                {
                    MessageBox.Show("Invalid port number (must be between 1-65535)", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                localIPAddress = IPAddress.Parse(tb_IP.Text);
                tcpListener = new TcpListener(localIPAddress, port);
                tcpListener.Start();
                AppendToRichTextBox($"Server is listening on {localIPAddress}:{port}\n");

                cts = new CancellationTokenSource();
                await Task.Run(() => ListenForClients(cts.Token));
            }
            catch (Exception ex)
            {
                AppendToRichTextBox($"Error starting server: {ex.Message}\n");
            }
        }

        private async Task ListenForClients(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    TcpClient client = await tcpListener.AcceptTcpClientAsync();
                    AppendToRichTextBox("Client connected.\n");
                    _ = HandleClientComm(client, token);
                }
            }
            catch (OperationCanceledException)
            {
                AppendToRichTextBox("Server stopped listening.\n");
            }
            catch (Exception ex)
            {
                AppendToRichTextBox($"Error in listener: {ex.Message}\n");
            }
        }

        private async Task HandleClientComm(TcpClient client, CancellationToken token)
        {
            try
            {
                using (client)
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;

                    while (!token.IsCancellationRequested &&
                           (bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, token)) != 0)
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        AppendToRichTextBox($"Received: {message}\n");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Ignore, this is expected when cancelling
            }
            catch (Exception ex)
            {
                AppendToRichTextBox($"Error: {ex.Message}\n");
            }
            finally
            {
                AppendToRichTextBox("Client disconnected.\n");
            }
        }

        private void AppendToRichTextBox(string text)
        {
            if (rtb_rcv_mess.InvokeRequired)
            {
                rtb_rcv_mess.BeginInvoke(new Action<string>(AppendToRichTextBox), text);
            }
            else
            {
                rtb_rcv_mess.AppendText(text);
            }
        }

        private void StopServer()
        {
            cts?.Cancel();
            tcpListener?.Stop();
        }

        private void Bai03_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopServer();
        }
    }
}
