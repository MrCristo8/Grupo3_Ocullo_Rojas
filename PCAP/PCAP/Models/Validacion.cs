using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCAP.Models
{
    public class Validacion
    {
        public static bool ValidarCedula(String Ced)
        {
            bool verificacion = true;
            List<string> c = new List<string>();
            foreach (char item in Ced)
            {
                c.Add(item.ToString());
            }
            List<int> cedula = Array.ConvertAll(c.ToArray(), x => int.Parse(x)).ToList();
            int suma = 0, aux = 0;
            if (false) { }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    if (cedula[i] < 0 || cedula[i] >= 10)
                    {
                        verificacion = false;
                        break;
                    }
                }
                if (verificacion == true)
                {
                    int j = 0;
                    while (j < 9)
                    {
                        cedula[j] = cedula[j] * 2;
                        if (cedula[j] > 9)
                        {
                            cedula[j] = cedula[j] - 9;
                        }
                        j = j + 2;
                    }
                    for (int k = 0; k < 9; k++)
                    {
                        suma = suma + cedula[k];
                    }
                    aux = (suma / 10);
                    aux = (aux + 1) * 10;
                    aux = aux - suma;
                    if (aux == 10)
                    {
                        aux = 0;
                    }
                    if (aux != cedula[9])
                    {
                        verificacion = false;
                    }
                }
            }
            return verificacion;
        }
    }
}