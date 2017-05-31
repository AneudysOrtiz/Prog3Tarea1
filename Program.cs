using System;

namespace CalculadoraPrestamos
{
    class MainClass

    {
        double prestamo, interes,meses, res;
        int cont;
        bool continuar=true;




        public void Iniciar(){

            while(continuar){




                Console.WriteLine("\nIngrese el monto del prestamo: ");
                prestamo = double.Parse(Console.ReadLine());

                Console.WriteLine("\nIngrese la duracion del prestamo (meses): ");
                meses = double.Parse(Console.ReadLine());

                Console.WriteLine("\nIngrese el porcentaje de interes mensual: ");
                interes = double.Parse(Console.ReadLine());

                double cx = 1 + (interes / 100);
                cx = 1 / cx;
                cx = Math.Pow(cx, meses);
                cx = 1 - cx;
                res = ((interes / 100) * prestamo) / cx;


                Console.WriteLine("-----------------------------------------------------------------------");

                Console.WriteLine("\nEL monto a pagar mensual es de: RD$ " + res +"\n");


                Console.WriteLine("\t\t\t\t\t\t\t****** Tabla de Amortizacion ******");
                Tabla();

				Console.WriteLine("\nDesea hacer otro calculo? \n1- Si\n2- No");
				cont= int.Parse(Console.ReadLine());

                if(cont==2){
                    continuar = false;
                    Environment.Exit(0);

                }else if(cont!=1){
                    Console.WriteLine("\n***** Opcion no valida ******");
					Console.WriteLine("\nDesea hacer otro calculo? \n1- Si\n2- No");
					cont = int.Parse(Console.ReadLine());

                }


            }


			

        }

        public void Tabla(){

            int n = Convert.ToInt32(meses)+1;

			string[,] tabla = new string [n, 6];

            tabla[0, 0]= "Mes";
            tabla[0, 1] = "Saldo Inicial";
            tabla[0, 2] = "Amortizacion";
            tabla[0, 3] = "Interes       ";
            tabla[0, 4] = "Pago";
            tabla[0, 5] = "Saldo Final";

           


            double saldoI = prestamo;
            double interesP = (saldoI * interes) / 100;
            double amortizacion = res - interesP;
            double saldoF = saldoI - amortizacion;

            //Llenando la tabla
            for (int i = 1; i < n;i++){
                
                int mes = i;
                tabla[i, 0] = mes.ToString();
                tabla[i, 1] = "RD$ " + Math.Round(saldoI,2).ToString()+ "   ";
                tabla[i, 2] = "RD$ " + Math.Round(amortizacion, 2).ToString()+ "   ";
                tabla[i, 3] = "RD$ " + Math.Round(interesP, 2).ToString()+"   ";
                tabla[i, 4] = "RD$ " + Math.Round(res, 2).ToString()+ "   ";
                tabla[i, 5] = "RD$ " + Math.Round(saldoF, 2).ToString()+ "   ";


                saldoI = saldoF;
				interesP = (saldoI * interes) / 100;
				 amortizacion = res - interesP;
				 saldoF = saldoI - amortizacion;

            }


            //Imprimiendo la Tabla
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < 6; j++)
				{
                    Console.Write("\t"+tabla[i,j]+"\t");
					
				}
                Console.Write("\n");
			}



        }


        public static void Main(string[] args)
        {
            Console.WriteLine("\n\t\t\t############################" +
                              "\n\t\t\t# Calculadora de Prestamos #" +
                              "\n\t\t\t############################");

            MainClass calc = new MainClass();
            calc.Iniciar();

        }
    }
}
