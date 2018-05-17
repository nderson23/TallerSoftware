using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Validaciones.Datos;

namespace Validaciones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool errores = false;

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                erpMensaje.SetError(txtNombre, "el nombre es obligatorio");
                errores = true;
            }

            if (string.IsNullOrEmpty(txtCostoServicio.Text))
            {
                erpMensaje.SetError(txtCostoServicio, "El costo es obligatorio ");
                errores = true;
            }

            if (string.IsNullOrEmpty(txtNumeroDocumento.Text))
            {
                MessageBox.Show("El numero de documento es obligatorio");
                errores = true;
            }

            if (errores)
            {
                return;
            }

            if (((TipoDocumento)cboTipoDocumento.SelectedItem).Id == 3)

            {
                if (Convert.ToInt64(txtNumeroDocumento.Text) <= 1000000000)
                {
                    MessageBox.Show("debe ingresar un numero mayor a 1.000.000.000");

                }

                if (Convert.ToInt64(txtNumeroDocumento.Text) >= 9999999999)
                {
                    MessageBox.Show("debe ingresar un numero menor  a 9.999.999.999");
                }
                return;
            }
                                    
            if (Convert.ToInt64(txtCostoServicio.Text) <= 0)
            {
                erpMensaje.SetError(txtCostoServicio, "El numero ingresado debe ser mayor a 0");
                return;
            }                       
            
            Datos.Paciente Registro = new Datos.Paciente();
            Registro.Nombre = txtNombre.Text;
            Registro.NumeroDocumento = Convert.ToInt64(txtNumeroDocumento.Text);
            Registro.CostoServicio = Convert.ToInt64(txtCostoServicio.Text);

            MessageBox.Show("Registro Ingresado Exitosamente");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Collections.Generic.List<Datos.TipoDocumento>
                tiposDocumento = new List<Datos.TipoDocumento>();

            tiposDocumento.Add(new Datos.TipoDocumento() { Id = 1, Nombre = "Cedula Ciudania" });
            tiposDocumento.Add(new Datos.TipoDocumento() { Id = 2, Nombre = "Tarjeta de  extranjeria" });
            tiposDocumento.Add(new Datos.TipoDocumento() { Id = 3, Nombre = "NUIP" });
            tiposDocumento.Add(new Datos.TipoDocumento() { Id = 4, Nombre = "Tarjeta de identidad" });
            cboTipoDocumento.DataSource = tiposDocumento;
            cboTipoDocumento.DisplayMember = "Nombre";

            System.Collections.Generic.List<Datos.Rango>
            rangos = new List<Datos.Rango>();

            rangos.Add(new Datos.Rango() { Id = 1, Nombre = "Rango A" });
            rangos.Add(new Datos.Rango() { Id = 2, Nombre = "Rango B" });
            rangos.Add(new Datos.Rango() { Id = 3, Nombre = "Rango C" });

            cboRango.DataSource = rangos;
            cboRango.DisplayMember = "Nombre";
        }

        private void btnCalcularPago_Click(object sender, EventArgs e)
        {
            double ValorApagar = 0;

            if (((Rango)cboRango.SelectedItem).Id == 1)

            {
                ValorApagar = (Convert.ToInt64(txtCostoServicio.Text) - ((Convert.ToInt64(txtCostoServicio.Text) * 0.30)));

            }
            if (((Rango)cboRango.SelectedItem).Id == 2)
            {
                ValorApagar = (Convert.ToInt64(txtCostoServicio.Text) - ((Convert.ToInt64(txtCostoServicio.Text) * 0.20)));

            }
            if (((Rango)cboRango.SelectedItem).Id == 3)
            {
                ValorApagar = (Convert.ToInt64(txtCostoServicio.Text) - ((Convert.ToInt64(txtCostoServicio.Text) * 0.10)));
            }

            MessageBox.Show("el valor a pagar es de " + ValorApagar);
                                
         }

        private void txtCostoServicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((int)e.KeyChar == 8 ||
              (int)e.KeyChar >= 48 && (int)e.KeyChar <= 59))
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
