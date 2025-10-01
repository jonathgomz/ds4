Public Module Program
    Public Sub Main(args() As String)
        Dim perrito As Perro = New Perro()
        perrito.nombre = "Chizu"
        perrito.raza = "Pastor aleman"
        perrito.altura = "0.70 cm"

        Console.WriteLine(perrito.comer("carne"))

        Dim perrito2 As Perro = New Perro()
        perrito2.nombre = "Lazy"
        perrito2.altura = "0.60"

        Console.WriteLine(perrito2.comer("pollo"))

        Dim perrito3 As Perro = New Perro("Peluchin", "Poodle", "0.50")
        Console.WriteLine(perrito3.comer("pan"))
    End Sub
End Module