using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemperaturaRefuerzoUES
{
    public partial class Form1 : Form
    {
        public int contador = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            int hora = 0;
            int minuto = 0;
            double temperatura = 0;
            string tiempo = String.Empty;
            bool estadoHora = false;
            bool estadoMinuto = false;
            bool estadoTemperatura = false;
            var dta = new DataTable();
            try
            {
                hora = int.Parse(txtHora.Text);
                minuto = Convert.ToInt32(txtMinuto.Text);
                temperatura = Convert.ToDouble(txtTemperatura.Text);
                if (hora >= 0 && hora <= 24)
                {
                    estadoHora = true;
                }
                else
                {
                    MessageBox.Show("Se ingreso una hora fuera de rango");
                    txtHora.Focus();
                }
                if (minuto >= 0 && minuto < 60)
                {
                    estadoMinuto = true;
                }
                else 
                {
                    MessageBox.Show("Se ingresaron minutos fuera de rango");
                    txtMinuto.Focus();
                }
                if (temperatura >= -270)
                {
                    estadoTemperatura = true;
                }
                else 
                {
                    MessageBox.Show("Se ingreso una temperatura fuera de rango");
                    txtMinuto.Focus();
                }
                if (estadoHora && estadoMinuto && estadoTemperatura) 
                {
                    dta.Columns.Add("#");
                    dta.Columns.Add("Temperatura (C°)");
                    dta.Columns.Add("Tipo de Clima");
                    dta.Columns.Add("Hora");
                    if (temperatura < 10)
                    {
                        tiempo = hora + ":" + minuto;
                        dta.Rows.Add(contador,temperatura, "Frio", tiempo);
                        contador=contador+1;
                        
                    }
                    else 
                    {
                        if (temperatura >= 10 && temperatura <= 20)
                        {
                            tiempo = hora + ":" + minuto;
                            dta.Rows.Add(contador, temperatura, "Nublado", tiempo);
                            contador = contador + 1;
                        }
                        else 
                        {
                            tiempo = hora + ":" + minuto;
                            dta.Rows.Add(contador, temperatura, "Calor", tiempo);
                            contador = contador + 1;
                        }
                    }
                    dtaInfo.DataSource = dta;
                }
            }
            catch 
            {
                MessageBox.Show("Sucedio un error!");
            }
        }
    }
}
