Imports System.Data.SqlClient

Public Class clsJointTaxPayerDA

    Public Shared Function getSpouce(ByVal intSpouceID As Integer) As SpouceTableStructure
        Dim connection As SqlConnection = clsConnection.getConnection()
        Dim strSelectStatement As String = "SELECT * FROM [TaxReturn2014].[dbo].[tblJointTaxPayer] WHERE TaxPayerID =" & intSpouceID
        Dim command As New SqlCommand(strSelectStatement, connection) '
        connection.Open()
        Dim reader As SqlDataReader = command.ExecuteReader(CommandBehavior.SingleRow)

        Dim myTaxPayer As SpouceTableStructure

        If reader.Read Then

            myTaxPayer.strJointLastName = reader.GetString(0)
            myTaxPayer.strJointFirstName = reader.GetString(1)
            myTaxPayer.strJointInitial = reader.GetString(2)
        Else
            Throw New KeyNotFoundException("The Joint Tax Payer record does not exist in the database." & vbCrLf & vbCrLf & _
                                      "Use the right of the screen to add a new Joint Tax Payer.")
        End If
        connection.Close()
        Return myTaxPayer
    End Function

    Public Shared Function insertSpouce(ByVal myJointTaxPayer As SpouceTableStructure) As Integer
        Dim connection As SqlConnection = clsConnection.getConnection()
        Dim strInsertStatement As String = "INSERT INTO [TaxReturn2014].[dbo].[tblJointTaxPayer] ([TaxPayerID], [JointLastName], [JointFirstName], [JointInitial]) VALUES (" & myJointTaxPayer.intTaxPayerID & ", '" & myJointTaxPayer.strJointLastName & "', '" & myJointTaxPayer.strJointFirstName & "', '" & myJointTaxPayer.strJointInitial & "') "
        Dim command As New SqlCommand(strInsertStatement, connection) '
        connection.Open()
        Dim intQueryResult As Integer = command.ExecuteNonQuery()
        connection.Close()
        Return intQueryResult
    End Function

    Public Shared Function deleteSpouce(ByVal intTaxPayerID As Integer) As Integer
        Dim connection As SqlConnection = clsConnection.getConnection()
        Dim strDeleteStatement As String = "DELETE FROM [TaxReturn2014].[dbo].[tblJointTaxPayer] WHERE TaxPayerID =" & intTaxPayerID
        Dim command As New SqlCommand(strDeleteStatement, connection) '
        connection.Open()
        Dim intQueryResult As Integer = command.ExecuteNonQuery()
        connection.Close()
        Return intQueryResult
    End Function

End Class
