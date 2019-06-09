Imports System.Data.SqlClient

Public Class clsTaxPayerDA

    Public Shared Function getTaxPayer(ByVal intTaxPayerID As Integer) As TaxPayerStructure
        Dim connection As SqlConnection = clsConnection.getConnection()
        Dim strSelectStatement As String = "SELECT * FROM [TaxReturn2014].[dbo].[tblTaxPayer] WHERE TaxPayerID =" & intTaxPayerID
        Dim command As New SqlCommand(strSelectStatement, connection) '
        connection.Open()
        Dim reader As SqlDataReader = command.ExecuteReader(CommandBehavior.SingleRow)

        Dim myTaxPayer As TaxPayerStructure

        If reader.Read Then
            myTaxPayer.strTaxPayerLastName = reader.GetString(1)
            myTaxPayer.strTaxPayerFirstName = reader.GetString(2)
            myTaxPayer.strTaxPayerInitial = reader.GetString(3)
            myTaxPayer.strTaxPayerAddress = reader.GetString(4)
            myTaxPayer.strTaxPayerCity = reader.GetString(5)
            myTaxPayer.strTaxPayerState = reader.GetString(6)
            myTaxPayer.strTaxPayerZip = reader.GetString(7)
        Else
            Throw New ArgumentException("ERROR DB001: The Tax Payer record does not exist in the database.")
        End If
        connection.Close()
        Return myTaxPayer
    End Function

    Public Shared Function updateTaxPayer(ByRef newTaxPayer As TaxPayerStructure) As Integer
        Dim connection As SqlConnection = clsConnection.getConnection()

        Dim strUpdateStatement As String =
            "UPDATE [tblTaxPayer] SET [TaxPayerLastName] = '" & newTaxPayer.strTaxPayerLastName & _
            "', [TaxPayerFirstName] = '" & newTaxPayer.strTaxPayerLastName & _
            "', [TaxPayerInitial] = '" & newTaxPayer.strTaxPayerInitial & _
            "', [TaxPayerAddress] = '" & newTaxPayer.strTaxPayerAddress & _
            "', [TaxPayerCity] ='" & newTaxPayer.strTaxPayerCity & _
            "', [TaxPayerState] = '" & newTaxPayer.strTaxPayerState & _
            "', [TaxPayerZip] ='" & newTaxPayer.strTaxPayerZip & _
            "',  WHERE [TaxPayerID] = " & newTaxPayer.intTaxPayerID & ";"

        Dim command As New SqlCommand(strUpdateStatement, connection)
        connection.Open()
        Return command.ExecuteNonQuery()
    End Function
End Class
