Module area

    Sub Main()
        Dim radio As Single
        Dim area As Single
        Dim circumferencia As Single
        Const pi = 3.1415926

        Console.Write("Ingrese el radio: ")
        radio = Console.ReadLine

        area = pi * radio ^ 2
        circumferencia = 2 * pi * radio

        Console.WriteLine("El area es : {0}", area)
        Console.WriteLine("La circumferencia es : {0}", circumferencia)

        Console.ReadKey()
    End Sub

End Module