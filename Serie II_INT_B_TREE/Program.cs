using System;
using DataStructures;

namespace Serie_II_INT_B_TREE
{
    class Program
    {
        static void Main(string[] args)
        {
            inicio:
            Console.WriteLine("Ingrese grado del arbol B (Numero entero impar mayor que 3)");
            int degree = 0;

            if(int.TryParse(Console.ReadLine(), out degree) && degree >= 3 && degree % 2 == 1)
            {
                B_Tree<int> b_Tree = new B_Tree<int>(degree);
                bool continuar = true;
                do
                {
                    Console.Clear();
                    Console.WriteLine("1. Ingresar un nuevo elemento");
                    Console.WriteLine("2. Eliminar un elemento");
                    Console.WriteLine("3. Verificar si existe un elemento");
                    Console.WriteLine("4. Imprimir todos los elementos del arbol");
                    Console.WriteLine("5. Salir");
                    Console.WriteLine("Ingrese una opción:");

                    int option = 0;
                    if (int.TryParse(Console.ReadLine(), out option))
                    {
                        switch (option)
                        {
                            case 1:
                            insert:
                                Console.WriteLine("Ingrese un numero entero diferente de 0");
                                int newElement = 0;
                                if (int.TryParse(Console.ReadLine(), out newElement))
                                {
                                    if (b_Tree.search(newElement) == 0)
                                    {
                                        b_Tree.Insert(newElement);
                                        Console.WriteLine("Valor ingresado correctamente");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se pudo ingresar, valor repetido");
                                        goto insert;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("El valor ingresado no es un entero, vuelva a intentarlo");
                                    goto insert;
                                }
                                break;
                            case 2:
                            delete:
                                Console.WriteLine("Ingrese el numero a eliminar");
                                int element = 0;
                                if (int.TryParse(Console.ReadLine(), out element))
                                {
                                    if (b_Tree.search(element) != default)
                                    {
                                        b_Tree.Remove(element);
                                        Console.WriteLine("Valor eliminado correctamente");
                                    }
                                    else
                                    {
                                        Console.WriteLine("El valor ingresado no existe");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("El valor ingresado no es un entero, vuelva a intentarlo");
                                    goto delete;
                                }
                                break;
                            case 3:
                            verificar:
                                Console.WriteLine("Ingrese el numero a verificar");
                                int verify_element = 0;
                                if (int.TryParse(Console.ReadLine(), out verify_element))
                                {
                                    if (b_Tree.search(verify_element) != default)
                                    {
                                        Console.WriteLine("El valor si existe");
                                    }
                                    else
                                    {
                                        Console.WriteLine("El valor ingresado no existe");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("El valor ingresado no es un entero, vuelva a intentarlo");
                                    goto verificar;
                                }
                                break;
                            case 4:
                            imprimir:
                                Console.WriteLine("El resultado es: \n" + b_Tree.printTree());
                                break;
                            case 5:
                                continuar = false;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opción incorrecta, vuelva a intentarlo");
                    }
                    Console.ReadLine();

                } while (continuar);
            }
            else
            {
                Console.WriteLine("Grado invalido, intentelo de nuevo");
                goto inicio;
            }
        }
    }
}
