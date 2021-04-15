using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LoginDiseño
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
            //Como el evento es enter, significa que si el Texto en el TextBox es 
            //usuario(lo cual se cumple) entonces al entrar vaciamos el texto y cambiamos el color de la fuente
            //a un tono mas claro y resaltable
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text="USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }//De lo contrario si no estamos dentro usamos el evento leave, que se no ingresamos nada entonces dejamos
            //al TextBox con el texto inicialmente, en este caso "USUARIO"
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")//Lo mismo aplica para el TextBox de contraseña
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.LightGray;
                txtContraseña.UseSystemPasswordChar = true;//Para validar el textBox como contraseña
                //De esta forma, se observan puntos al ingresar datos, o si esta en mayusculas o no
                verPass.Visible = true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "CONTRASEÑA";
                txtContraseña.ForeColor = Color.DimGray;
                txtContraseña.UseSystemPasswordChar = false;//Si regresa, entonces se quita el modo contraseña y se 
                //muestra el mismo texto: "Contraseña"
                verPass.Visible = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            //boton salir
            //podria hacerse:
            //Application.Exit();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {//Con este codigo cada objeto que le agreguemos estas lineas, podran mover la pantalla
            //de acuerdo a los metodos declarados inicialmente para estas funciones
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//Minimiza la pantalla
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void verPass_MouseHover(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = false;
        }

        private void verPass_MouseLeave(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = true;
        }
    }
}
