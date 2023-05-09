Imports System.Security.Cryptography

Public Class clsRGEncrypt

    Public Function RGEncrypt(ByVal raw As String) As String
        Using csp = New AesCryptoServiceProvider()
            Dim e As ICryptoTransform = GetCryptoTransform(csp, True)
            Dim inputBuffer As Byte() = Encoding.UTF8.GetBytes(raw)
            Dim output As Byte() = e.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length)
            Dim encrypted As String = Convert.ToBase64String(output)
            Return encrypted
        End Using
    End Function

    Public Function RGDecrypt(ByVal encrypted As String) As String
        Using csp = New AesCryptoServiceProvider()
            Dim d = GetCryptoTransform(csp, False)
            Dim output As Byte() = Convert.FromBase64String(encrypted)
            Dim decryptedOutput As Byte() = d.TransformFinalBlock(output, 0, output.Length)
            Dim decypted As String = Encoding.UTF8.GetString(decryptedOutput)
            Return decypted
        End Using
    End Function

    Private Shared Function GetCryptoTransform(ByVal csp As AesCryptoServiceProvider, ByVal encrypting As Boolean) As ICryptoTransform
        csp.Mode = CipherMode.CBC
        csp.Padding = PaddingMode.PKCS7
        Dim passWord = "Pass@word1"
        Dim salt = "S@1tS@lt"
        Dim iv As String = "e675f725e675f725"
        Dim spec = New Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(passWord), Encoding.UTF8.GetBytes(salt), 65536)
        Dim key As Byte() = spec.GetBytes(16)
        csp.IV = Encoding.UTF8.GetBytes(iv)
        csp.Key = key

        If encrypting Then
            Return csp.CreateEncryptor()
        End If

        Return csp.CreateDecryptor()
    End Function

    Public Function EncodeBase64(input As String) As String
        Return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input))
    End Function

    Public Function DecodeBase64(input As String) As String
        Return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(input))
    End Function

End Class
