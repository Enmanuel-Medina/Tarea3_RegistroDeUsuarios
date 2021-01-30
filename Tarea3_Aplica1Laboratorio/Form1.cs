using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tarea3_Aplica1Laboratorio.BLL;
using Tarea3_Aplica1Laboratorio.Entidades;

namespace Tarea3_Aplica1Laboratorio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            AliasTextBox.Text = String.Empty;
            NombreTextBox.Text = String.Empty;
            EmailTextBox.Text = String.Empty;
            RolIdTextBox.Text = String.Empty;
            ClaveTextBox.Text = String.Empty;
            FechaTimePicker.Value = DateTime.Now;

        }
        private Usuario LLenaClase()
        {
            Usuario usuario = new Usuario();

            usuario.UsuarioId = Convert.ToInt32(IdNumericUpDown.Value);
            usuario.Alias = AliasTextBox.Text;
            usuario.Nombre = NombreTextBox.Text;
            usuario.Email = EmailTextBox.Text;
            usuario.RolId = RolIdTextBox.Text;
            usuario.Clave = ClaveTextBox.Text;
            usuario.FechaIgreso = FechaTimePicker.Value;
            return usuario;
        }
        private void LLenaCampo(Usuario usuario)
        {
            IdNumericUpDown.Value = usuario.UsuarioId;
            AliasTextBox.Text = usuario.Alias;
            NombreTextBox.Text = usuario.Nombre;
            EmailTextBox.Text = usuario.Email;
            RolIdTextBox.Text = usuario.RolId;
            ClaveTextBox.Text = usuario.Clave;
            FechaTimePicker.Value = usuario.FechaIgreso;

        }
        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                MyErrorProvider.SetError(NombreTextBox, "El campo Descripcion no puede estar vacio");
                NombreTextBox.Focus();
                paso = false;
            }
            return paso;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Usuario usuario = UsuarioBLL.Buscar((int)IdNumericUpDown.Value);
            return (usuario != null);
        }


        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();
            usuario = UsuarioBLL.Buscar(id);

            if (usuario != null)
                LLenaCampo(usuario);
            else
                MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Usuario roles;

            if (!Validar())
                return;
            roles = LLenaClase();

            if (IdNumericUpDown.Value == 0)
                paso = UsuarioBLL.Guardar(roles);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un usuario que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = UsuarioBLL.Modificar(roles);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();
            if (UsuarioBLL.Buscar(id) != null)
            {
                if (UsuarioBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("No se puede eliminar el usuario que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }

