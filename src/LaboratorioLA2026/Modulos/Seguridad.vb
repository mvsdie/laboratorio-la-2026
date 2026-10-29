Imports System.Security.Cryptography

Module Seguridad
    Public Function CrearSalt() As String
        'genero un salt distinto para cada usuario
        Dim saltBytes() As Byte = RandomNumberGenerator.GetBytes(16)
        Return Convert.ToBase64String(saltBytes)
    End Function

    Public Function CrearHash(clave As String, saltTexto As String) As String
        'obtengo el hash con el salt guardado
        Dim saltBytes() As Byte = Convert.FromBase64String(saltTexto)
        Dim resultado() As Byte = Rfc2898DeriveBytes.Pbkdf2(clave, saltBytes, 10000, HashAlgorithmName.SHA256, 32)
        Return Convert.ToBase64String(resultado)
    End Function
End Module
